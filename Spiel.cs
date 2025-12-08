
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
            }
            NavigationSystem.Navigation(Ort.HausAmAmselhof);
            if (aktuellerOrt == Ort.Fluesterwald)
            {
                Console.WriteLine("Oh oh - ein hungriger Fuchs lauert");
            }

        }
        public static void Pause()
        {
            Console.WriteLine("\nDrücke ENTER, um fortzufahren...");
            Console.ReadLine();
        }
    }
}
