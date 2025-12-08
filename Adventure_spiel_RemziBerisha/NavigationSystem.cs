using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Spiel_RemziBerisha
{
    public static class NavigationSystem
    {
        public static void Navigation(Ort aktuellerOrt)
        {
            while (true)
            {
                Console.Clear();
                aktuellerOrt.ZeigOrt();
                Console.WriteLine("\nMögliche Richtungen:");

                foreach (var n in aktuellerOrt.Nachbarn)
                    Console.WriteLine($"- {n.Key}");

                Console.Write("\nWohin möchtest du gehen? ");
                string richtung = Console.ReadLine().ToUpper();

                if (aktuellerOrt.Nachbarn.ContainsKey(richtung))
                {
                    aktuellerOrt = aktuellerOrt.Nachbarn[richtung];
                }
                else
                {
                    Console.WriteLine("Diese Richtung gibt es nicht!");
                    Console.WriteLine("Drücke ENTER, um es erneut zu versuchen...");
                    Console.ReadLine();
                }
            }
        }
    }
}
