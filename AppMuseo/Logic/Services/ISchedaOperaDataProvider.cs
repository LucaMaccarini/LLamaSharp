using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMuseo.Logic.Services
{
    public interface ISchedaOperaDataProvider
    {
        public string GetSchedaOperaData(string nomeOpera);
        public string GetSmallSchedaOperaData(string nomeOpera);
    }
}
