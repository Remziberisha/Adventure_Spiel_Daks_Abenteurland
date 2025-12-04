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

       
        public void FügeNachbarHinzu(string richtung, Ort ort)
        {
            Nachbarn[richtung] = ort;
        }


        public static Ort HausAmAmselhof;
        public static Ort Fluesterwald;
        public static Ort Steinhornberge;
        public static Ort Nebeltal;
        public static Ort VulkanAschenturm;

        static Ort()
        {
            HausAmAmselhof = new Ort("Haus am Amselhof",new string[] {"HAUS"},
                "Dak lebt hier mit seiner Familie. Ein böser Schwan hat seinen Bruder entführt."
            );

            Fluesterwald = new Ort("Flüsterwald", new string[] {"WALD"},
                "Ein dichter Wald voller Geheimnisse und merkwürdiger Geräusche."
            );

            Steinhornberge = new Ort("Steinhornberge", new string[] { "BERG" },
                "Hohe, felsige Berge, die Dak überwinden muss."
            );

            Nebeltal = new Ort("Nebeltal", new string[] {"TAL"},
                "Ein nebliges Tal, in dem die Sicht eingeschränkt ist."
            );

            VulkanAschenturm = new Ort("Vulkan Aschenturm", new string[] {"VULKAN"},
                "Am Fuß des Vulkans wird Dak seinen Bruder finden müssen."
            );
        
            
            HausAmAmselhof.FügeNachbarHinzu("Wald", Fluesterwald);
            HausAmAmselhof.FügeNachbarHinzu("Berd", Steinhornberge);

            Fluesterwald.FügeNachbarHinzu("Tal", Nebeltal);
            Fluesterwald.FügeNachbarHinzu("Haus", HausAmAmselhof);

            Steinhornberge.FügeNachbarHinzu("Tal", Nebeltal);
            Steinhornberge.FügeNachbarHinzu("Haus", HausAmAmselhof);

            Nebeltal.FügeNachbarHinzu("Vulkan", VulkanAschenturm);
            Nebeltal.FügeNachbarHinzu("Berge", Steinhornberge);
            Nebeltal.FügeNachbarHinzu("Wald", Fluesterwald);

            VulkanAschenturm.FügeNachbarHinzu("Tal", Nebeltal);





        }

        public void ZeigOrt()
        {
            foreach (string s in AsciArt)
                Console.WriteLine(s);
            Console.WriteLine($"\n{Beschreibung}");
        }
    }
}
