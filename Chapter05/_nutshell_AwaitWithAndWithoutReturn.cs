using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05
{
    [Description("_1.5")]
    class _nutshell_AwaitWithAndWithoutReturn
    {
        private static void Main()
        {
            var tt = DisplayPrimeCounts();
            Console.WriteLine("It should returns 2, First comment though, am I ?");
            Console.WriteLine(tt.Result);
            var res = DontEvenBotherToHaveATaskDeclareSomeWhere().Result;
            Console.ReadLine();
        }

        public static async Task<int> DisplayPrimeCounts()
        {
            await GetPrimesCountAsync();
            Console.WriteLine("Though synchronously, i am 2, yet now i'm last...");
            return 2;
        }

        public static async Task<int> GetPrimesCountAsync()
        {
            await Task.Delay(500);
            Console.WriteLine("I would expect to be second. I'm still am, but its because i'm in the middle");
            return 3;
        }

        public static async Task<int> DontEvenBotherToHaveATaskDeclareSomeWhere()
        {
            return 3;
        }

    }
}