using System;
using System.Linq;

Console.WriteLine(NumberOfInstancesInString("balloon", "lloo")); // 0
Console.WriteLine(NumberOfInstancesInString("balloon", "balloon7balloon")); // 2
Console.WriteLine(NumberOfInstancesInString("balloon", "balloon")); // 1
Console.WriteLine(NumberOfInstancesInString("balloon", "oonxysad75943fgdbaffdsfldsflg")); // 1
Console.WriteLine(NumberOfInstancesInString("balloon", "baballoonlbaballoonlballoonlooballoonnloon")); // 6
Console.WriteLine(NumberOfInstancesInString("balloon", "")); // 0

Console.WriteLine(NumberOfInstancesInString("aba", "bxxxaxxxaxxxaaxxxab")); // 2


int NumberOfInstancesInString(string searchParameter, string text)
{
    var letterCounts = searchParameter
        .GroupBy(character => character)
        .ToDictionary(k => k.Key, v => v.Count());
    
    // with the balloon example we are using we end up with the following dictionary:
    // var letterCounts = new Dictionary<char, int>
    // {
    //     {'b', 1},
    //     {'a', 1},
    //     {'l', 2},
    //     {'o', 2},
    //     {'n', 1},
    // };
    // where the key (e.g. 'l') is the character and the value (e.g. 2) is
    // the number of instances of that character in our search parameter

    var letterCollection = letterCounts.Keys;
    var letterGroupings = text
        .Where(character => letterCollection.Contains(character))
        .GroupBy(n => n);
    
    if (letterGroupings.Count() < letterCounts.Count)
    {
        return 0;
    }
	
    var instanceCount = int.MaxValue;
    
    foreach (var group in letterGroupings)
    {
        var instancesOfCharacter = group.Count();
        var requiredInstancesOfCharacter = letterCounts[group.Key];
        
        //integer division is always rounded down so this works to calculate the max available
        var numberOfWordsThisLetterCanMake = instancesOfCharacter / requiredInstancesOfCharacter;

        // if this letter can make less words than our current max then it limits the max words we can create
        if (numberOfWordsThisLetterCanMake < instanceCount)
        {
            instanceCount = numberOfWordsThisLetterCanMake;
        }
    }

    return instanceCount;
}
