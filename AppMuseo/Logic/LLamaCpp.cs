using LLama;
using LLama.Common;
using LLama.Sampling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMuseo.Logic
{
    internal class LLamaCpp : ILLamaCpp
    {
        
        ChatHistory chatHistory;
        ChatSession session;

        InferenceParams inferenceParams = new InferenceParams()
        {
            MaxTokens = 256, // No more than 256 tokens should appear in answer. Remove it if antiprompt is enough for control.
            AntiPrompts = new List<string> { "User:" }, // Stop generation once antiprompts appear.
            SamplingPipeline = new DefaultSamplingPipeline(),
        };


        public LLamaCpp(string path, uint? ContextSize = 1024, int GpuLayerCount =5)
        {
            string modelPath = Path.Combine(FileSystem.Current.AppDataDirectory, path);

            ModelParams parameters = new ModelParams(modelPath)
            {
                ContextSize = ContextSize, //The longest length of chat as memory.
                GpuLayerCount = GpuLayerCount //How many layers to offload to GPU. Please adjust it according to your GPU memory.
            };

            LLamaWeights model = LLamaWeights.LoadFromFile(parameters);
            LLamaContext context = model.CreateContext(parameters);
            InteractiveExecutor executor = new InteractiveExecutor(context);

            // Add chat histories as prompt to tell AI how to act.
            chatHistory = new ChatHistory();
            chatHistory.AddMessage(AuthorRole.System, "Transcript of a dialog, where the User interacts with an Assistant named Bob. Bob is helpful, kind, honest, good at writing, and never fails to answer the User's requests immediately and with precision.");
            chatHistory.AddMessage(AuthorRole.User, "Hello, Bob.");
            chatHistory.AddMessage(AuthorRole.Assistant, "Hello. How may I help you today?");

            session = new ChatSession(executor, chatHistory);

        }

        public async IAsyncEnumerable<string> ChatAsync(string input)
        {
            await foreach (var text in session.ChatAsync(new ChatHistory.Message(AuthorRole.User, input), inferenceParams))
            {
                yield return text;
            }
        }
    }
}
