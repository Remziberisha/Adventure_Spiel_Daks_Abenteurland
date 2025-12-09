


using System.Transactions;
using System.Xml.Serialization;

namespace Adventure_spiel_RemziBerisha
{
    public class Combat
    {
        private readonly string enemyName;
        private int enemyHP;
        private readonly int enemyDamage;
        private readonly Random rnd = new();
        private readonly bool isBoss;

        public Combat (string enemyName, int enemyHP, int enemyDamage, bool isBoss = false)
        {
            this.enemyName = enemyName;
            this.enemyHP = enemyHP;
            this.enemyDamage = enemyDamage;
            this.isBoss = isBoss;
        }
        public bool Start(ref int playerHP, int playerDamage)
        {
            Console.WriteLine($"Ein {enemyName} erscheint");

            while (enemyHP > 0 && playerHP > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\nDak: {playerHP} HP  ---|---{enemyName}: {enemyHP} HP");
                Console.ResetColor();
                Console.WriteLine("wähle Aktion: 1=Angreifen 2=Heilen 3=Fliehen");
                Console.WriteLine("Eingabe: ");
                string eingabe = Console.ReadLine()?.Trim() ?? "";

                int fliehen = rnd.Next(0, 2);

                if (eingabe == "1")
                {
                    //Angriff
                    int schaden = playerDamage + rnd.Next(-2, 4);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Dak atackiert und verursacht {schaden} Schaden!");
                    Console.ResetColor();
                    enemyHP-=schaden;

                    if (enemyHP <= 10)
                    {
                        Console.WriteLine("NEIN! Das kann nicht sein");
                    }
                }
                else if (eingabe == "2")
                {
                    int heilt = 15 + rnd.Next(-1, 4);
                    playerHP += heilt;
                    Console.WriteLine($"Dak nutzt einen Heiltrank. + {heilt}");
                }

                else if (eingabe == "3")
                {
                    if (fliehen == 1)
                    {
                        Console.WriteLine("Dak ist geflohen!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Flucht ist gescheitert");
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe.");
                }

                if (enemyHP>0)
                {
                    int schaden = enemyDamage; 
                    playerHP-= schaden;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{enemyName} trifft Dak und verursacht {schaden} Schaden");
                    Console.ResetColor();
                    if (playerHP <= 0) 
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Dak Wurde Besiegt...");
                        Console.ResetColor();  
                        return false;
                    }
                }

            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{enemyName} wurde besiegt!");
            Console.ResetColor();
            
            return playerHP > 0;

          
        }
        
    }
}
