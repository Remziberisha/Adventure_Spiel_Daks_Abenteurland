using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adventure_Spiel_RemziBerisha
{
   
    internal class Hangman
    {
        public static void hausAmAmselhof()
        {
            Console.WriteLine("Dak ist eine Gummiente," +
                " Sein Bruder Bert wurde von einem bösen Schwan namens Gary entführt und am Fuß eines Vulkans \ngefangen gehalten." +
                " Jetzt muss Dak den Schwan finden, um seinen Bruder zu befreien.");
            Console.WriteLine("\"Drücke ENTER, um fortzufahren\"");
            Console.ReadKey();

            bool gewonnen = false;
            while (!gewonnen)
            {
                Hangman minispiel = new Hangman("TEICH");
                gewonnen = minispiel.Starte();

                if (gewonnen)
                    Console.WriteLine("Dak kann jetzt das huas verlassen !");
                else
                    Console.WriteLine("Dak muss später erneunt versuchen");
                // Hier endet der erste kapitel , entscheidung BERG oder WALD
            }

           
        }
       
        



        private string geheimesWort;
        private int maxVersuche;

        public Hangman(string wort, int versuche = 12)
        {
            geheimesWort = wort.ToUpper();
            maxVersuche = versuche;
        }

        public bool Starte()
        {
            char[] erraten = new char[geheimesWort.Length];
            for (int i = 0; i < erraten.Length; i++)
                erraten[i] = '_';

            List<char> benutzteBuchstaben = new List<char>();
            int versuche = maxVersuche;

            // Ladepunkte
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }

            Console.Clear();
            Console.WriteLine("\nDak will das Haus verlassen, aber die Tür des Zauns ist verriegelt");
            Console.WriteLine("🔒!");
            Console.WriteLine("Um den Zaun zu öffnen, musst du das geheime Passwort erraten.");
            Console.WriteLine("Du kannst Buchstabe für Buchstabe eingeben oder direkt das ganze Wort.");
            Console.WriteLine($"Du hast {maxVersuche} Versuche.\n");

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

                // Wort eingeben
                if (input.Length > 1)
                {
                    if (input == geheimesWort)
                    {
                        Console.Clear();
                        Console.WriteLine("🎉 Du hast das Passwort korrekt eingegeben!");
                        Console.WriteLine("🔓 Die Tür öffnet sich.");
                        return true;
                    }
                    else
                    {
                        versuche--;
                        Console.WriteLine("\n❌ Falsch! Das Wort ist nicht korrekt.");
                    }
                }
                else // Einzelner Buchstabe
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
                            if (geheimesWort[i] == buchstabe)
                                erraten[i] = buchstabe;

                        if (!erraten.Contains('_'))
                        {
                            Console.Clear();
                            Console.WriteLine("🎉 Du hast das Passwort geknackt!");
                            Console.WriteLine("🔓 Die Tür öffnet sich.");
                            return true;
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
            return false;
        }
    }
}

