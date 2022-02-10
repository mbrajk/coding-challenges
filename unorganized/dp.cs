
Console.WriteLine("Starting coding interview");

var a = Fib2(10); //55

int Fib(int n)
{
    var dicto = new Dictionary<int, int>();
    if (n <= 2)
    {
        return 1; 
    }

    if (dicto.ContainsKey(n))
    {
        return dicto[n];
    }

    var result = Fib(n - 1) + Fib(n - 2);
    dicto[n] = result;
    return result;
}

int Fib2(int n)
{
    var oneAgo = 1;
    var twoAgo = 1;
    
    foreach(var x in Enumerable.Range(1, n))
    {
        if (x <= 2)
        {
            continue;
        }

        var now = oneAgo + twoAgo;
        twoAgo = oneAgo;
        oneAgo = now;
    }

    return oneAgo;
}

Console.WriteLine(a);
Console.ReadKey();