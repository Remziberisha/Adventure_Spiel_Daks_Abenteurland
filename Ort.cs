

namespace Adventure_Spiel_RemziBerisha
{
    public class Ort
    {


        public string Name;
        public string[] AsciArt;
        public string Beschreibung;
        public Dictionary<string, Ort> Nachbarn;

        public Ort(string name, string[] asciiArt, string beschreibung)
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

        /*  Navigation (Karte)
       *            WAlD
       *          /      \
       *  HAUS <          TAl-------Vulkan 
       *          \      /
       *            BERG
       */

        public static Ort HausAmAmselhof;
        public static Ort Fluesterwald;
        public static Ort Steinhornberge;
        public static Ort Nebeltal;
        public static Ort VulkanAschenturm;

        static Ort()
        {
            HausAmAmselhof = new Ort("Haus am Amselhof", new string[]
            {@"HAUS            
                               Wald
                             /       \            
                  (DAK)Haus<           >Tal-------Vulkan 
                             \       /
                               Berge "},
                "Dak lebt hier mit seiner Familie. Ein böser Schwan hat seinen Bruder entführt."
            );

            Fluesterwald = new Ort("Flüsterwald", new string[]
            {@"WALD
                         (DAK) Wald
                             /       \            
                       Haus<           >Tal-------Vulkan 
                             \       /
                               Berge "},
                "Ein dichter Wald voller Geheimnisse und merkwürdiger Geräusche."
            );

            Steinhornberge = new Ort("Steinhornberge", new string[]
            {@"BERG
                               Wald
                             /       \            
                       Haus<           >Tal-------Vulkan 
                             \       /
                          (DAK)Berge "},
                "Hohe, felsige Berge, die Dak überwinden muss."
            );

            Nebeltal = new Ort("Nebeltal", new string[]
            {@"TAL             
                               Wald
                             /       \            
                       Haus<           >(DAK)Tal-------Vulkan 
                             \       /
                               Berge "},
                "Ein nebliges Tal, in dem die Sicht eingeschränkt ist."
            );

            VulkanAschenturm = new Ort("Vulkan Aschenturm", new string[]
            {@"VULKAN
                               Wald
                             /       \            
                       Haus<           >Tal-------(DAK)Vulkan 
                             \       /
                               Berge "},
                "Am Fuß des Vulkans wird Dak seinen Bruder finden müssen."
            );


            HausAmAmselhof.FügeNachbarHinzu("WALD", Fluesterwald);
            HausAmAmselhof.FügeNachbarHinzu("BERG", Steinhornberge);

            Fluesterwald.FügeNachbarHinzu("TAL", Nebeltal);
            Fluesterwald.FügeNachbarHinzu("HAUS", HausAmAmselhof);

            Steinhornberge.FügeNachbarHinzu("TAL", Nebeltal);
            Steinhornberge.FügeNachbarHinzu("HAUS", HausAmAmselhof);

            Nebeltal.FügeNachbarHinzu("VULKAN", VulkanAschenturm);
            Nebeltal.FügeNachbarHinzu("BERG", Steinhornberge);
            Nebeltal.FügeNachbarHinzu("Wald", Fluesterwald);

            VulkanAschenturm.FügeNachbarHinzu("TAL", Nebeltal);
        }

        public void ZeigOrt()
        {
            foreach (string s in AsciArt)
                Console.WriteLine(s);
            Console.WriteLine($"\n{Beschreibung}");
        }
    }
}
