using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            Console.Title = "Wasteland Game";
            Console.ForegroundColor = ConsoleColor.Green;
            // ----------------------------------------------------
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            Start();
            Encounters.FirstEncounter();
            while (mainLoop)
            {
                Encounters.RandomEncounter();

            }

        }


        static void Start()
        {

            Console.WriteLine("You wake's up in a cold metal shell that you reluctantly call home.");
            Console.WriteLine("You live a fallout shelter to protect you from the radaition above ground.");
            Console.WriteLine("You were awaken by the banging on your door, you assume it's a security guard checking up on people.......");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You open the door to a guard in a panic, he asks you 'Whats your name?!' ");
            Console.Write("Name: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(" 'Well nice to meet you " +currentPlayer.name + ", The vault has been compromised its every man for themselves! ' ");

            Console.WriteLine("After he says this hes pulled into the hallway violently by some sort of creature. ");
            Console.ReadKey();
            

        }

        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString();
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();


        }




    }
}
