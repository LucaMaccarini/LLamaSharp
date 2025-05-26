using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMuseo.Logic
{
    internal class Test : ITest
    {
        private string str = "a";
        public Test() { this.str = "str"; }
        public string a()
        {
            return str;
        }
    }
}
