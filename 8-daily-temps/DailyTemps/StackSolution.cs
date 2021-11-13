using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyTemps
{
    internal class StackSolution : ISolution
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            var results = new int[temperatures.Length];
            var stack = new Stack<int>();
            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                if (!stack.Any())
                {
                    results[i] = 0;
                }
                else
                {
                    while (stack.Any() && temperatures[stack.Peek()] <= temperatures[i])
                    {
                        var item = stack.Pop();
                    }
                    if (stack.Count == 0)
                    {
                        results[i] = 0;
                    }
                    else
                    {
                        results[i] = stack.Peek() - i;
                    }
                }

                stack.Push(i);
            }

            return results;
        }
    }
}
