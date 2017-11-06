//using System;
//using System.Net;

//namespace Zoo
//{
//    public interface IAnimal
//    {
//        string Name { get; set; }
//        int? Health { get; set; }
//        /// <summary>
//        /// Return numbers of legs
//        /// </summary>
//        /// <returns>An int number of legs</returns>
//        int? NumberOfLegs();
//        void Speak();
//    }

//    public abstract class Animal : IAnimal
//    {
//        public string Name { get; set; }
//        public int? Health { get; set; }

//        public abstract int? NumberOfLegs();

//        public virtual void Speak()
//        {
//            Console.WriteLine("Aaargh");
//        }
//    }

//    public class Zergling : Animal
//    {
//        public override int? NumberOfLegs()
//        {
//            return 6;
//        }

//        public override void Speak()
//        {
//            Console.WriteLine("Hoi!");
//        }
//    }

//    public class Hydralisk : Animal
//    {
//        public override int? NumberOfLegs()
//        {
//            return 1;
//        }

//        public override void Speak()
//        {
//            Console.WriteLine("Hallo!");
//        }
//    }

//    public class Program
//    {
//        public static void Main()
//        {
//            IAnimal animal = GetInstance();
//            //animal.Name = "Zergling";

//            //Animal instance = (Animal) animal;


//            DoIetsMetDeAnimal(animal);

//            Console.ReadLine();
//        }

//        private static IAnimal GetInstance()
//        {
//            return null;
//        }

//        private static void DoIetsMetDeAnimal(IAnimal animal)
//        {
//            animal.Speak();
//        }

//        public void PrintStars(object o)
//        {
//            if (o is null) return;     // constant pattern "null"

//            if (!(o is int i))
//            {
//                return; // type pattern "int i"
//            }

//            Console.WriteLine(new string('*', i));
//        }
//    }
//}
