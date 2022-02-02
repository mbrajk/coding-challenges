
//Console.WriteLine("Starting coding interview");
//var strings = new List<string>
//{
//    "abcdefg",
//    "aacdefg",
//    "abcdefzz"
//};

//var waysToDoWork = new List<UniqueStrings>
//{
//    new UniqueStringsLinq(),
//    new UniqueStringsNoDs(),
//    new UniqueStringsDict(),
//};

//foreach (var str in strings)
//{
//    Console.WriteLine($"-- {str} --");
//    foreach(var wayToDoWork in waysToDoWork)
//    {
//        Console.WriteLine($"{wayToDoWork.GetType()}: {wayToDoWork.AllUnique(str)}");
//    }
//    Console.WriteLine();
//}

//Console.ReadKey();

//implement an algorithim to check if a string has all unique characters
public interface UniqueStrings
{
    bool AllUnique(string str);
}

public class UniqueStringsLinq : UniqueStrings
{
    public bool AllUnique(string str)
    {
        var grp = str.GroupBy(x => x);
        return grp.All(g => g.Count() < 2);
    }
}

public class UniqueStringsDict : UniqueStrings
{
    public bool AllUnique(string str)
    {
        // could pre-initialize to the alphabet
        var dict = new Dictionary<char, int>();

        foreach (var item in str)
        {
            if (dict.ContainsKey(item))
            {
                return false;
            }
            dict[item] = 1;
        }

        return true;
    }
}

public class UniqueStringsNoDs : UniqueStrings
{
    // no additional data structures allowed
    public bool AllUnique(string str)
    {
        for(int i = 0; i < str.Length; i++)
        {
            for(int j = i + 1; j < str.Length; j++)
            {
                if (str[i] == str[j])
                {
                    return false;
                }
            }
        }

        return true;
    }
}