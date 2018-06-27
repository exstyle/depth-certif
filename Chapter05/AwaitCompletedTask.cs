using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05
{
    [Description("Listing 5.3")]
    class AwaitCompletedTask
    {
        static void Main()
        {
            DisplayPrimeCounts();

            Console.ReadLine();

            //Task taskWithoutWaitOnIt = MethodWithoutWaiting();

            //for (int i = 8000; i < 10000; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //Task task = DemoCompletedAsync();
            //Console.WriteLine("Method returned");
            //// Safe in a console app - no synchronization context
            //task.Wait();
            //Console.WriteLine("Task completed");
        }


        static async Task MethodWithoutWaiting()
        {
            for (int i = 9000; i < 10000; i++)
            {
                Console.WriteLine(i);
            }
        }


        static async Task DemoCompletedAsync()
        {
            Task<int> task = OtherAsyncMethod();

            //var t = Task.Run(OtherAsyncMethod);
            for (int i = 10000; i < 10100; i++)
            {
                Console.WriteLine(i);
            }
            //await task;
            Console.WriteLine("Haha");

            Console.WriteLine("Before first await");
            await Task.FromResult(10);
            Console.WriteLine("Between awaits");
            await Task.Delay(1000);
            Console.WriteLine("After second await");
        }

        static async Task<int> OtherAsyncMethod()
        {
            Console.WriteLine("Yeah, first await");
            Task.Delay(5000);
            Console.WriteLine("Yeah,Between awaits");
            Task.Delay(5000);
            Console.WriteLine("Yeah,After second awaits");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }

            return 45;
        }

        public static void DisplayPrimeCounts()
        {
            for (int i = 0; i < 10; i++)
            {
                var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
                awaiter.OnCompleted(() =>   Console.WriteLine(awaiter.GetResult() + " primes between... "));
            }

            Console.WriteLine("Done");
        }

        public static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
           ParallelEnumerable.Range(start, count).Count(n =>
         Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

    }
}