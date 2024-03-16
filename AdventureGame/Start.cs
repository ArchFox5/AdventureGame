using System;
using System.Threading;

namespace SlimeAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Introduction();
        }

        private static void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=======================================");
            Console.WriteLine("      Welcome to Slime Adventure       ");
            Console.WriteLine("=======================================");
            Console.WriteLine("A large and green, slightly slimy world awaits you!");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nWhat you know:");
            Console.WriteLine("You find yourself in a place filled with lush green forests, and shimmering ponds. But wait... aren't you also a slime?");
            Console.ResetColor();

            AskToStartAdventure();
        }

        private static void AskToStartAdventure()
        {
            Console.WriteLine("\n\nAre you ready to find out why you're a slime? (Y/N)");
            string response = Console.ReadLine().ToLower();

            if (response == "no" || response == "n")
            {
                Console.WriteLine("\nIt's okay! Come back when you're ready to embark on this slimy adventure!");
                return;
            }
            else if (response == "yes" || response == "y")
            {
                StartAdventure();
            }
            else
            {
                Console.WriteLine("\nBoing! Please respond with 'Yes' or 'No'.");
                AskToStartAdventure();
            }
        }

        private static void StartAdventure()
        {
            int ladybugX = 1;
            int ladybugY = 0;
            int shovelX = 4;
            int shovelY = -3;
            int flowerX = 4;
            int flowerY = -9;

            bool ladybugFound = false;
            bool shovelFound = false;
            bool flowerFound = false;

            Console.WriteLine("\nThe adventure begins! Let's discover why you're a slime...");
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" B O I N G");
            Console.WriteLine("              ░░░░░░░░░░                ");
            Console.WriteLine("          ░░░░        ░░░░░░            ");
            Console.WriteLine("        ░░                  ░░          ");
            Console.WriteLine("      ░░                    ░░░░        ");
            Console.WriteLine("    ░░                      ░░░░░░      ");
            Console.WriteLine("    ░░                        ░░░░      ");
            Console.WriteLine("  ░░                ░░    ░░  ░░░░░░    ");
            Console.WriteLine("  ░░                ██░░  ██    ░░░░    ");
            Console.WriteLine("  ░░                ██░░  ██    ░░░░    ");
            Console.WriteLine("  ░░            ░░            ░░░░░░    ");
            Console.WriteLine("  ░░░░░░                      ░░░░░░    ");
            Console.WriteLine("    ░░░░░░                  ░░░░░░      ");
            Console.WriteLine("Use 'W', 'A', 'S', and 'D' to move the slime. Press 'Q' to quit.");
            Console.WriteLine("\nYou see something to the right of you.");

            int slimeX = 0;
            int slimeY = 0;
            bool hitFence = false;

            Thread movementThread = new Thread(() =>
            {
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (hitFence)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.Write(new string(' ', Console.WindowWidth));

                        hitFence = false;
                    }

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.W:
                            if (slimeY > -20)
                                slimeY++;
                            break;
                        case ConsoleKey.A:
                            if (slimeX > -20)
                                slimeX--;
                            break;
                        case ConsoleKey.S:
                            if (slimeY < 20)
                                slimeY--;
                            break;
                        case ConsoleKey.D:
                            if (slimeX < 20)
                                slimeX++;
                            break;
                        case ConsoleKey.Q:
                            Console.WriteLine("Quitting...");
                            Environment.Exit(0);
                            break;
                    }

                    if (Math.Abs(slimeX) >= 20 || Math.Abs(slimeY) >= 20)
                    {
                        PrintFence();
                        hitFence = true;
                    }
                    if (slimeX == ladybugX && slimeY == ladybugY && !ladybugFound)
                    {
                        ladybugFound = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nYou find a Lady bug flying about, you carefully dodge it, but it follows you anyway... strange...");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nYou see something to the south east of you.");
                    }
                    else if (slimeX == shovelX && slimeY == shovelY && !shovelFound)
                    {
                        shovelFound = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nYou roll over a shovel, it doesn't hurt but it looks a bit dangerous to have here in tall grass.");
                        Console.WriteLine("\nYou decide to roll over an area where the grass is flattened so nobody gets hurt.");
                        Console.WriteLine("\nThis shovel looks familiar anyway...");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nYou see something to the south of you.");
                    }
                    else if (slimeX == flowerX && slimeY == flowerY && !flowerFound)
                    {
                        flowerFound = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nA beautiful flower with a strong smell. Perfect for making potions with...");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    if (ladybugFound && shovelFound && flowerFound)
                    {
                        Win();
                        return;
                    }

                    Console.WriteLine($"\nSlime moved. Current position: ({slimeX}, {slimeY})");
                }
            });
            movementThread.IsBackground = true;
            movementThread.Start();

            while (true)
            {
            }
        }

        private static void PrintFence()
        {
            Console.WriteLine("\nOof! You've hit what seems to be a fence");
        }

        private static void Win()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string userName = Environment.UserName;
            Console.WriteLine($"\nHey!! {userName}!? Where are you!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nWhat was that sound? You decide to... ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n1. Go closer to the voice calling out your name.");
            Console.WriteLine("\n2. Stay where you are, maybe you can blend in with your surroundings.");
            Console.WriteLine("\n3. Run away!!");

            string response = Console.ReadLine().ToLower();

            if (response == "1" || response == "first")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nThere you are! I've been looking all over for you {userName}.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThe person seemed to be a witch, she swiftly picked you up and said some chants.");
                Console.WriteLine("\nPoof!");
                Console.WriteLine("\nAnd just like that you were turned back into a human!");
                Console.WriteLine("\nAs it turned out, you turned yourself into a slime...");
                Environment.Exit(0);
            }
            else if (response == "2" || response == "second")
            {
                Console.WriteLine("\nYou decided to stay hidden.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{userName}? Where are you?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThe voice steps closer and closer until finally...");
                Console.WriteLine("\nThey step on you.");
                Thread.Sleep(2000);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oop- Sorry.");
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("\nIt was a witch! And she is now picking you up and chanting...");
                Console.WriteLine("\nPoof!");
                Console.WriteLine("\nAnd just like that you were turned back into a human!");
                Console.WriteLine("\nAs it turned out, you turned yourself into a slime...");
                Environment.Exit(0);
            }
            else if (response == "3" || response == "third")
            {
                Console.WriteLine("\nH-Hey! Come back!");
                Console.WriteLine("\nYou run away towards the fence quickly!");
                Console.WriteLine("\nUnfortunately, you were so fast you slammed right into the fence as well...");
                Console.WriteLine("\nYou lose consciousness...");
                Introduction();
            }
            else
            {
                Console.WriteLine("\nBoing! Please respond with '1', '2', or '3'.");
                Win();
            }
        }
    }
}
