using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMuseo.Logic.Services
{
    internal interface ISchedaOperaDataProvider
    {
        public string GetSchedaOperaData(string nomeOpera);
    }
}
