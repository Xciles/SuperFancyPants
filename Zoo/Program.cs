using System;
using System.Collections.Generic;
using System.IO;

namespace Zoo
{
    public class GenericList<T>
        where T : class
    {
        private class Node
        {
            public Node(T i)
            {
                Data = i;
            }

            public T Data { get; set; }
            public Node Next { get; set; }
        }

        private Node _head = null;

        public GenericList()
        {
        }

        public void AddNode(T x)
        {
            var node = new Node(x);
            node.Next = _head;
            _head = node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node begin = _head;

            while (begin != null)
            {
                yield return begin.Data;
                begin = begin.Next;
            }
        }

        public T this[int x]
        {
            get
            {
                var current = _head;
                for (int i = 0; i < x; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                var current = _head;
                for (int i = 0; i < x; i++)
                {
                    current = current.Next;
                }

                var node = new Node(value);
                node.Next = current;
                current.Next = node;
            }
        }
    }

    public class Person
    {
        private int _age;
        public string Name { get; set; }
        public string Function { get; set; }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public void SetAge(int value)
        {
            _age = value;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var personList = new GenericList<Person>();

            personList.AddNode(new Person() { Age = 10, Function = "SPelen", Name = "Robbert" });
            personList.AddNode(new Person() { Age = 20, Function = "Typen", Name = "Hans" });
            personList.AddNode(new Person() { Age = 30, Function = "Iets", Name = "Rick" });
            personList.AddNode(new Person() { Age = 10, Function = "SPelen", Name = "Robbert" });
            personList.AddNode(new Person() { Age = 20, Function = "Typen", Name = "Hans" });
            personList.AddNode(new Person() { Age = 30, Function = "Iets", Name = "Rick" });
            personList.AddNode(new Person() { Age = 10, Function = "SPelen", Name = "Robbert" });
            personList.AddNode(new Person() { Age = 20, Function = "Typen", Name = "Hans" });
            personList.AddNode(new Person() { Age = 30, Function = "Iets", Name = "Rick" });

            personList[3] = new Person();

            foreach (var person in personList)
            {
                break;
            }

            var list = new List<int>();


            foreach (var i in list)
            {

            }

            Console.ReadLine();

        }
    }

}


//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//namespace Zoo
//{
//    public class Help : IComparable
//    {
//        public string Name { get; set; }
//        public int Age { get; set; }

//        public int CompareTo(object obj)
//        {
//            return 1;
//        }
//    }

//    public class HelpComparer : IComparer<Help>
//    {
//        public int Compare(Help x, Help y)
//        {
//            return 1;
//        }
//    }

//    public class Program
//    {


//        public static void Main()
//        {
//            IList<string> stringList = new List<string>();

//            stringList.Add("String 1");
//            stringList.Add("String 2");

//            IList<int> listiNsts = new List<int>();

//            string[] stringArray = new string[] { "String 1", "String 2" };

//            SortedDictionary<int, string> sortedDict = new SortedDictionary<int, string>();

//            sortedDict.Add(1, "Hallo");
//            sortedDict[1] = "Hallo";

//            SortedDictionary<Help, string> helpSortedDictionary = new SortedDictionary<Help, string>(new HelpComparer());

//            helpSortedDictionary.Add(new Help { Name = "Hans", Age = 30 }, "Hallo");
//            helpSortedDictionary.Add(new Help { Name = "Rick", Age = 30 }, "Hallo");

//            Dictionary<int, string> dict = new Dictionary<int, string>();

//            dict[1] = "Hallo";
//            dict[2] = "Hoi";

//            dict.Add(3, "hallo");

//            var dictResult1 = dict[1];
//            if (dict.TryGetValue(1, out string dictResult))
//            {

//            }

//            HashSet<string> set = new HashSet<string>();


//            Queue queue = new Queue();

//            queue.Enqueue("hallo 1");
//            queue.Enqueue("hallo 2");
//            queue.Enqueue("hallo 3");
//            queue.Enqueue("hallo 4");

//            var result = queue.Dequeue();

//            Stack stack = new Stack();

//            stack.Push("hallo 1");
//            stack.Push("hallo 2");
//            stack.Push("hallo 13");
//            stack.Push("hallo 14");

//            var stackResult = stack.Pop();

//            LinkedList<string> linkedList = new LinkedList<string>();
//            linkedList.AddLast("Hallo 1");
//            linkedList.AddLast("Hallo 2");
//            linkedList.AddLast("Hallo 3");
//            linkedList.AddLast("Hallo 4");
//            linkedList.AddLast("Hallo 5");


//            var input = Convert.ToInt32(Console.ReadLine());

//            Console.WriteLine("Add: {0} = {1}", input, Add(input));



//            //ArrayList arrayList = new ArrayList();
//            //arrayList.Add(1);
//            //arrayList.Add("string");

//            //CustomList<string>



//            Console.WriteLine("Done");
//            Console.ReadLine();
//        }


//        private static int Add(int x)
//        {
//            if (x <= 1) return 1;

//            return x + Add(x - 1);
//        }
//    }
//}





//#region Gen


////using System;
////using System.Collections.Generic;

////namespace Zoo
////{
////    public class GenericList<T>
////    {
////        private class Node
////        {
////            public Node(T t)
////            {
////                Next = null;
////                Data = t;
////            }

////            public Node Next { get; set; }

////            public T Data { get; set; }
////        }

////        private Node head;

////        public GenericList()
////        {
////            head = null;
////        }

////        public void AddHead(T t)
////        {
////            Node n = new Node(t);
////            n.Next = head;
////            head = n;
////        }

////        public T this[int i]
////        {
////            get
////            {
////                var current = head;
////                for (int j = 0; j < i; j++)
////                {
////                    current = current.Next;
////                }
////                return current.Data;
////            }
////            set
////            {
////                var current = head;
////                for (int j = 0; j < i; j++)
////                {
////                    current = current.Next;
////                }

////                Node n = new Node(value);

////                n.Next = current;
////                current.Next = n;
////            }
////        }

////        public IEnumerator<T> GetEnumerator()
////        {
////            Node current = head;

////            while (current != null)
////            {
////                yield return current.Data;
////                current = current.Next;
////            }
////        }
////    }

////    public class Program
////    {
////        public static void Main()
////        {
////            GenericList<int> list = new GenericList<int>();

////            for (int x = 0; x < 10; x++)
////            {
////                list.AddHead(x);
////            }

////            foreach (int i in list)
////            {
////                Console.Write(i + " ");
////            }
////            Console.WriteLine("\nDone");
////            Console.ReadLine();
////        }
////    }
////}

//#endregion

//#region Add

////using System;

////namespace zoo
////{
////    public class Program
////    {
////        private static int Add(int x)
////        {
////            if (x <= 1) return 1;

////            return x + Add(x - 1);
////        }

////        public static void Main(string[] args)
////        {
////            Console.WriteLine("Add: {0}", Add(5));


////            Console.ReadKey();
////        }
////    }
////}

//#endregion

//#region Zoo

////using System;
////using System.Collections.Generic;
////using System.Diagnostics;
////using System.Linq;

////namespace Zoo
////{


////    class Program
////    {
////        static void Main(string[] args)
////        {
////            IAnimal zergling = new Zergling();

////            zergling.NumberOfLegs();
////            zergling.Speak();

////            var zerglings = new List<Zergling>()
////            {
////                new Zergling()
////                {
////                    Name = "zerlings 1",
////                    Health = 100
////                },
////                new Zergling()
////                {
////                    Name = "zerlings 2",
////                    Health = 100
////                },
////                new Zergling()
////                {
////                    Name = "zerlings 3",
////                    Health = 100
////                },
////                new Zergling()
////                {
////                    Name = "zerlings 11",
////                    Health = 100
////                },
////                new Zergling()
////                {
////                    Name = "zerlings 11",
////                    Health = 100
////                },
////                new Zergling()
////                {
////                    Name = "zerlings 11",
////                    Health = 100
////                },
////                new Zergling()
////                {
////                    Name = "zerlings 11",
////                    Health = 100
////                },
////                new Zergling()
////                {
////                    Name = "zerlings 11",
////                    Health = 100
////                },
////                new Zergling()
////                {
////                    Name = "zerlings 12",
////                    Health = 100
////                },
////                new Zergling()
////                {
////                    Name = "zerlings 13",
////                    Health = 100
////                },
////                new Zergling()
////                {
////                    Name = "zerlings 22",
////                    Health = 100
////                }
////            };

////            for (int j = 0; j < 10; j++)
////            {
////                Console.WriteLine($"Iteration: {j}");

////                Stopwatch watch = new Stopwatch();

////                watch.Start();
////                for (int i = 0; i < 10_000_000; i++)
////                {
////                    var lings1 = zerglings.Where(x => x.Name == "zerlings 1").First();
////                    lings1.Health++;
////                }
////                watch.Stop();

////                var lingsWhereElapsed = watch.ElapsedMilliseconds;

////                watch.Reset();
////                watch.Start();

////                for (int i = 0; i < 100_000_00; i++)
////                {
////                    var lings1 = zerglings.First(x => x.Name == "zerlings 1");
////                    lings1.Health++;
////                }
////                watch.Stop();

////                var lingsFirstElapsed = watch.ElapsedMilliseconds;

////                Console.WriteLine($"Where: {lingsWhereElapsed}");
////                Console.WriteLine($"First: {lingsFirstElapsed}");
////            }

////            //var lings1 = zerglings.Where(x => x.Name.Contains("1")).First();
////            //var lings2 = zerglings.First(x => x.Name.Contains("1"));


////            var aa = zerglings.Where(x => x.Name.Contains("1")).ToList();


////            Console.WriteLine("Hello World!");
////            Console.ReadKey();
////        }
////    }
////}


//#endregion