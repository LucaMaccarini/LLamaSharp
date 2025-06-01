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
                  "artwork": {
                    "title": "The Starry Night",
                    "original_title": "The Starry Night",
                    "artist": {
                      "name": "Vincent van Gogh",
                      "nationality": "Dutch",
                      "lifespan": "1853-1890",
                      "art_movement": "Post-Impressionism",
                      "brief_biography": "Vincent van Gogh was a Dutch painter known for his unique style and intense emotional expression. Despite his short and troubled life, he profoundly influenced modern painting."
                    },
                    "year_created": 1889,
                    "technique": {
                      "type": "Oil on canvas",
                      "dimensions": {
                        "height_cm": 73.7,
                        "width_cm": 92.1
                      },
                      "place_created": "Saint-Rémy-de-Provence, France",
                      "materials": "Oil paints on linen canvas",
                      "painting_techniques": {
                        "brushstrokes": "Thick, dynamic brushstrokes, sometimes spiral-shaped, creating movement in the composition",
                        "color_palette": "Palette dominated by blues, intense yellows, greens, and blacks, with strong contrasts between warm and cool colors",
                        "impasto": "Frequent use of impasto (very thick brushstrokes) to add texture and relief to the surface"
                      }
                    },
                    "historical_context": {
                      "period": "Late 19th century, Post-Impressionist period",
                      "location": "Psychiatric hospital in Saint-Rémy, where Van Gogh was being treated after a nervous breakdown",
                      "influences": [
                        "Influence from Impressionist and Japanese painting",
                        "Interest in representing emotional aspects of landscape more than realistic precision"
                      ]
                    },
                    "visual_description": {
                      "composition": "Night scene of a village under a vivid and dynamic starry sky",
                      "main_elements": {
                        "sky": {
                          "features": [
                            "Night sky with swirling and spiral patterns of light",
                            "Large, bright yellow stars scattered throughout",
                            "Bright yellow crescent moon, stylized",
                            "Swirling patterns suggesting movement in the air"
                          ],
                          "colors": [
                            "Deep blue",
                            "Azure blue",
                            "Golden yellow",
                            "White highlights around stars and light sources"
                          ]
                        },
                        "landscape": {
                          "village": {
                            "houses": "Simplified, stylized houses with pointed roofs in cool earthy tones",
                            "church": "A church with a prominent central steeple stands out in the village",
                            "hills": "Gently rolling hills in the background",
                            "streets": "Narrow, simple streets between houses"
                          },
                          "cypress_tree": {
                            "position": "In the foreground on the left side",
                            "description": "Tall, dark tree resembling a flame reaching toward the sky",
                            "function": "Serves as a vertical link between the earth and sky, contrasting with the soft landscape shapes"
                          }
                        }
                      }
                    },
                    "evoked_emotions": {
                      "description": "The artwork conveys a sense of movement and life within the silence of the night, blending feelings of unease and wonder.",
                      "objective_psychological_aspects": [
                        "The dynamic sky suggests energy and turbulence",
                        "The calm village appears as a peaceful refuge",
                        "The cypress tree creates a vertical tension breaking the horizontal lines"
                      ]
                    },
                    "curiosities": {
                      "original_title_misnomer": "Van Gogh originally titled the painting 'View from the Asylum Window at Saint-Rémy,' not 'The Starry Night.'",
                      "current_location": "The painting is housed at the Museum of Modern Art (MoMA) in New York City.",
                      "creation_context": "Van Gogh painted the artwork during a period of hospitalization and emotional instability.",
                      "artist_reflections": "Van Gogh wrote in letters to his brother Theo about his fascination with the night sky, although he never saw this exact scene firsthand.",
                      "astronomical_research": "Recent studies have shown that the stars and moon in the painting correspond to an actual astronomical configuration visible from Saint-Rémy on June 19, 1889."
                    },
                    "cultural_impact": {
                      "artistic_influence": [
                        "Considered one of the most iconic works of Post-Impressionism and modern art",
                        "Influenced artists such as Pablo Picasso and many others",
                        "Subject of numerous tributes, parodies, and reinterpretations in contemporary art"
                      ],
                      "media_presence": [
                        "The image has become a pop culture icon",
                        "Featured in films, advertisements, music albums, and merchandise"
                      ],
                      "major_exhibitions": [
                        "Permanent exhibition at MoMA in New York City",
                        "Numerous temporary exhibitions dedicated to Van Gogh worldwide"
                      ]
                    }
                  }
                }                
                
                """;
        }

        public string GetSmallSchedaOperaData(string nomeOpera)
        {
            return """
                 {
                  "artwork": {
                    "title": "The Starry Night",
                    "artist": {
                      "name": "Vincent van Gogh",
                      "nationality": "Dutch",
                      "art_movement": "Post-Impressionism"
                    },
                    "year_created": 1889,
                    "technique": {
                      "type": "Oil on canvas",
                      "dimensions_cm": {
                        "height": 73.7,
                        "width": 92.1
                      }
                    },
                    "visual_description": {
                      "sky": {
                        "features": [
                          "Swirling patterns of light",
                          "Bright yellow stars",
                          "Crescent moon"
                        ],
                        "colors": ["Blue", "Yellow", "White"]
                      },
                      "landscape": {
                        "village": "Stylized houses and church",
                        "cypress_tree": "Tall dark tree in foreground"
                      }
                    },
                    "curiosities": {
                      "original_title": "'View from the Asylum Window at Saint-Rémy'",
                      "location": "Museum of Modern Art, New York"
                    }
                  }
                }
                

                """;
        }

        public string GetReallySmallSchedaOperaData(string nomeOpera)
        {
            return """
                 {
                  "artwork": {
                    "title": "The Starry Night",
                    "artist": {
                      "name": "Vincent van Gogh",
                      "nationality": "Dutch",
                      "art_movement": "Post-Impressionism"
                    },
                    "year_created": 1889,
                    "technique": {
                      "type": "Oil on canvas",
                      "dimensions_cm": {
                        "height": 73.7,
                        "width": 92.1
                      }
                    }
                  }
                }
                

                """;
        }
    }
}
