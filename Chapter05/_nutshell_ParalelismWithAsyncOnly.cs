using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05
{
    // Mono Thread.
    [Description("_1.6")]
    class _nutshell_ParalelismWithAsyncOnly
    {
        private static void Main()
        {
            var tt = DisplayPrimeCounts();
           
           
            Console.ReadLine();
        }

        public static async Task<int> DisplayPrimeCounts()
        {
            GetPrimesCountAsync();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(i);
            }
            return 2;
        }

        public static async Task<int> GetPrimesCountAsync()
        {
            await Task.Delay(100);
            for (int i = 1000; i < 10000; i++)
            {
                Console.WriteLine(i);
            }

            return 3;
        }


    }
}