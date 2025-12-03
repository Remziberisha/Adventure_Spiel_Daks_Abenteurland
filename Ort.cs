using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Spiel_Remzi
{
    public class Ort
    {


        public string Name;
        public string[] AsciArt;
        public string Beschreibung;

        public Ort (string name, string[] asciiArt, string beschreibung)
        {
            Name = name;
            AsciArt = asciiArt;
            Beschreibung = beschreibung;
        }

        public void ZeigOrt()
        {
            foreach (string s in AsciArt)
                Console.WriteLine(s);
            Console.WriteLine($"\n{Beschreibung}");
        }
    }
}
