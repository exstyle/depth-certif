using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05
{
    [Description("_1.4")]
    class _nutshell_WithAsync
    {
        private static void Main()
        {
            DisplayPrimeCounts();
            Console.ReadLine();
        }

        public static async Task DisplayPrimeCounts()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(await GetPrimesCountAsync(i * 1000000 + 2, 1000000) +
                " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
            Console.WriteLine("Done!");
        }

        public static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
           ParallelEnumerable.Range(start, count).Count(n =>
         Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }
    }
}