using System.Collections.Generic;
using System.Linq;

namespace MaxLengthString
{
    public class RecursiveStringOperations : IStringOperations
    {
        public int GetMaxLengthUniqueString(IList<string> arr)
        {
            int[] a = {0};
            
            MaxString(arr, "", 0, a);
            
            return a[0];
        }

        private void MaxString(IList<string> arr, string currentString, int index, IList<int> result)
        {
            if (index == arr.Count) 
            {
                if (CharacterCount(currentString) > result[0])
                {
                    result[0] = CharacterCount(currentString);
                }
                
                return;
            }

            MaxString(arr, currentString, index + 1, result);
            MaxString(arr, currentString + arr[index], index + 1, result);
        }
        
        private int CharacterCount(string s)
        {
            var hasDuplicates = s
                     .GroupBy(c => c)
                     .Any(g => g.Count() > 1);
                 
            return hasDuplicates ? 0 : s.Length;
        }
    }
}