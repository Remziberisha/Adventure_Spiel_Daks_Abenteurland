using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Spiel_Remzi
{
    internal class Spiel
    {
        private Ort HausAmAmselhof;
        private Ort Fluesterwald;
        private Ort Steinhornberge;
        private Ort Nebeltal;
        private Ort VulkanAschenturm;

        public Spiel()
        {
            HausAmAmselhof = new Ort(
                "Haus am Amselhof",
                new string[] {
                "  _____  ",
                " /     \\ ",
                "|  _ _  |",
                "| |   | |",
                "|_|___|_|"
                },
                "Dak lebt hier mit seiner Familie. Ein böser Schwan hat seinen Bruder entführt."
            );

            Fluesterwald = new Ort(
                "Flüsterwald",
                new string[] {
                "   &&& &&  & &&",
                "&& &\\/&\\|& ()|/ @, &&",
                " &\\/(/&/&||/& /_/)_&/_&"
                },
                "Ein dichter Wald voller Geheimnisse und merkwürdiger Geräusche."
            );

            Steinhornberge = new Ort(
                "Steinhornberge",
                new string[] {
                "   /\\",
                "  /  \\    /\\",
                " /    \\  /  \\"
                },
                "Hohe, felsige Berge, die Dak überwinden muss."
            );

            Nebeltal = new Ort(
                "Nebeltal",
                new string[] {
                " ~~~ ~~~~ ~~~",
                "~  ~  ~  ~  ~"
                },
                "Ein nebliges Tal, in dem die Sicht eingeschränkt ist."
            );

            VulkanAschenturm = new Ort(
                "Vulkan Aschenturm",
                new string[] {
                "   /\\",
                "  /  \\",
                " /    \\",
                "/      \\",
                "--------"
                },
                "Am Fuß des Vulkans wird Dak seinen Bruder finden müssen."
            );
        }



        public void Start()
        {
            Console.WriteLine("Willkomen bei Dak's Abenteuerland");
            Console.WriteLine("Gib dein Namen ein:");

            string name = Console.ReadLine();
            Console.WriteLine($"Hallo {name}");
            hausAmAmselhof();
        }
        private void hausAmAmselhof()
        {
            
            Console.WriteLine("Dak ist eine Gummiente," +
                " Sein Bruder Bert wurde von einem bösen Schwan namens Gary entführt und am Fuß eines Vulkans \ngefangen gehalten." +
                " Jetzt muss Dak den Schwan finden, um seinen Bruder zu befreien.");
            Console.WriteLine("\"Drücke ENTER, um fortzufahren\"");
            Console.ReadKey();
            
            
            PasswortMinispiel();
        }
        public static void PasswortMinispiel()
        {
            string geheimesWort = "TEICH";  // Das Passwort
            char[] erraten = new char[geheimesWort.Length];
            for (int i = 0; i < erraten.Length; i++)
                erraten[i] = '_';

            int versuche = 12;
            List<char> benutzteBuchstaben = new List<char>();

            Console.Clear();
            Console.WriteLine("Dak will das Haus verlassen, aber die Tür des Zauns ist verriegelt");
            Console.WriteLine("🔒!");
            Console.WriteLine("Um den Zaun zu öffnen, musst du das geheime Passwort erraten.");
            Console.WriteLine("Du kannst Buchstabe für Buchstabe eingeben oder direkt das ganze Wort.");
            Console.WriteLine("Du hast 12 Versuche.\n");

            while (versuche > 0)
            {
                Console.WriteLine("Passwort: " + string.Join(" ", erraten));
                Console.WriteLine("Benutzte Buchstaben: " + string.Join(", ", benutzteBuchstaben));
                Console.WriteLine($"Übrige Versuche: {versuche}");
                Console.Write("\nGib einen Buchstaben oder das ganze Wort ein: ");

                string input = Console.ReadLine().ToUpper().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("\n⚠ Bitte etwas eingeben!");
                    continue;
                }

                // Ganze Wort-Eingabe prüfen
                if (input.Length > 1)
                {
                    if (input == geheimesWort)
                    {
                        Console.Clear();
                        Console.WriteLine("🎉 Du hast das Passwort korrekt eingegeben!");
                        Console.WriteLine("🔓 Die Tür öffnet sich.");
                        return;
                    }
                    else
                    {
                        versuche--;
                        Console.WriteLine("\n❌ Falsch! Das Wort ist nicht korrekt.");
                    }
                }
                else // einzelner Buchstabe
                {
                    char buchstabe = input[0];

                    if (benutzteBuchstaben.Contains(buchstabe))
                    {
                        Console.WriteLine("\n⚠ Diesen Buchstaben hast du schon benutzt!");
                        continue;
                    }

                    benutzteBuchstaben.Add(buchstabe);

                    if (geheimesWort.Contains(buchstabe))
                    {
                        Console.WriteLine("\n✔ Richtiger Buchstabe!");

                        for (int i = 0; i < geheimesWort.Length; i++)
                        {
                            if (geheimesWort[i] == buchstabe)
                            {
                                erraten[i] = buchstabe;
                            }
                        }

                        if (!erraten.Contains('_'))
                        {
                            Console.Clear();
                            Console.WriteLine("🎉 Du hast das Passwort geknackt!");
                            Console.WriteLine("🔓 Die Tür öffnet sich.");
                            return;
                        }
                    }
                    else
                    {
                        versuche--;
                        Console.WriteLine("\n❌ Falsch! Der Buchstabe gehört nicht zum Passwort.");
                    }
                }

                Console.WriteLine("\nDrücke ENTER, um weiterzumachen...");
                Console.ReadLine();
                Console.Clear();
            }

            Console.Clear();
            Console.WriteLine("❌ Du hast alle Versuche verbraucht!");
            Console.WriteLine("Die Tür bleibt verschlossen… Dak muss es später erneut versuchen.\n");
        }



        string eingabe;

        /* do
        {
            Console.WriteLine("Wohin willst du gehen? (1=Wald / 2=Berge)");
            eingabe = Console.ReadLine();

            if (eingabe == "1")
            {
                Console.WriteLine("Du gehst durch den Wald...");
            }
            else if (eingabe == "2")
            {
                Console.WriteLine("Du gehst durch die Berge...");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte erneut versuchen.");
            }

        } while (eingabe != "1" && eingabe != "2");
        */
    
    }
}

