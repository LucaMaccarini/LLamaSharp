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

        public string GetSchedaOperaDataIT(string nomeOpera)
        {
            return """
                {
                  "opera_d_arte": {
                    "titolo": "La notte stellata",
                    "titolo_originale": "The Starry Night",
                    "artista": {
                      "nome": "Vincent van Gogh",
                      "nazionalità": "Olandese",
                      "periodo_vita": "1853-1890",
                      "movimento_artistico": "Post-Impressionismo",
                      "breve_biografia": "Vincent van Gogh è stato un pittore olandese noto per il suo stile unico e l'intensa espressione emotiva. Nonostante la sua vita breve e travagliata, ha influenzato profondamente la pittura moderna."
                    },
                    "anno_creazione": 1889,
                    "tecnica": {
                      "tipo": "Olio su tela",
                      "dimensioni": {
                        "altezza_cm": 73.7,
                        "larghezza_cm": 92.1
                      },
                      "luogo_creazione": "Saint-Rémy-de-Provence, Francia",
                      "materiali": "Colori ad olio su tela di lino",
                      "tecniche_pittoriche": {
                        "pennellate": "Pennellate spesse e dinamiche, talvolta a spirale, che creano movimento nella composizione",
                        "palette_cromatica": "Palette dominata da blu, gialli intensi, verdi e neri, con forti contrasti tra colori caldi e freddi",
                        "impasto": "Uso frequente dell’impasto (pennellate molto spesse) per aggiungere texture e rilievo alla superficie"
                      }
                    },
                    "contesto_storico": {
                      "periodo": "Fine XIX secolo, periodo post-impressionista",
                      "luogo": "Ospedale psichiatrico di Saint-Rémy, dove Van Gogh era in cura dopo un crollo nervoso",
                      "influenze": [
                        "Influenza della pittura impressionista e giapponese",
                        "Interesse per la rappresentazione degli aspetti emotivi del paesaggio più che per la precisione realistica"
                      ]
                    },
                    "descrizione_visiva": {
                      "composizione": "Scena notturna di un villaggio sotto un cielo stellato vivido e dinamico",
                      "elementi_principali": {
                        "cielo": {
                          "caratteristiche": [
                            "Cielo notturno con motivi di luce vorticosi e a spirale",
                            "Grandi stelle gialle e brillanti sparse ovunque",
                            "Luna a mezzaluna gialla brillante, stilizzata",
                            "Motivi vorticosi che suggeriscono movimento nell’aria"
                          ],
                          "colori": [
                            "Blu profondo",
                            "Azzurro",
                            "Giallo dorato",
                            "Riflessi bianchi attorno alle stelle e alle fonti luminose"
                          ]
                        },
                        "paesaggio": {
                          "villaggio": {
                            "case": "Case semplificate e stilizzate con tetti a punta in toni terrosi freddi",
                            "chiesa": "Una chiesa con un campanile centrale prominente si distingue nel villaggio",
                            "colline": "Dolci colline ondulate sullo sfondo",
                            "strade": "Stradine strette e semplici tra le case"
                          },
                          "cipresso": {
                            "posizione": "In primo piano sul lato sinistro",
                            "descrizione": "Albero alto e scuro simile a una fiamma che si protende verso il cielo",
                            "funzione": "Funziona come collegamento verticale tra terra e cielo, in contrasto con le forme morbide del paesaggio"
                          }
                        }
                      }
                    },
                    "emozioni_evocate": {
                      "descrizione": "L’opera trasmette un senso di movimento e vita nel silenzio della notte, fondendo sensazioni di inquietudine e meraviglia.",
                      "aspetti_psicologici_oggettivi": [
                        "Il cielo dinamico suggerisce energia e turbolenza",
                        "Il villaggio calmo appare come un rifugio pacifico",
                        "Il cipresso crea una tensione verticale che rompe le linee orizzontali"
                      ]
                    },
                    "curiosità": {
                      "titolo_originale_errato": "Van Gogh inizialmente intitolò il dipinto 'Vista dalla finestra dell’asilo a Saint-Rémy', non 'La notte stellata'.",
                      "posizione_attuale": "Il dipinto è conservato al Museum of Modern Art (MoMA) di New York.",
                      "contesto_creazione": "Van Gogh realizzò l’opera durante un periodo di ricovero e instabilità emotiva.",
                      "riflessioni_artista": "Van Gogh scrisse nelle lettere al fratello Theo del suo fascino per il cielo notturno, anche se non vide mai direttamente questa scena.",
                      "ricerche_astronomiche": "Studi recenti hanno mostrato che le stelle e la luna nel dipinto corrispondono a una configurazione astronomica reale visibile da Saint-Rémy il 19 giugno 1889."
                    },
                    "impatto_culturale": {
                      "influenza_artistica": [
                        "Considerata una delle opere più iconiche del Post-Impressionismo e dell’arte moderna",
                        "Ha influenzato artisti come Pablo Picasso e molti altri",
                        "Oggetto di numerosi omaggi, parodie e reinterpretazioni nell’arte contemporanea"
                      ],
                      "presenza_mediatica": [
                        "L’immagine è diventata un’icona della cultura pop",
                        "Apparsa in film, pubblicità, album musicali e merchandising"
                      ],
                      "principali_mostre": [
                        "Esposizione permanente al MoMA di New York",
                        "Numerose mostre temporanee dedicate a Van Gogh in tutto il mondo"
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

    }
}
