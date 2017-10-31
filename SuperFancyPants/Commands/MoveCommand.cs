using System;
using SuperFancyPants.Business;
using SuperFancyPants.Domain.Enums;

namespace SuperFancyPants.Commands
{
    public class MoveCommand : ICommand
    {
        public string Name { get { return "move"; } }
        public string Description { get { return "move <direction> | Info"; } }

        public void Execute(Game game, string args)
        {
            if (Enum.TryParse<EDirection>(args, true, out var direction))
            {
                game.MoveToDirection(direction);
            }
            else
            {
                PrintNotValidDirection();
            }
        }

        private static void PrintNotValidDirection()
        {
            Console.WriteLine("Not a valid direction!?");
        }
    }
}