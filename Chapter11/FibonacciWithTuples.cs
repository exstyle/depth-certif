using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter11
{
    class FibonacciWithTuples
    {
        static void Main()
        {
            foreach (var value in Fibonacci().Take(10))
            {
                Console.WriteLine(value);
            }
        }

        static IEnumerable<int> Fibonacci()
        {
            var pair = (current: 0, next: 1);
            while (true)
            {
                yield return pair.current;
                pair = (pair.next, pair.current + pair.next);
            }
        }
    }
}
