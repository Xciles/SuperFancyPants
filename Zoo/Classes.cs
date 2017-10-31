using System;

namespace Zoo
{
    public interface IAnimal
    {
        int Health { get; set; }
        int NumberOfLegs();
        void Speak();
    }

    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public abstract int NumberOfLegs();

        public virtual void Speak()
        {
            Console.WriteLine("Aaargh");
        }
    }

    public class Zergling : Animal
    {
        public override int NumberOfLegs()
        {
            return 6;
        }

        public override void Speak()
        {
            Console.WriteLine("Hoi!");
        }
    }
}
