﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DistinctSubsequences
{
    public static class Solution
    {
        public static int NumDistinct(string s, string t)
        {
            var combinations = GetCombinations(s, t);
            return combinations;
        }

        private static int GetCombinations(IEnumerable<char> items, string t)
        {
            var foundSets = new List<string>();
            var baseString = items
                .Where(baseStringChar => t.Contains(baseStringChar))
                .ToList();

            if (t.Length == 0 || baseString.Count == 0 || baseString.Count < t.Length)
            {
                return 0;
            }
            
            var size = Math.Pow(2, baseString.Count);

            var iters = 0;
            for (int counter = t.Length; counter < size; counter++)
            {
                var currentString = "";
                
                var binaryRepresentation = Convert.ToString(counter, 2)
                    .PadLeft(baseString.Count, '0');

                var countOfIncludedLetters = binaryRepresentation.Count(a => a == '1');
                var incorrectIncludedLettersForMatch = countOfIncludedLetters != t.Length;

                if (incorrectIncludedLettersForMatch)
                {
                    continue;
                }

                var theCharactersWeAreLookingAt = binaryRepresentation
                    .Select((value, index) => value == '1' ? baseString[index] : ' ')
                    .Where(word => word != ' ');

                var theWordWeAreLookingAt = string.Join("", theCharactersWeAreLookingAt);
                if (theWordWeAreLookingAt.Contains(t))
                {
                    foundSets.Add(binaryRepresentation);
                }

                iters++;
                // if (theCharactersWeAreLookingAt.Distinct().Count() != t.Distinct().Count())
                // {
                //     continue;
                // }
                //
                // for (var bitIndex = 0; bitIndex < binaryRepresentation.Length; bitIndex++)
                // {
                //     var currentBit = binaryRepresentation[bitIndex];
                //
                //     if (currentBit == '0')
                //     {
                //         continue;
                //     }
                //     
                //     var currentCharacter = baseString.ElementAt(bitIndex);
                //     currentString += currentCharacter;
                //
                //     iters++;
                //     if (currentString.Length >= t.Length && currentString.Contains(t))
                //     {
                //         foundSets.Add(binaryRepresentation);
                //         break;
                //     }
                // }
            }

            return foundSets.Count;
        }
    }
}