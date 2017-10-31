using System;
using SuperFancyPants.Business;
using SuperFancyPants.Domain.Enums;

namespace SuperFancyPants
{
    public class Program
    {
        public static void Main()
        {
            var done = false;
            var game = new Game();

            game.InitializeAndStartGame();

            while (!done)
            {
                game.DescribeLocation();

                if (game.ShouldEnd()) break;

                PrintLambda();

                var input = Console.ReadLine();
                string args = "";
                if (input.Contains(" "))
                {
                    var splitted = input.Split(" ");
                    input = splitted[0];
                    args = splitted[1];
                }

                switch (input.ToLower())
                {
                    case "move":
                        {
                            EDirection direction;
                            if (Enum.TryParse<EDirection>(args, true, out direction))
                            {
                                game.MoveToDirection(direction);
                            }
                            else
                            {
                                PrintNotValidDirection();
                            }
                            break;
                        }
                    case "look":
                        {
                            game.LookArround();
                            break;
                        }
                    case "exit":
                        {
                            done = true;
                            break;
                        }
                    case "help":
                        {
                            PrintHelp();
                            break;
                        }
                    default:
                        {
                            PrintCommandNotFound();
                            PrintHelp();
                            break;
                        }
                }
            }

            game.End();

            Console.WriteLine("<press any key to exit>");
            Console.ReadKey();
        }

        private static void PrintCommandNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Command not found...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Help:");
            Console.WriteLine("Available commands are, Move <to>, Help, Exit");
        }

        private static void PrintNotValidDirection()
        {
            Console.WriteLine("Not a valid direction!?");
        }

        private static void PrintLambda()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("λ ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
