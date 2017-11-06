using System;

namespace ExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var game = new Game();
            //game.SetupRoom();

            //game.PrintItemsInChestInRoom(100);

            string input = Length("Deze string", out var length);

            var result = Length("Deze string");

            (string Input, int Length) result2 = LengthBet("Deze string");


            Console.WriteLine(result2);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        public static (string Input, int Length) LengthBet(string input)
        {
            (string Input, int Length) bla = (input, input.Length);

            bla.Length = 10_000;

            return (input, input.Length);
        }

        public static Tuple<string, int> Length(string input)
        {
            return new Tuple<string, int>(input, input.Length);
        }

        public static string Length(string input, out int length)
        {
            length = input.Length;
            return input;
        }
    }
}
