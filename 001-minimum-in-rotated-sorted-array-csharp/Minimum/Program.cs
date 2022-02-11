namespace Minimum
{
    public static class RotatedSortedArray2
	{
        public static int FindMinimumValue(int[] ints)
        {
            var lowest = 99999;
            var left = 0;
            var right = ints.Length-1;
            
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