
using System.Runtime.CompilerServices;
using Adventure_spiel_RemziBerisha;

namespace Adventure_Spiel_RemziBerisha
{
    internal class Spiel
    {

        private Ort aktuellerOrt;
        private int dakHP = 50;
        private int dakSchaden = 12;
        private List<string> inventory = new();
        private bool garryBesiegt = false;
        private bool hangmanFertig = false;
        private bool fuchsBesiegt = false;
        private const string SAVEFILE = "dak_save.json";

        public void Start()
        {
            aktuellerOrt = Ort.HausAmAmselhof;
            Console.WriteLine("Willkomen bei Dak's Abenteuerland");
            Console.WriteLine("Gib dein Namen ein:");

            string name = Console.ReadLine()?.Trim() ?? "";
            Console.WriteLine($"Hallo {name}");
            if (aktuellerOrt == Ort.HausAmAmselhof && !hangmanFertig)
            {
                hangmanFertig = Hangman.hausAmAmselhof();
                if (!hangmanFertig)
                {
                    Console.WriteLine("Leider geht die Tür nicht versuche es später nochmal!");
                    return;
                }
            }
            SpielSchleife();
        }
       
        
        private void SpielSchleife()
            {
            bool spielLauft = true;
            while (spielLauft)
            {
                Console.Clear();
                aktuellerOrt.ZeigOrt();
                ZeigStatus();
                Console.WriteLine("\nMögliche Richtungen");
                foreach (var n in aktuellerOrt.Nachbarn)
                    Console.WriteLine($"-{n.Key}");
                Console.WriteLine("\nEingabe (Richtung, Status, Quitt): ");
                string eingabe = Console.ReadLine()?.Trim().ToUpper() ?? "";

                if (eingabe == "STATUS")
                {
                    ZeigStatus();
                    Pause();
                }
                else if (eingabe =="QUIT")
                {
                    Console.WriteLine("Spiel wird beendet...");
                    spielLauft = false;
                }
                else if (aktuellerOrt.Nachbarn.ContainsKey(eingabe))
                {
                    aktuellerOrt =  aktuellerOrt.Nachbarn[eingabe];
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Dak geht nach {aktuellerOrt.Name}");
                    Console.ResetColor();
                    Pause();
                    OrtEvent();
                }
                else
                {
                    Console.WriteLine("Diese Richtung gibt es nicht!");
                    Pause();
                }

                if (dakHP <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGAME OVER");
                    Console.ResetColor();
                    spielLauft = false;
                }
                if (garryBesiegt)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nHERZLICHEN GLUECKWUNSCH!");
                    Console.WriteLine("Du hast das Spiel gewonnen!");
                    Console.WriteLine("\nDu hast Bert gerettet!");
                    Console.ResetColor();
                    spielLauft = false;
                }
             }
        }
        private void OrtEvent()
        {
            if (aktuellerOrt == Ort.Fluesterwald && !fuchsBesiegt)

            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Oh -ein Hungriger Fuchs lauert");
                Console.ResetColor();
                Pause();
                Console.Clear();
                Combat combat = new Combat("Fuchs", 32, 8);
                bool kampfGewonen = combat.Start(ref dakHP, dakSchaden);
                if (kampfGewonen && dakHP >0)
                {
                    fuchsBesiegt = true;
                    Console.WriteLine("\nNach dem Kampf findest du ein kleines Federchen im Gras.");
                    inventory.Add("Federchen");
                    dakSchaden += 3;
                    Console.WriteLine("Dak's angriff steigt +3 .");
                }
                Pause();

            }
            if (aktuellerOrt ==Ort.VulkanAschenturm && !garryBesiegt)
            {
                Console.WriteLine("\nDie Hitze ist unerträglich");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nGarry der boese Schwan erscheint!");
                Console.ResetColor();
                Pause();
                Combat combat = new Combat ("Garry", 70, 11);
                bool kampfGewonen = combat.Start(ref dakHP, dakSchaden);

                if (kampfGewonen && dakHP>0)
                {
                    garryBesiegt = true;
                    Console.WriteLine("\nGarry sinkt zu Boden...");
                    Pause();
                    Console.WriteLine("Bert watschelt aus der Hoele heraus !");
                    Console.WriteLine("Du hast bert gerettet");
                    Pause();


                }
                else
                {
                    Console.WriteLine("Du wurdest besiegt ...");
                    Pause();

                }
            }
        }
        public static void Pause()
        {
            Console.WriteLine("\nDrücke ENTER, um fortzufahren...");
            Console.ReadLine();
        }
        private void ZeigStatus()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nHP: {dakHP}  |  Schaden: {dakSchaden}  |  Items: {inventory.Count}");
            Console.ResetColor();
        }
    }
}
