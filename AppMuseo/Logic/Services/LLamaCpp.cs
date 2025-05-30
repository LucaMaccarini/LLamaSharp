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

        public void AddAndProcessSystemMessage(string message) => Session.AddAndProcessSystemMessage(message);
        public void AddAndProcessAssistantMessage(string message) => Session.AddAndProcessAssistantMessage(message);
        public void AddAndProcessUserMessage(string message) => Session.AddAndProcessUserMessage(message);

        static InferenceParams defaultIferenceParams = new InferenceParams()
        {
            MaxTokens = 5000,
            AntiPrompts = new List<string> { "User:" }, 
            SamplingPipeline = new DefaultSamplingPipeline(),
        };

        public void LoadModel(string appPackagePath, uint contextSize=8000)
        {
            var modelPath = Path.Combine(FileSystem.Current.AppDataDirectory, appPackagePath);

            var parameters = new ModelParams(modelPath)
            {
                ContextSize = contextSize
            };

            var model = LLamaWeights.LoadFromFile(parameters);
            var context = model.CreateContext(parameters);
            var executor = new InteractiveExecutor(context);

            ChatHistory chatHistory = new ChatHistory();

            Session = new ChatSession(executor, chatHistory);

            Debug.WriteLine($"Model succesfully loaded");
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
