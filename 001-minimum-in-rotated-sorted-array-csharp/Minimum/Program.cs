using System;
using System.Collections.Generic;

namespace Minimum
{
    public class Program
    {
        static void Main()
        {
            var arrays = new List<int[]>();

            arrays.Add(new[] { 5, 6, 2, 3, 4 }); //2
            
            arrays.Add(new[] { 1 }); //1
            arrays.Add(new[] { 4, 5, 1, 2, 3 }); //1
            
            arrays.Add(new[] { 3, 4, 5, 1, 2 }); //1
            arrays.Add(new[] { 4, 5, 6, 7, 8, 0, 2 }); //0
            arrays.Add(new[] { 4, 5, 6, 7, 8, 1, 2 }); //1
            arrays.Add(new[] { 4, 5, 6, 7, 0, 1, 2 }); //0
            arrays.Add(new[] { 11, 13, 15, 17 }); //11

            foreach (var array in arrays)
            {
                //Console.WriteLine(RotatedSortedArray.FindMinimumValue(array));
                Console.WriteLine(RotatedSortedArray2.FindMinimumValue(array));
            }
        }
    }

	public static class RotatedSortedArray2
	{
        public static int FindMinimumValue(int[] ints)
        {
            var lowest = 99999;
            var left = 0;
            var right = ints.Length-1;

            // we check the middle, set it to lowest
            // then we check left and right of middle to see if < or >
            // if left is > than middle then we can ignore left since it would
            // necessarily be increasing to that point
            
            
            while (true)
            {
                // we get the mid point
                var middle = (left + right) / 2;
                // if midpoint is less than 
                if (ints[middle] < lowest)
                {
                    lowest = ints[middle];
                }

                // if we have nothing left to check we are done
                if (left == right || middle == left || middle == right)
                {
                    return lowest;
                }
                
                // if right of me is lower then it must be the lowest number since it would otherwise be increasing
                if (ints[middle + 1] < lowest)
                {
                    return ints[middle + 1];
                }
                
                // if the far right is lower than me then that must be where the lowest number is since
                // left of me would be increasing
                if (ints[right] < lowest)
                {
                    left = middle;
                    continue;
                }

                // if the number to my left is is greater than me then i must be the lowest number
                if (ints[middle - 1] > lowest)
                {
                    return lowest;
                }

                // all other checks failed so we must need to check the left side
                right = middle;
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