using LLama;
using LLama.Common;
using LLama.Sampling;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMuseo.Logic.Services
{
    internal class LLamaCpp : ILLamaCpp
    {
        private ChatSession? _session;

        static InferenceParams defaultIferenceParams = new InferenceParams()
        {
            AntiPrompts = new List<string> {"If you want to hear more about this artwork, just ask me!", "I hope you enjoyed this story!", "User:", },
            SamplingPipeline = new DefaultSamplingPipeline(),
        };

        ChatSession Session
        {
            get
            {
                if (_session is null) throw new NullReferenceException($"_session can't be null, call {nameof(LoadModel)} method to instantiate it");
                return _session;
            }

            set
            {
                _session = value;
            }
        }

        public void AddSystemMessage(string message) => Session.AddSystemMessage(message);
        public void AddAssistantMessage(string message) => Session.AddAssistantMessage(message);
        public void AddUserMessage(string message) => Session.AddUserMessage(message);

        public bool LoadModel(string appPackagePath, uint contextSize = 30000)
        {
            try
            {
                var modelPath = Path.Combine(FileSystem.Current.AppDataDirectory, appPackagePath);

                var parameters = new ModelParams(modelPath)
                {
                    ContextSize = contextSize,
                    GpuLayerCount = 5,
                };

                var model = LLamaWeights.LoadFromFile(parameters);
                var context = model.CreateContext(parameters);
                var executor = new InteractiveExecutor(context);

                ChatHistory chatHistory = new ChatHistory();
                Session = new ChatSession(executor, chatHistory);

                Debug.WriteLine($"Model succesfully loaded");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading model: {ex.Message}");
                return false;
            }
        }

        public async IAsyncEnumerable<string> ChatAsync(string input)
        {
            await foreach (var text in Session.ChatAsync(new ChatHistory.Message(AuthorRole.User, input), defaultIferenceParams))
            {
                yield return text;
            }
        }
    }
}
