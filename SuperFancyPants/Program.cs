using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperFancyPants
{
    public enum EDirection
    {
        North,
        East,
        South,
        West,
        Up,
        Down
    }

    public class Room
    {
        public IDictionary<EDirection, Room> ConnectedRooms = new Dictionary<EDirection, Room>();
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Finish { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Currently in {Name}");
            Console.Write($"Possible directions are: ");

            foreach (var connectedRoomsKey in ConnectedRooms.Keys)
            {
                Console.Write($"{connectedRoomsKey:G} ");
            }
            Console.Write(Environment.NewLine);
        }
    }

    public class Game
    {
        private Room _currentRoom;

        public string PlayerName { get; private set; }

        public void InitializeAndStartGame()
        {
            Setup();

            Initialize();

            Start();
        }

        private void Setup()
        {
            var entrance = new Room { Description = "Main entrance to the Castle", Name = "Entrance" };
            var livingRoom = new Room { Description = "Welcome to the LivingRoom", Name = "LivingRoom" };
            var diner = new Room { Description = "The diner looks nice, doesn't it?", Name = "Diner" };
            var kitchen = new Room { Description = "We have some food in the kitchen.", Name = "Kitchen", Finish = true };
            var upstairs = new Room { Description = "This is upstairs", Name = "Upstairs" };
            var yard = new Room { Description = "This is the yard", Name = "Yard" };


            entrance.ConnectedRooms.Add(EDirection.North, livingRoom);
            entrance.ConnectedRooms.Add(EDirection.South, yard);

            yard.ConnectedRooms.Add(EDirection.North, entrance);

            livingRoom.ConnectedRooms.Add(EDirection.Up, upstairs);
            livingRoom.ConnectedRooms.Add(EDirection.East, diner);

            diner.ConnectedRooms.Add(EDirection.North, kitchen);

            _currentRoom = entrance;
        }

        private void Initialize()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("------------------------------------------------------------------------------");
            Console.Write("------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SUPER FANCY PANTS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");

            var str = @"                         __...---""""""---...__
           .:::::.   _.-'                      '-._
       .::::::::::::::::'   ^^      ,              '-.
  .  .:::''''::::::::'   ,        _/(_       ^^       '.
   ':::'      .'       _/(_       {\\               ,   '.
             /         {\\        /;_)            _/(_    \
            /   ,      /;_)    =='/ <===<<<       {\\      \
           /  _/(_  =='/ <===<<<  \__\       ,    /;_)      \
          /   {\\      \__\      , ``      _/(_=='/ <===<<<  \ ";

            Console.WriteLine(str);
            Console.WriteLine("------------------------------------------------------------------------------");

            SetPlayerName();
        }

        private void SetPlayerName()
        {
            Console.WriteLine("Hello new player, what is your Name?");
            PrintLambda();

            PlayerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(PlayerName)) SetPlayerName();

            Console.WriteLine($"Welcome {PlayerName}, please find the Exit!");
        }

        private static void PrintLambda()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("λ ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool ShouldEnd()
        {
            return _currentRoom.Finish;
        }

        public void End()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("-----       END     ------");
            Console.WriteLine("--------------------------");
        }

        private void Start()
        {

        }

        public void DescribeLocation()
        {
            Console.WriteLine($"-- You are currently in {_currentRoom.Name}. --");
            Console.WriteLine($"-- {_currentRoom.Description}");

            if (_currentRoom.Finish)
            {
                Console.WriteLine("YOU HAVE MADE IT TO THE FINISH!");
                var str = @"╔═══╗─────────────╔╗───╔╗───╔╗
║╔═╗║────────────╔╝╚╗──║║──╔╝╚╗
║║─╚╬══╦═╗╔══╦═╦═╩╗╔╬╗╔╣║╔═╩╗╔╬╦══╦═╗╔══╗
║║─╔╣╔╗║╔╗╣╔╗║╔╣╔╗║║║║║║║║╔╗║║╠╣╔╗║╔╗╣══╣
║╚═╝║╚╝║║║║╚╝║║║╔╗║╚╣╚╝║╚╣╔╗║╚╣║╚╝║║║╠══║
╚═══╩══╩╝╚╩═╗╠╝╚╝╚╩═╩══╩═╩╝╚╩═╩╩══╩╝╚╩══╝
──────────╔═╝║
──────────╚══╝";
                Console.WriteLine(str);
                Console.WriteLine("-----------------------");
            }
        }

        public void MoveToDirection(EDirection direction)
        {
            if (_currentRoom.ConnectedRooms.ContainsKey(direction))
            {
                _currentRoom = _currentRoom.ConnectedRooms[direction];
            }
            else
            {
                Console.WriteLine($"Cannot move to {direction}.");
            }
        }

        public void LookArround()
        {
            _currentRoom.PrintInfo();
        }
    }

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
