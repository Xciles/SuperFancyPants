using System;
using SuperFancyPants.Business;

namespace SuperFancyPants.Commands
{
    public class HelpCommand : ICommand
    {
        public string Name { get { return "help"; } }
        public string Description { get { return "This command"; } }

        public void Execute(Game game, string args)
        {
            Console.WriteLine("Available help Commands: ");
            foreach (var command1 in Program.Commands)
            {
                Console.WriteLine($"{command1.Name} : {command1.Description}");
            }
        }
    }
}