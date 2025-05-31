using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMuseo.Logic.Services
{
    public interface ILLamaCpp
    {
        public bool LoadModel(string appPackagePath, uint contextSize = 8000);
        public IAsyncEnumerable<string> ChatAsync(string input);
        public void AddSystemMessage(string message);
        public void AddAssistantMessage(string message);
        public void AddUserMessage(string message);
    }
}
