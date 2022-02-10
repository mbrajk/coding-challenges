using System;
using System.Collections.Generic;

namespace Minimum
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arrays = new List<int[]>();

            arrays.Add(new int[] { 5, 6, 2, 3, 4 }); //2
            
            arrays.Add(new int[] { 1 }); //1
            arrays.Add(new int[] { 4, 5, 1, 2, 3 }); //1

            arrays.Add(new int[] { 3, 4, 5, 1, 2 }); //1
            arrays.Add(new int[] { 4, 5, 6, 7, 8, 0, 2 }); //0
            arrays.Add(new int[] { 4, 5, 6, 7, 8, 1, 2 }); //1
            arrays.Add(new int[] { 4, 5, 6, 7, 0, 1, 2 }); //0
            arrays.Add(new int[] { 11, 13, 15, 17 }); //11

            foreach (var array in arrays)
            {
                Console.WriteLine(RotatedSortedArray.FindMinimumValue(array));
            }
        }
    }
    
    public static class RotatedSortedArray
    {
        public static int FindMinimumValue(int[] nums)
        {
            var lowestValue = int.MaxValue;

            var left = 0;
            var right = nums.Length - 1;

            while (right >= left)
            {
                var mid = left + ((right - left) / 2);
                var midValue = nums[mid];

                if (mid + 1 < nums.Length && mid - 1 >= left)
                {
                    if (nums[mid + 1] < midValue)
                    {
                        return nums[mid + 1];
                    }
                    
                    if (nums[mid - 1] > midValue)
                    {
                        return midValue;
                    }
                }

                if (nums[right] > midValue)
                {
                    lowestValue = midValue;
                    right = mid - 1;
                }
                else
                {
                    lowestValue = nums[right];
                    left = mid + 1;
                }
            }

            return lowestValue;
        }
    }
}