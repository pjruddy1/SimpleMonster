using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMonsterClass
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }

        static void DisplayDeleteSeaMonsterInfo(List<SeaMonster> seaMonsters)
        {
            string seaMonsterName;

            DisplayHeader("Delete Sea monster Info");

            //
            //Delete Sea Monster Names
            //
            foreach (SeaMonster seaMonster in seaMonsters)
            {
                Console.WriteLine(seaMonster.Name);
            }
            //
            // Get Name From User
            //
            Console.WriteLine();
            Console.Write("Enter Sea Monster to Delete: ");
            seaMonsterName = Console.ReadLine();

            //
            // get sea monster from list
            //
            bool monsterFound = false;
            foreach (SeaMonster seaMonster in seaMonsters)
            {
                if (seaMonster.Name == seaMonsterName)
                {
                    Console.WriteLine(seaMonster.Name);
                    Console.WriteLine(seaMonster.Weight);
                    Console.WriteLine(seaMonster.CanUseFreshwater);
                    Console.WriteLine(seaMonster.HomeSea);
                    Console.WriteLine(seaMonster.CurrentEmotionalState);
                    Console.WriteLine();
                    Console.Write("Press Any Key to Delete Monster");
                    seaMonsters.Remove(seaMonster);
                    monsterFound = true;
                    break;
                }
            }

            //
            // feedback - monster not found
            //
            if (!monsterFound)
            {
                Console.WriteLine("Unable to find Monster");
            }

            DisplayContinuePrompt();
        }


        /// <summary>
        /// display opening screen
        /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to Simple Monster Classes");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        static SeaMonster InitializeSeaMonsterSid(string name)
        {
            SeaMonster sid = new SeaMonster("Sid");

            sid.Weight = 2.5;
            sid.CanUseFreshwater = true;
            sid.CurrentEmotionalState = SeaMonster.EmotionalState.SAD;
            sid.HomeSea = "Dead Sea";
            return sid;
        }

        static SeaMonster InitializeSeaMonsterSuzy()
        {
            SeaMonster suzy = new SeaMonster();

            suzy.Name = "Suzy";
            suzy.Weight = 1.2;
            suzy.CanUseFreshwater = true;
            suzy.CurrentEmotionalState = SeaMonster.EmotionalState.HAPPY;
            suzy.HomeSea = "Red Sea";
            return suzy;
        }

        static void DisplaySeaMonsterInfo(List<SeaMonster> seaMonsters)
        {
            string seaMonsterName;

            DisplayHeader("Display Sea monster Info");

            //
            //Display a List Of Sea Monster Names
            //
            foreach (SeaMonster seaMonster in seaMonsters)
            {
                Console.WriteLine(seaMonster.Name);
            }
            //
            // Get Name From User
            //
            Console.WriteLine();
            Console.Write("Enter Name: ");
            seaMonsterName = Console.ReadLine();

            //
            // get sea monster from list
            //
            bool monsterFound = false;
            foreach (SeaMonster seaMonster in seaMonsters)
            {
                if (seaMonster.Name == seaMonsterName)
                {
                    Console.WriteLine(seaMonster.Name);
                    Console.WriteLine(seaMonster.Weight);
                    Console.WriteLine(seaMonster.CanUseFreshwater);
                    Console.WriteLine(seaMonster.HomeSea);
                    Console.WriteLine(seaMonster.CurrentEmotionalState);
                    
                    monsterFound = true;
                    break;
                }
            }

            //
            // feedback - monster not found
            //
            if (!monsterFound)
            {
                Console.WriteLine("Unable to find Monster");
            }

            DisplayContinuePrompt();
        }

        static void DisplayAllSeaMonsters(List<SeaMonster> seaMonsters)
        {
            DisplayHeader("List of Sea Monsters");

            foreach (SeaMonster seamonster in seaMonsters)
            {
                Console.WriteLine(seamonster.SeaMonsterAttitude());
            }

            DisplayContinuePrompt();
        }

        static void DisplayGetUserSeaMonster(List<SeaMonster> seaMonsters)
        {
            //
            // create(instantiate) a new SeaMonster object
            //

            SeaMonster newSeaMonster = new SeaMonster();
            DisplayHeader("Add A Sea Monster");
            //
            //Assign Sea Monster Properties

            Console.Write("Enter Name: ");
            newSeaMonster.Name = Console.ReadLine();

            Console.Write("Enter Weight: ");
            double.TryParse(Console.ReadLine(), out double weight);
            newSeaMonster.Weight = weight;

            Console.Write("Can Use Freshwater: ");
            if (Console.ReadLine().ToUpper() == "YES")
            {
                newSeaMonster.CanUseFreshwater = true;
            }
            else
            {
                newSeaMonster.CanUseFreshwater = false;
            }

            Console.Write("Enter Which Sea They Live: ");
            newSeaMonster.HomeSea = Console.ReadLine();

            Console.Write("Enter Emotional State: ");
            Enum.TryParse(Console.ReadLine().ToUpper(), out SeaMonster.EmotionalState emotionalState);
            newSeaMonster.CurrentEmotionalState = emotionalState;
            //
            //Add Sea Monster to list
            seaMonsters.Add(newSeaMonster);

            DisplayContinuePrompt();
        }

        static void DisplayMenu()
        {
            //
            // instantiate sea monsters
            //
            SeaMonster suzy;
            suzy = InitializeSeaMonsterSuzy();

            SeaMonster sid;
            sid = InitializeSeaMonsterSid("sid");

            //
            // add sea monsters to list
            //

            List<SeaMonster> seaMonsters = new List<SeaMonster>();
            seaMonsters.Add(suzy);
            seaMonsters.Add(sid);


            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\tA) Display All Sea Monsters");
                Console.WriteLine("\tB) User Add a Sea Monster");
                Console.WriteLine("\tC) Display Sea monster Info");
                Console.WriteLine("\tE) ");
                Console.WriteLine("\tF) Exit");

                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "A":
                    case "a":
                        DisplayAllSeaMonsters(seaMonsters);
                        break;

                    case "B":
                    case "b":
                        DisplayGetUserSeaMonster(seaMonsters);
                        break;

                    case "C":
                    case "c":
                        DisplaySeaMonsterInfo(seaMonsters);
                        break;

                    case "D":
                    case "d":
                        DisplayDeleteSeaMonsterInfo(seaMonsters);
                        break;

                    case "E":
                    case "e":

                        break;

                    case "F":
                    case "f":
                        exiting = true;
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tThanks for using Simple Monster Classes.");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display header
        /// </summary>
        static void DisplayHeader(string headerTitle)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerTitle);
            Console.WriteLine();
        }
    }
}
