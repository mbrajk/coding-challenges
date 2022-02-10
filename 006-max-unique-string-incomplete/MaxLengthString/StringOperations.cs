using System.Collections.Generic;
using System.Linq;

namespace MaxLengthString
{
    public class StringOperations : IStringOperations
    {
        // this implementation works for all of the unit tests i have in this solution but doesn't
        // work with all of leetcode's tests. Additionally it is inefficient and builds more
        // answers than necessary
        public int GetMaxLengthUniqueString(IList<string> arr)
        {
            if (arr.Count == 0)
            {
                return 0;
            }
            
            if (arr.Count == 1)
            {
                return arr[0].Length;
            }

            arr = arr.Select(b =>
            {
                var grp = b.GroupBy(c => c);
                return grp.Any(g => g.Count() > 1) ? "" : b;
            }).ToArray();

            var biggestBois = arr.ToArray();
            
            for (int i = 1; i < arr.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var concatString = "";
                    
                    if (!biggestBois[j].Any(c => arr[i].Contains(c)))
                    {
                        concatString = biggestBois[j];
                    }
                    
                    else if (!arr[i].Any(c => arr[j].Contains(c)))
                    {
                        concatString = arr[j];
                    }
                    
                    biggestBois[j] = concatString + arr[i];
                }
            }
            return biggestBois.OrderByDescending(s => s.Length).First().Length;
        }
    }
}