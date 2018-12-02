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
                    Console.WriteLine(seaMonster.WhenFound);
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

        static void InitializeSeaMonsters(string name, List<SeaMonster> seaMonsters)
        {
            
            SeaMonster sid = new SeaMonster("Sid");

            sid.Weight = 2.5;
            sid.CanUseFreshwater = true;
            sid.CurrentEmotionalState = SeaMonster.EmotionalState.SAD;
            sid.HomeSea = "Dead Sea";
            sid.WhenFound = new DateTime(1984, 11, 27, 6, 32, 0);
            sid.SeaMonsterIsFound();
            seaMonsters.Add(sid);

            SeaMonster suzy = new SeaMonster();
            suzy.Name = "Suzy";
            suzy.Weight = 1.2;
            suzy.CanUseFreshwater = true;
            suzy.CurrentEmotionalState = SeaMonster.EmotionalState.HAPPY;
            suzy.HomeSea = "Red Sea";
            suzy.WhenFound = new DateTime(1982, 12, 04, 6, 32, 0);
            suzy.SeaMonsterIsFound();
            seaMonsters.Add(suzy);
        }
        
        static void DisplayChangeSeaMonsterInfo(List<SeaMonster> seaMonsters)
        {
            string seaMonsterName;
            bool validResponse = false;
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
            Console.Write("Enter Name of Sea Monster to Change: ");
            seaMonsterName = Console.ReadLine();

            //
            // get sea monster from list
            //
            bool monsterFound = false;
            foreach (SeaMonster seaMonster in seaMonsters)
            {
                if (seaMonster.Name == seaMonsterName)
                {
                    Console.WriteLine();
                    Console.WriteLine("Current Monster's Information");
                    Console.WriteLine(seaMonster.Name);
                    Console.WriteLine($"weight in Tons {seaMonster.Weight}");
                    Console.WriteLine($"Sea Monster uses fresh water {seaMonster.CanUseFreshwater}");
                    Console.WriteLine($"{seaMonster.Name} lives in {seaMonster.HomeSea}");
                    Console.WriteLine($"{seaMonster.Name} is feeling {seaMonster.CurrentEmotionalState}");
                    Console.WriteLine($"First Found {seaMonster.WhenFound}");
                    Console.WriteLine($"Sea Monster Found {seaMonster.WasFound}");

                    Console.Write("Enter Sea Monster's Correct Name: ");
                    seaMonster.Name = Console.ReadLine();

                    Console.Write("Enter Sea Monster's Correct Weight: ");
                    validResponse = double.TryParse(Console.ReadLine(), out double weight);
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please Enter a correct amount!");
                        validResponse = double.TryParse(Console.ReadLine(), out weight);
                    }
                    seaMonster.Weight = weight;

                    Console.Write("Can The Sea Monster Use Freshwater: ");
                    while (!validResponse)
                    {
                        if (Console.ReadLine().ToUpper() == "YES")
                        {
                            seaMonster.CanUseFreshwater = true;
                            validResponse = true;
                        }
                        else if (Console.ReadLine().ToUpper() == "NO")
                        {
                            seaMonster.CanUseFreshwater = false;
                            validResponse = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.Write("Invalid answer please choose YES or NO: ");
                        }
                    }
                    Console.Write("Enter the correct Sea they live in: ");
                    seaMonster.HomeSea = Console.ReadLine();

                    Console.Write("Enter Correct Emotional State: ");
                    Enum.TryParse(Console.ReadLine().ToUpper(), out SeaMonster.EmotionalState emotionalState);
                    switch (emotionalState)
                    {
                        case SeaMonster.EmotionalState.HAPPY:
                        case SeaMonster.EmotionalState.SAD:
                        case SeaMonster.EmotionalState.ANGRY:
                        case SeaMonster.EmotionalState.PISSED:
                        case SeaMonster.EmotionalState.FURIOUS:
                        case SeaMonster.EmotionalState.WILD:
                            validResponse = true;
                            break;
                        case SeaMonster.EmotionalState.NONE:
                            validResponse = false;
                            break;
                    }
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please enter valid Emotion: ");
                        Enum.TryParse(Console.ReadLine().ToUpper(), out emotionalState);
                        switch (emotionalState)
                        {
                            case SeaMonster.EmotionalState.HAPPY:
                            case SeaMonster.EmotionalState.SAD:
                            case SeaMonster.EmotionalState.ANGRY:
                            case SeaMonster.EmotionalState.PISSED:
                            case SeaMonster.EmotionalState.FURIOUS:
                            case SeaMonster.EmotionalState.WILD:
                                validResponse = true;
                                break;
                            case SeaMonster.EmotionalState.NONE:
                                validResponse = false;
                                break;
                        }
                    }
                    seaMonster.CurrentEmotionalState = emotionalState;

                    Console.WriteLine("Enter the  Correct Date/Time they were found (YYYY-MM-DD): ");
                    validResponse = DateTime.TryParse(Console.ReadLine(), out DateTime dateTime);
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please enter a valid Date & Time: ");
                        validResponse = DateTime.TryParse(Console.ReadLine(), out dateTime);
                    }
                    seaMonster.WhenFound = dateTime;

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
                    Console.WriteLine($"weight in Tons {seaMonster.Weight}");
                    Console.WriteLine($"Sea Monster uses fresh water {seaMonster.CanUseFreshwater}");
                    Console.WriteLine($"{seaMonster.Name} lives in {seaMonster.HomeSea}");
                    Console.WriteLine($"{seaMonster.Name} is feeling {seaMonster.CurrentEmotionalState}");
                    Console.WriteLine($"First Found {seaMonster.WhenFound}");
                    Console.WriteLine($"Sea Monster Found {seaMonster.WasFound}");

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
            DisplayHeader("List of Sea Monsters and how they feel:");

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
            bool validResponse = false;
            SeaMonster newSeaMonster = new SeaMonster();
            DisplayHeader("Add A Sea Monster");
            //
            //Assign Sea Monster Properties

            Console.Write("Enter Name: ");
            newSeaMonster.Name = Console.ReadLine();

            Console.Write("Enter the monster's weight in tons: ");
            validResponse = double.TryParse(Console.ReadLine(), out double weight);
            while(!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount!");
                validResponse = double.TryParse(Console.ReadLine(), out weight);
            }
            newSeaMonster.Weight = weight;

            validResponse = false;
            while (!validResponse)
            {
                Console.Write($"Can {newSeaMonster.Name} Use Freshwater: ");
                if (Console.ReadLine().ToUpper() == "YES")
                {
                    newSeaMonster.CanUseFreshwater = true;
                    validResponse = true;
                }
                else if (Console.ReadLine().ToUpper() == "NO")
                {
                    newSeaMonster.CanUseFreshwater = false;
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Invalid answer please choose YES or NO: ");
                }
            }
            Console.Write($"Which body does {newSeaMonster.Name} reside: ");
            newSeaMonster.HomeSea = Console.ReadLine();

            Console.Write("Enter Emotional State(Happy, Sad, Angry, Pissed, Furious, Wild): ");
            Enum.TryParse(Console.ReadLine().ToUpper(), out SeaMonster.EmotionalState emotionalState);
            switch (emotionalState)
            {
                case SeaMonster.EmotionalState.HAPPY:
                case SeaMonster.EmotionalState.SAD:
                case SeaMonster.EmotionalState.ANGRY:
                case SeaMonster.EmotionalState.PISSED:
                case SeaMonster.EmotionalState.FURIOUS:
                case SeaMonster.EmotionalState.WILD:
                    validResponse = true;
                    break;
                case SeaMonster.EmotionalState.NONE:
                    validResponse = false;
                    break;
            }
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please enter valid Emotion: ");
                Enum.TryParse(Console.ReadLine().ToUpper(), out emotionalState);
                switch (emotionalState)
                {
                    case SeaMonster.EmotionalState.HAPPY:
                    case SeaMonster.EmotionalState.SAD:
                    case SeaMonster.EmotionalState.ANGRY:
                    case SeaMonster.EmotionalState.PISSED:
                    case SeaMonster.EmotionalState.FURIOUS:
                    case SeaMonster.EmotionalState.WILD:
                        validResponse = true;
                        break;
                    case SeaMonster.EmotionalState.NONE:
                        validResponse = false;
                        break;
                }
            }
            newSeaMonster.CurrentEmotionalState = emotionalState;

            Console.WriteLine("Enter the  Correct Date/Time they were found (YYYY,MM,DD,hh,mm,ss): ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out DateTime dateTime);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please enter a valid Date & Time: ");
                validResponse = DateTime.TryParse(Console.ReadLine(), out dateTime);
            }
            newSeaMonster.WhenFound = dateTime;
            newSeaMonster.SeaMonsterIsFound();

            //
            //Add Sea Monster to list
            seaMonsters.Add(newSeaMonster);

            DisplayContinuePrompt();
        }

        static void DisplayMenu()
        {
            List<SeaMonster> seaMonsters = new List<SeaMonster>();
            InitializeSeaMonsters("name", seaMonsters);
            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\tA) Display All Sea Monsters");
                Console.WriteLine("\tB) User Add a Sea Monster");
                Console.WriteLine("\tC) Display Sea monster Info");
                Console.WriteLine("\tD) Delete Sea Monster");
                Console.WriteLine("\tE) Update Sea Monster Info");
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
                        DisplayChangeSeaMonsterInfo(seaMonsters);
                        break;

                    case "F":
                    case "f":
                        exiting = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice please choose again.");
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
