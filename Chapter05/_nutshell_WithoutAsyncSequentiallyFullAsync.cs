using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05
{
    [Description("_1.2")]
    public static class _nutshell_WithoutAsyncSequentiallyFullAsync
    {
        private static void Main()
        {
            DisplayPrimeCountsAsync();
            Console.WriteLine("Fin du programme");
            Console.ReadLine();
        }

        /// <summary>
        /// Cette méthode est asynchrone, au sens ou elle renvoi une tache, et où le code de l'opération est réalisé après, pour partie, le retour.
        /// </summary>
        /// <returns></returns>
        static Task DisplayPrimeCountsAsync()
        {
            var machine = new PrimesStateMachine();
            machine.DisplayPrimeCountsFrom(0);
            return machine.Task;
        }

        class PrimesStateMachine
        {
            TaskCompletionSource<object> _tcs = new TaskCompletionSource<object>();
            public Task Task { get { return _tcs.Task; } }
            public void DisplayPrimeCountsFrom(int i)

            {
                var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
                awaiter.OnCompleted(() =>
                {
                    Console.WriteLine(awaiter.GetResult());
                    if (++i < 10) DisplayPrimeCountsFrom(i);
                    else { Console.WriteLine("Done"); _tcs.SetResult(null); }
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

}