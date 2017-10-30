using System;

namespace SuperFancyPants
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PrintMethod();

            Console.ReadKey();
        }

        public static void PrintMethod()
        {
            Console.WriteLine("Vanuit de print methode");

            string result = Console.ReadLine();

            Console.WriteLine(result);

            Console.WriteLine("Dit was het resultaat: " + result);
            Console.WriteLine(String.Format("Dit was het resultaat: {0}", result));
            Console.WriteLine($"Dit was het resultaat: {result}");

            string multiLine = @"Hallo
                                    Multi line";

            string s = "C:\\Projects\\Temp\\";
            string s2 = @"C:\Projects\Temp\";

            Console.WriteLine(multiLine);

            string @string;
            int i;
            float f;
            double d;
            bool b;
            long l;
        }
    }
}
