using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adventure_Spiel_Remzi
{
    internal class Spiel
    {
        private Ort aktuellerOrt;
        
        public void Start()
        {
            aktuellerOrt = Ort.HausAmAmselhof;
            Console.WriteLine("Willkomen bei Dak's Abenteuerland");
            Console.WriteLine("Gib dein Namen ein:");

            string name = Console.ReadLine();
            Console.WriteLine($"Hallo {name}");
            Hangman.hausAmAmselhof();

            Hangman.Navigation(Ort.HausAmAmselhof);
        }
    }
}

