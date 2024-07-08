using System;

namespace learning_c_sharp.Functions;

public class ReturningMultipleValues
{
    static void Main(string[] args)
    {
        (int a, int b) myTuple = (5, 10);
        var tupleDiverse = ("Some text", 10.5f);

        myTuple.b = 20;

        (int, int) result = PlusTimes(6, 12);
        Console.WriteLine($"{result.Item1}, {result.Item2}");
    }

    static (int, int) PlusTimes(int a, int b)
    {
        return (a + b, a * b);
    }
}