using SuperFancyPants.Business;

namespace SuperFancyPants.Commands
{
    //public class Help
    //{
    //    public void Test()
    //    {
    //        string input = Console.ReadLine();

    //        var command = input.Substring(0, input.IndexOf(" ", StringComparison.InvariantCulture));
    //        var args = input.Substring(input.IndexOf(" ", StringComparison.InvariantCulture) + 1);

    //        var commandInstance = CommandList.ParseCommand(command);
    //        commandInstance.Execute(null,args);
    //    }
    //}

    //public class CommandList
    //{
    //    private static IList<ICommand> _commands = new List<ICommand>();
    //    public static ICommand ParseCommand(string command)
    //    {
    //        switch (command)
    //        {
    //            case "move": return new MoveCommand();
    //            case "help": return new HelpCommand();
    //            default: return new HelpCommand();
    //        }
    //    }
    //}

    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        void Execute(Game game, string args);
    }
}
