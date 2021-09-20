using System;
using System.Collections.Generic;
using System.Linq;

namespace DistinctSubsequences
{
    public static class Solution
    {
        public static int NumDistinct(string s, string t)
        {
            // var searchStringValues = t
            //     .Select((value, index) => new KeyValuePair<char, int>(value, index + 1))
            //     .ToDictionary(a => a.Key, b => b.Value);
            var combinations = GetCombinations(s, t);
            return combinations;
            // var count = 0;
            //
            // foreach (var combination in combinations)
            // {
            //     if (combination.Contains(t))
            //     {
            //         count++;
            //     }
            // }
            //
            // return count;
        }

        private static int GetCombinations(IEnumerable<char> items, string t)
        {
            // var foundSets = new List<int[]>();
            //var foundSetDicts = new List<Dictionary<char, int>>();
            var foundSetDicts = new List<string>();
            var baseString = items.Where(a => t.Contains(a)).ToList();

            if (t.Length == 0 || baseString.Count == 0 || baseString.Count < t.Length)
            {
                return 0;
            }
            
            var size = Math.Pow(2, baseString.Count);
            
            // var foundSet = new int[items.Count()];
            // var foundSetDict = new Dictionary<char, int>();
            
            for (int counter = 1; counter < size; counter++)
            {
                var currentString = "";
                
                var binaryRepresentation = Convert.ToString(counter, 2)
                    .PadLeft(baseString.Count, '0');
                var binaryTooShort = binaryRepresentation.Length < t.Length;
                
                var countOfIncludedLetters = binaryRepresentation.Count(a => a == '1');
                var notEnoughIncludedLettersForMatch = countOfIncludedLetters < t.Length;

                if (binaryTooShort || notEnoughIncludedLettersForMatch)
                {
                    continue;
                }
                for (var bitIndex = 0; bitIndex < binaryRepresentation.Length; bitIndex++)
                {
                    var currentBit = binaryRepresentation[bitIndex];
                    var currentCharacter = baseString.ElementAt(bitIndex);
        
                    if (currentBit == '1')
                    {
                        
                        currentString += currentCharacter;
                        // var foundValues = foundSetDicts
                        //     .Where(dict => dict.ContainsKey(currentCharacter))
                        //     .FirstOrDefault(dict =>
                        //     {
                        //         dict.TryGetValue(currentCharacter, out var foundCharacterIndex);
                        //         return foundCharacterIndex == bitIndex;
                        //     });
                        //
                        // if (foundValues == null)
                        // {
                        //     currentString += currentCharacter;
                        // }
                    }
        
                    if (currentString.Contains(t))
                    {
                        // var vals = binaryRepresentation
                        //     .Select((val, index) => new KeyValuePair<char, int>(val, index))
                        //     .ToDictionary(d => d.Key, c => c.Value);
                        
                        foundSetDicts.Add(binaryRepresentation);
                    }
                }
        
                // if (!string.IsNullOrWhiteSpace(currentString))
                // {
                //     strings.Add(currentString);
                // }
                //
                // foundSet = new int[items.Count()];
            }

            var distinct = foundSetDicts.Distinct();
            var actual = foundSetDicts.Where(a => a.Count(b => b == '1') == t.Length);
            return actual.Distinct().Count();
        }

        // foreach (var item in items)
            // {
            //     var newCombinations = new List<string>();
            //
            //     foreach (var combination in combinations)
            //     {
            //         for (var i = 0; i <= combination.Length; i++)
            //         {
            //             newCombinations.Add(
            //                 combination.Substring(0, i) +
            //                 item +
            //                 combination.Substring(i));
            //         }
            //     }
            //
            //     combinations.AddRange(newCombinations);
            // }
            //
            // return combinations;

            // private static IEnumerable<string> GetCombinations(IEnumerable<char> items)
        // {
        //     var combinations = new List<string> {string.Empty};
        //
        //     foreach (var item in items)
        //     {
        //         var newCombinations = new List<string>();
        //
        //         foreach (var combination in combinations)
        //         {
        //             for (var i = 0; i <= combination.Length; i++)
        //             {
        //                 newCombinations.Add(
        //                     combination.Substring(0, i) +
        //                     item +
        //                     combination.Substring(i));
        //             }
        //         }
        //
        //         combinations.AddRange(newCombinations);
        //     }
        //
        //     return combinations;
        // }
    }
}