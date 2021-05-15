using System;

namespace ConsoleApp1
{
    public class Encounters
    {

        static Random rand = new Random();

        //Encounter Generic



        //Encounters 
        public static void FirstEncounter()
        {
            Console.Clear();
            Console.WriteLine("You look over to your nightstand and grab a rusty pipe");
            Console.WriteLine("You open your door to see irradaiated scorpions attacking people");
            Console.WriteLine("A Radation scorpion spots you, and turns towards you.....");
            Console.ReadKey();
            Combat(false, "Rad Scorpion", 1, 4);


        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("What will u do next? ");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("=============SELECT ONE============");
            Console.WriteLine("===================================");
            Console.WriteLine("|             (E)xplore           |");
            Console.WriteLine("|             (R)return           |");
            Console.WriteLine("===================================");
            string input2 = Console.ReadLine();
            if (input2 == "e" || input2 == "explore")
            {
                Combat(true, "", 0, 0);

            }
            else if(input2 == "r" || input2 == "return")
            {
                Shop.LoadShop(Program.currentPlayer); 
            }



            


        }


        //Encounter Tools
        public static void RandomEncounter()
        {
            switch (rand.Next(0, 1))
            {
                case 0:
                    BasicFightEncounter();
                    break;

            }

        }


        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();

            }
            else
            {
                n = name;
                p = power;
                h = health;

            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine("=======" + n + " =======");
                Console.WriteLine(p + "<--Power / Health -->" + h);
                Console.WriteLine("=======================");
                Console.WriteLine("|  (A)ttack (D)efnd   |");
                Console.WriteLine("|  (R)un    (H)eal    |");
                Console.WriteLine("=======================");
                Console.WriteLine("Stimpaks: " + Program.currentPlayer.stims + "  Health: " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //attack
                    Console.WriteLine("You swing your weapon and strike the " + n);
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage ");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine("You swing your arms over your face and brace for impact from the  " + n);
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4) / 2;
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage ");
                    Program.currentPlayer.health -= damage;
                    h -= attack;

                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint away from " + n + " Its strike catches you in the back, sending you sprawling onto the ground");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You nearly escape the strike from the " + n + " and you successfully ran away!");
                        Console.ReadKey();
                        //goto store
                        Shop.LoadShop(Program.currentPlayer);
                    }


                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //heal
                    if (Program.currentPlayer.stims == 0)
                    {
                        Console.WriteLine("You fumble around in your gucci x Louis Vittion hand bag you can't find any stimpacks");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("The " + n + " Strikes you while you were distracted. You lose " + damage + " Health");
                    }
                    else
                    {
                        Console.WriteLine("You reach into your bag and retreive stimpack(s) ");
                        int stimV = 5;
                        Console.WriteLine("You gain" + stimV + " Health");
                        Program.currentPlayer.health += stimV;
                        Console.WriteLine("As you were healing the " + n + " Strikes you.");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine(n + " Hit you for" + damage + " Health");


                    }
                }
                if(Program.currentPlayer.health <= 0)
                {
                    //Death code 
                    Console.WriteLine("As you strugle to keep it together the attack  from " + n + " was devastating and you have died.");
                    Console.ReadKey();
                    System.Environment.Exit(0);

                }
                Console.ReadKey();








            }
            int c = Program.currentPlayer.GetCaps();
            Console.WriteLine("As you stand proundly over the "+n + ", its body limp you check it for caps Jackpot! You collect " +c+ " caps!");
            Program.currentPlayer.Caps += c;
            Console.ReadKey();




        }

        public static string GetName()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Rad Scorpion";
                case 1:
                    return "Solja Boy";
                case 2:
                    return "Raider";
                case 3:
                    return "Rouge Securitron";
                case 4:
                    return "Rad Roach";

            }
            return "Crazy Human "; 


        }
    }
}
