using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    public class Program
    {
        public string Name { get; set; }

        //public static async Task Main()
        //{

        //}

        public static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        private static async Task MainAsync()
        {

            // Commentertaar
            Console.WriteLine("Hello World!");

            //Thread;
            //ThreadPool;
            //TaskScheduler;

            //Thread thread = new Thread(new ParameterizedThreadStart(BackgroundWork));
            //thread.Start();

            //ThreadPool.QueueUserWorkItem(BackgroundWork);
            //ThreadPool.QueueUserWorkItem(BackgroundWork);

            //Task.Factory.StartNew(() => BackgroundWork());

            await AsyncMethod();
            await AsyncMethod();
            await AsyncMethod();
            await AsyncMethod();
            await AsyncMethod();

            var t1 = AsyncMethod();
            var t2 = AsyncMethod();
            var t3 = AsyncMethod();
            var t4 = AsyncMethod();
            var t5 = AsyncMethod();

            await Task.WhenAny(t1, t2, t3, t4, t5);
            await Task.WhenAll(t1, t2, t3, t4, t5);


            var result = await AsyncResultMethod();
            var task = AsyncResultMethod();

            await task;
            var tResult = task.Result;

            var tR1 = AsyncResultMethod();
            var tR2 = AsyncResultMethod();
            var tR3 = AsyncResultMethod();
            var tR4 = AsyncResultMethod();
            var tR5 = AsyncResultMethod();
            await Task.WhenAll(tR1, tR2, tR3, tR4, tR5);
            

            Console.ReadLine();
        }

        private static async Task AsyncMethod()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://www.google.com");

            }
        }

        private static async Task<string> AsyncResultMethod()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://www.google.com");

                return result;
            }
        }

        private static void BackgroundWork()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hallo" + 1);

                Thread.Sleep(500);
            }
        }

        private static void BackgroundWork(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hallo" + 1);

                Thread.Sleep(500);
            }
        }
    }
}
