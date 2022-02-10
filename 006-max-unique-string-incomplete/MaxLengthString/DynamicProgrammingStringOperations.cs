using System.Collections.Generic;
using System.Linq;
/*
 * This solution works for more cases and is more efficient but doesnt solve for all cases because it doesn't
 * simulate every possibility
 */

// namespace MaxLengthString
// {
//     public class DynamicProgrammingStringOperations : IStringOperations
//     {
//         public int GetMaxLengthUniqueString(IList<string> arr)
//         {
//             var results = new string[arr.Count];
//             
//             // on first pass we need to see if the initial strings have duplicates
//             for (int i = 0; i < arr.Count; i++)
//             {
//                 var duplicates = arr[i]
//                     .GroupBy(c => c)
//                     .Any(g => g.Count() > 1);
//                 
//                 if (duplicates)
//                 {
//                     results[i] = "";
//                 }
//                 else
//                 {
//                     results[i] = arr[i];
//                 }
//             }
//
//             for (int j = arr.Count - 1; j > 0; j--)
//             {
//                 var currentBiggestConcatString = results[j];
//                 
//                 for (int i = j - 1; i >= 0; i--)
//                 {
//                     var concatString = results[j] + arr[i];
//                     
//                     var noDuplicates = concatString
//                         .GroupBy(c => c)
//                         .All(c => c.Count() < 2);
//
//                     if (noDuplicates)
//                     {
//                         currentBiggestConcatString = concatString;
//                     }
//                 }
//
//                 results[j] = currentBiggestConcatString.Length > results[j].Length
//                     ? currentBiggestConcatString
//                     : results[j];
//             }
//
//             return results
//                 .OrderByDescending(s => s.Length)
//                 .First()
//                 .Length;
//         }
//     }
// }

namespace MaxLengthString
{
    public class DynamicProgrammingStringOperations : IStringOperations
    {
        public int GetMaxLengthUniqueString(IList<string> arr)
        {
            var results = new string[arr.Count];
            
            // on first pass we need to see if the string at j has duplicates
            for (int i = 0; i < arr.Count; i++)
            {
                var duplicates = arr[i]
                    .GroupBy(c => c)
                    .Any(g => g.Count() > 1);
                
                if (duplicates)
                {
                    results[i] = "";
                }
                else
                {
                    results[i] = arr[i];
                }
            }

            for (int i = arr.Count - 2; i >= 0; i--)
            {
                for (int j = arr.Count - 1; j > i; j--)
                {
                    // we set strings with duplicates to empty so we can skip them here
                    if (results[j].Length == 0)
                    {
                        continue;
                    }
                    
                    var concatString = arr[i] + results[j];
                    
                    var noDuplicates = concatString
                        .GroupBy(c => c)
                        .All(c => c.Count() < 2);

                    if (noDuplicates)
                    {
                        results[j] = concatString;
                    }
                }
            }

            return results
                .OrderByDescending(s => s.Length)
                .First()
                .Length;
        }
    }
}