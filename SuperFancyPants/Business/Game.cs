using System;
using System.Threading;
using System.Threading.Tasks;
using SuperFancyPants.Domain;
using SuperFancyPants.Domain.Enums;

namespace SuperFancyPants.Business
{
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

            upstairs.ConnectedRooms.Add(EDirection.Up, livingRoom);

            diner.ConnectedRooms.Add(EDirection.North, kitchen);

            _currentRoom = entrance;

            livingRoom.SomeoneEntered += LivingRoomOnSomeoneEntered;
        }

        private void LivingRoomOnSomeoneEntered(object sender, EventArgs eventArgs)
        {
            Thread.Sleep(1000);
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(1000);

                Console.WriteLine("Je bent naar de living room genavigeerd!");
            });
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
                _currentRoom.MovedToRoom();
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
}