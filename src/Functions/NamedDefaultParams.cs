namespace learning_c_sharp.Functions;

public class NamedDefaultParams
{
    static void PrintWithPrefix(string thestr, string prefix = "")
    {
        Console.WriteLine($"{prefix} {thestr}");
    }

    void Greet(string name = "friend", string greeting = "Hello")
    {
        Console.WriteLine($"{greeting}, {name}!");
    }

    Greet(greeting: "Good morning", name: "Alice");
    Greet(name: "Bob");
    Greet();
    
    // Named and Optional Parameters
    static void CalculateArea(double length = 1, double width = 1, bool isCircle = false)
    {
        double area;
        if (isCircle)
            area = Math.PI * length * length;
        else
            area = length * width;
        
        Console.WriteLine($"Area: {area}");
    }
}

void Call()
{
    NamedDefaultParams.CalculateArea(width: 5, length: 10);
    NamedDefaultParams.CalculateArea(isCircle: true, length: 3);
    CalculateArea();
}