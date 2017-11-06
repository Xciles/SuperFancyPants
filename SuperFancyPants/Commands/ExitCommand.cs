using System;
using SuperFancyPants.Business;
using static System.Math;

namespace SuperFancyPants.Commands
{
    public class ExitCommand : ICommand
    {
        public string Name => "exit";
        public string Description { get { return "Exit the game!"; } }

        public void Execute(Game game, string args)
        {
            Program.ShouldFinish();

            Pow(2, 2);

        }

        public string ReturnMethod()
        {
            return Name;
        }
    }
}