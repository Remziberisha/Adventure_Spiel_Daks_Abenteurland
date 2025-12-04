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
        public Dictionary<string, Ort> Nachbarn;

        public Ort (string name, string[] asciiArt, string beschreibung)
        {
            Name = name;
            AsciArt = asciiArt;
            Beschreibung = beschreibung;
            Nachbarn = new Dictionary<string, Ort>();

        }

        public void ZeigOrt()
        {
            foreach (string s in AsciArt)
                Console.WriteLine(s);
            Console.WriteLine($"\n{Beschreibung}");
        }
        public void FügeNachbarHinzu(string richtung, Ort ort)
        {
            Nachbarn[richtung] = ort;
        }
    }
}
