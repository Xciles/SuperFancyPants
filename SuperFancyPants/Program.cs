using System;

namespace SuperFancyPants
{
    public class Game
    {
        private static string _name;
        private static string _house;
        private static string _street;
        private static string _level;

        public static void StartGame()
        {
            Initialize();

            Start();

            End();
        }

        private static void End()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("-----       END     ------");
            Console.WriteLine("--------------------------");
        }

        private static void Start()
        {
            Console.WriteLine("Wat is je naam?");
            _name = Console.ReadLine();
            Console.WriteLine("Wat is je house?");
            _house = Console.ReadLine();
            Console.WriteLine("Wat is je street?");
            _street = Console.ReadLine();
            Console.WriteLine("Wat is je level?");
            _level = Console.ReadLine();

            Console.WriteLine($"Hallo {_name}, Je woont op {_street} en je huis staat op {_house}. " +
                              $"Je level is {_level}");
        }

        private static void Initialize()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("-----SuperFancyPants------");
            Console.WriteLine("--------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game.StartGame();

            Console.ReadKey();
        }
    }
}
