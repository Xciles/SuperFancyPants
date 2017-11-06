using System;
using System.Collections.Generic;

namespace ExceptionDemo
{
    public class Room
    {
        private IList<Chest> _chests;

        public Room()
        {
            _chests = new List<Chest>();
        }

        public void SetItems()
        {
            _chests.Add(new Chest() { NumberOfItems = 3 });
            _chests.Add(new Chest() { NumberOfItems = 2 });
            _chests.Add(new Chest());
            _chests.Add(new Chest() { NumberOfItems = 1 });
        }

        public void PrintItemValue(int totalValue)
        {
            Console.WriteLine($"We have {_chests.Count} chests, printing value per item per chest");

            foreach (var chest in _chests)
            {
                var value = Calculator.Caculate(totalValue, chest.NumberOfItems);
                Console.WriteLine($"Value per item in chest: {value}");
            }
        }
    }
}