namespace DailyTemps
{
    public class Solution : ISolution
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            var resultArray = new int[temperatures.Length];

            // start from - 2 since the last item in the list will always be 0
            for (int i = temperatures.Length - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < temperatures.Length; j++)
                {
                    // check if the number to our right is > than us, if so we are done, if not we add
                    // resultarray [i+1] + 1 because we know since that number is smaller that we
                    // definitely wont find anything larger until at least that far
                    if (i + 1 < temperatures.Length && temperatures[j] <= temperatures[i])
                    {
                        var jumpTo = j + resultArray[i + 1];
                        if (jumpTo < temperatures.Length)
                        {
                            resultArray[i] = resultArray[i + 1];
                        }
                    }

                    // if we found a number greater than us, set the result.
                    // Otherwise we didn't and it is 0
                    if (temperatures[j] > temperatures[i])
                    {
                        resultArray[i] = j - i;
                        break;
                    }
                    else
                    {
                        resultArray[i] = 0;
                    }
                }
            }

            return resultArray;
        }
    }
}