using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Spiel_Remzi
{
    internal class Spiel
    {
        public void Start()
        {
            Console.WriteLine("Willkomen bei Ruber Ranger");
            Console.WriteLine("gib dein Namen ein:");

            string name = Console.ReadLine();
            Console.WriteLine($"Hallo {name}");
            ersterKapitel();
        }
        private void ersterKapitel()
        {
            Console.WriteLine("Dak ist eine Gummiente, die mit ihrer Familie am Fluss lebt." +
                " Sein Bruder Bert wurde von einem bösen Schwan namens Gary entführt und am Fuß eines Vulkans gefangen gehalten." +
                " Jetzt muss Dak den Schwan finden, um seinen Bruder zu befreien. Dafür muss er entweder durch den Wald oder durch " +
                "die Berge und über das Tal bis zum Vulkan reisen.?");
            Console.WriteLine("1 - Wald");
            Console.WriteLine("2 - Berge");

            string eingabe = Console.ReadLine();

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
                Console.WriteLine("Ungültige Eingabe.");
                ersterKapitel();
            }
        }
    }
}
