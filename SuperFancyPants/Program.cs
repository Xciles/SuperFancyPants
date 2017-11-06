using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SuperFancyPants.Business;
using SuperFancyPants.Commands;

namespace SuperFancyPants
{
    public class Program
    {
        private static bool _done = false;
        public static IList<ICommand> Commands { get; private set; }

        public static void Main()
        {
            var game = new Game();

            SetupCommands();

            game.InitializeAndStartGame();
            var skipDescribe = false;

            while (!_done)
            {
                if (!skipDescribe)
                {
                    game.DescribeLocation();
                }
                skipDescribe = false;

                if (game.ShouldEnd()) break;

                PrintLambda();

                var input = Console.ReadLine();

                string command = input;
                string args = "";

                if (input.Contains(" "))
                {
                    command = input.Substring(0, input.IndexOf(" ", StringComparison.InvariantCulture));
                    args = input.Substring(input.IndexOf(" ", StringComparison.InvariantCulture) + 1);
                }

                var commandInstance = Commands.FirstOrDefault(x => x.Name == command);
                commandInstance?.Execute(game, args);

                if (commandInstance == null || commandInstance is HelpCommand)
                {
                    skipDescribe = true;
                }

                if (commandInstance == null)
                {
                    PrintCommandNotFound();
                }
            }

            game.End();

            Console.WriteLine("<press any key to exit>");
            Console.ReadKey();
        }

        private static void SetupCommands()
        {
            Commands = Assembly.GetExecutingAssembly().GetTypes()
                         .Where(x => x.GetInterfaces().Contains(typeof(ICommand)))
                         .Select(x => Activator.CreateInstance(x) as ICommand).ToList();


            var ty = typeof(ICommand);

            //var bla = (ty)Activator.CreateInstance(ty);
        }

        public static void ShouldFinish()
        {
            dynamic bla = default(dynamic);

            bla.Test = "";

            _done = true;
        }

        private static void PrintCommandNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Command not found...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintLambda()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("λ ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
