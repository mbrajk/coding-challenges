using System.Linq;

namespace IntervalListIntersections;

public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        if (!firstList.Any() || !secondList.Any())
        {
            return new int[][] { };
        }

        var i = 0;
        var j = 0;
        while (firstList.Length < i && secondList.Length < j)
        {
            //this works similar to how we would compare two strings
            // if first is wholly smaller than second then we can increment
            // first because we know it has no overlap
            // else we can increment second
            
            //if there is overlap then we need to specifically figure out where and add it to our result set
        }

        return secondList;
    }
}