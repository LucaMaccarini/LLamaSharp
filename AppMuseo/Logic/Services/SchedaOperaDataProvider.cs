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
                  {
                  "title": "Mona Lisa",
                  "alternative_title": "La Gioconda",
                  "author": "Leonardo da Vinci",
                  "creation_date": "1503-1506",
                  "technique": "Oil on poplar panel",
                  "dimensions": {
                    "height_cm": 77,
                    "width_cm": 53
                  },
                  "location": {
                    "museum_name": "Louvre Museum",
                    "city": "Paris",
                    "country": "France"
                  },
                  "description": "The Mona Lisa is one of the most famous paintings in the world. It depicts a seated woman with a serene expression and an enigmatic smile. The background landscape is hazy and unreal, achieved using the 'sfumato' technique, which Leonardo perfected to make transitions between light and shadow appear more natural.",
                  "artistic_style": "Renaissance",
                  "subject": {
                    "name": "Lisa Gherardini",
                    "description": "It is believed that the woman portrayed is Lisa Gherardini, wife of the Florentine merchant Francesco del Giocondo, from whom the alternative name 'La Gioconda' is derived."
                  },
                  "curiosities": [
                    "The Mona Lisa's smile is considered one of the most mysterious in art history.",
                    "The painting was stolen in 1911 and recovered two years later in Italy.",
                    "It is protected by bulletproof glass at the Louvre and is seen by millions of visitors each year.",
                    "The background landscape is not real, but a product of Leonardo's imagination."
                  ],
                  "technical_notes": "Leonardo used 'sfumato' to create a soft and realistic effect. There are no sharp outlines, and light gently models the volumes. The figure's gaze also appears to follow the viewer from any angle.",
                  "emotions_conveyed": [
                    "Mystery",
                    "Tranquility",
                    "Elegance",
                    "Psychological depth"
                  ]
                }
                
                """;
        }
    }
}
