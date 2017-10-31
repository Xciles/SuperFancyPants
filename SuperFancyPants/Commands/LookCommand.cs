using SuperFancyPants.Business;

namespace SuperFancyPants.Commands
{
    public class LookCommand : ICommand
    {
        public string Name { get { return "look"; } }
        public string Description { get { return "You will arround for clues!"; } }

        public void Execute(Game game, string args)
        {
            game.LookArround();
        }
    }
}