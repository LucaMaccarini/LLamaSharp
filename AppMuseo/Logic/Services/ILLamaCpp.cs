using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMuseo.Logic.Services
{
    public interface ILLamaCpp
    {
        public void LoadModel(string appPackagePath, uint contextSize = 8000);
        public IAsyncEnumerable<string> ChatAsync(string input);
        public void AddAndProcessSystemMessage(string message);
        public void AddAndProcessAssistantMessage(string message);
        public void AddAndProcessUserMessage(string message);
    }
}
