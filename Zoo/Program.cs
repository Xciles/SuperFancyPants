using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Zoo
{
    

    class Program
    {
        static void Main(string[] args)
        {
            IAnimal zergling = new Zergling();

            zergling.NumberOfLegs();
            zergling.Speak();

            var zerglings = new List<Zergling>()
            {
                new Zergling()
                {
                    Name = "zerlings 1",
                    Health = 100
                },
                new Zergling()
                {
                    Name = "zerlings 2",
                    Health = 100
                },
                new Zergling()
                {
                    Name = "zerlings 3",
                    Health = 100
                },
                new Zergling()
                {
                    Name = "zerlings 11",
                    Health = 100
                },
                new Zergling()
                {
                    Name = "zerlings 11",
                    Health = 100
                },
                new Zergling()
                {
                    Name = "zerlings 11",
                    Health = 100
                },
                new Zergling()
                {
                    Name = "zerlings 11",
                    Health = 100
                },
                new Zergling()
                {
                    Name = "zerlings 11",
                    Health = 100
                },
                new Zergling()
                {
                    Name = "zerlings 12",
                    Health = 100
                },
                new Zergling()
                {
                    Name = "zerlings 13",
                    Health = 100
                },
                new Zergling()
                {
                    Name = "zerlings 22",
                    Health = 100
                }
            };

            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine($"Iteration: {j}");

                Stopwatch watch = new Stopwatch();

                watch.Start();
                for (int i = 0; i < 10_000_000; i++)
                {
                    var lings1 = zerglings.Where(x => x.Name == "zerlings 1").First();
                    lings1.Health++;
                }
                watch.Stop();

                var lingsWhereElapsed = watch.ElapsedMilliseconds;

                watch.Reset();
                watch.Start();

                for (int i = 0; i < 100_000_00; i++)
                {
                    var lings1 = zerglings.First(x => x.Name == "zerlings 1");
                    lings1.Health++;
                }
                watch.Stop();

                var lingsFirstElapsed = watch.ElapsedMilliseconds;
                
                Console.WriteLine($"Where: {lingsWhereElapsed}");
                Console.WriteLine($"First: {lingsFirstElapsed}");
            }

            //var lings1 = zerglings.Where(x => x.Name.Contains("1")).First();
            //var lings2 = zerglings.First(x => x.Name.Contains("1"));


            var aa = zerglings.Where(x => x.Name.Contains("1")).ToList();


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
