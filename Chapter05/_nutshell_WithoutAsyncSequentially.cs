using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05
{
    [Description("_1.1")]
    public static class _nutshell_WithoutAsyncSequentially
    {
        private static void Main()
        {
            DisplayPrimeCounts();
            Console.ReadLine();
        }

        // This one is not asynchronous
        public static void DisplayPrimeCounts()
        {
            DisplayPrimeCountsFrom(0);
        }

        // This one is.
        static void DisplayPrimeCountsFrom(int i)
        {
            var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter(); // non blocking operation, car la méthode GetPrimesCountAsync execute dans un autre thread.
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(awaiter.GetResult() + " primes between...");
                if (++i < 10) DisplayPrimeCountsFrom(i);
                else Console.WriteLine("Done");
            });
        }

        public static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
           ParallelEnumerable.Range(start, count).Count(n =>
         Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }
    }
}