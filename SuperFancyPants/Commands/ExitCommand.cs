using SuperFancyPants.Business;

namespace SuperFancyPants.Commands
{
    public class ExitCommand : ICommand
    {
        public string Name { get { return "exit"; } }
        public string Description { get { return "Exit the game!"; } }

        public void Execute(Game game, string args)
        {
            Program.ShouldFinish();
        }
    }
}