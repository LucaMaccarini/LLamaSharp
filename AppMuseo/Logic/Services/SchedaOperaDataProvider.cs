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
                  "title": "Starry Night",
                  "author": "Vincent van Gogh",
                  "creation_date": "1889",
                  "technique": "Oil on canvas",
                  "dimensions": {
                    "height_cm": 73.7,
                    "width_cm": 92.1
                  },
                  "location": {
                    "museum_name": "Museum of Modern Art (MoMA)",
                    "city": "New York",
                    "country": "United States",
                    "gallery_room": "Floor 5, Gallery 501"
                  },
                  "description": "A swirling night sky over a small town, full of emotion and vibrant color. The sky dominates the composition with turbulent energy, featuring a bright crescent moon and glowing stars, while a peaceful village lies below. A large, dark cypress tree rises in the foreground, connecting earth and sky.",
                  "artistic_style": "Post-Impressionism",
                  "subject": {
                    "name": "Night sky",
                    "description": "Expresses van Gogh's emotional state through vivid stars and swirling patterns. The scene, while based on real elements, is a blend of memory, imagination, and symbolism."
                  },
                  "historical_context": "Painted during Van Gogh's stay at the Saint-Paul-de-Mausole asylum in Saint-Rémy-de-Provence, France. Despite being in a period of mental turmoil, he produced some of his most iconic works during this time.",
                  "influences": [
                    "Japanese woodblock prints",
                    "Religious symbolism",
                    "Astronomical observation"
                  ],
                  "symbolism": {
                    "cypress_tree": "Traditionally associated with death and eternity, it links the terrestrial and celestial realms.",
                    "village": "Possibly imagined, representing peace and human presence under a vast, chaotic sky.",
                    "stars": "Enhanced and exaggerated, symbolizing hope, wonder, and possibly divine presence."
                  },
                  "materials_used": [
                    "Oil paints",
                    "Primed canvas",
                    "Pigments including ultramarine, cobalt blue, and chrome yellow"
                  ],
                  "notable_features": [
                    "Dramatic brushstrokes and impasto technique",
                    "Unrealistic but expressive use of color",
                    "Rhythmic, swirling sky patterns",
                    "Contrast between motion in the sky and stillness in the village"
                  ],
                  "related_works": [
                    "Café Terrace at Night (1888)",
                    "The Starry Night Over the Rhône (1888)",
                    "Wheatfield with Cypresses (1889)"
                  ]
                }
                
                """;
        }
    }
}
