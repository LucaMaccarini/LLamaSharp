using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMuseo.Logic.Services
{
    internal class SchedaOperaDataProvider : ISchedaOperaDataProvider
    {
        public string GetSchedaOperaData(string nomeOpera)
        {
            return """
                 {"title":"Starry Night","author":"Vincent van Gogh","creation_date":"1889","technique":"Oil on canvas","location":{"museum_name":"MoMA","city":"New York"},"description":"A swirling night sky over a small town, full of emotion and vibrant color.","artistic_style":"Post-Impressionism","subject":{"name":"Night sky","description":"Expresses van Gogh's emotional state through vivid stars and swirling patterns."}}
                
                """;
        }
    }
}
