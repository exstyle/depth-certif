using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05
{
    [Description("Listing 5.3. NutShell")]
    class _nutshell_WithoutAsync
    {
        private static void Main()
        {
            DisplayPrimeCounts();
            Console.ReadLine();
        }

        public static void DisplayPrimeCounts()
        {
            for (int i = 0; i < 10; i++)
            {
                var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
                awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult() + " primes between... "));
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