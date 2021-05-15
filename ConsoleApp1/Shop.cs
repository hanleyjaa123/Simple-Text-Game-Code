using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Shop
    {
         static int armorMod;
         static int  weaponMod;
         static int difMod;

        public static void LoadShop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int stimP;
            int armorP;
            int weaponP;
            int difP;

            while (true)
            {
                stimP = 25 + 10 * p.mods;
                armorP = 100 * (p.armorValue + 1);
                weaponP = 100 * (p.weaponValue );
                difP = 300 + 100 * p.mods;
                Console.Clear();
                Console.WriteLine("============ SHOP =============");
                Console.WriteLine("===============================");
                Console.WriteLine("|        (S)timpacks        |$ " + stimP);
                Console.WriteLine("|          (W)eapons        |$ " + weaponP);
                Console.WriteLine("|          (A)rmor          |$ " + armorP);
                Console.WriteLine("|          (M)od(s)         |$ " + difP);
                Console.WriteLine("===============================");
                Console.WriteLine("|          (E)xit            | ");
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("========= Player Sheet ==========");
                Console.WriteLine("|        Currency                 " + p.Caps);
                Console.WriteLine("|        Current Health " + p.health);
                Console.WriteLine("|        Armor/Player Defense: " + p.armorValue + " |");
                Console.WriteLine("|        Weapon Strength: " + p.weaponValue + " |");
                Console.WriteLine("|        Stimpack Ammount: " + p.stims + " |");
                Console.WriteLine("|        Weapon Mod Strength's: " + p.mods + " |");
                Console.WriteLine("===============================");






                // wait for input
                string input = Console.ReadLine().ToLower();
                if (input == "s" || input == "stimpack")
                {
                    TryBuy("stimpack", stimP, p);

                }
                else if (input == "w" || input == "weapons")
                {
                    TryBuy("weapons", weaponP, p);

                }
                else if (input == "a" || input == "armor")
                {
                    TryBuy("armor", armorP, p);

                }
                else if (input == "m" || input == "mods")
                {
                    TryBuy("mods", difP, p);

                }
                else if (input == "e" || input == "exit")
                {
                    break;
                }
                
            

            }




        }
        static void TryBuy(string item, int cost, Player p)
        {
            if(p.Caps >= cost)
            {
                if (item == "stimpack")
                    p.stims++;
                else if (item == "weapons")
                    p.weaponValue++;
                else if (item == "armor")
                    p.armorValue++;
                else if (item == "mods")
                    p.mods++;
                p.Caps -= cost;

            }
            else
            {
                Console.WriteLine("You ask to but shop owner for the item, but you don't have enough caps. ");
                Console.ReadKey();
            }


        }
    }
}
