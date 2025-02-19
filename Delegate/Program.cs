using static Delegate.Program;

namespace Delegate;

internal class Program
{
    public delegate void Print();
    static void Main(string[] args)
    {
        Func<int, double, double> func1 = CalculateCircle;
        Console.WriteLine($"Area of circle : {CalculateCircle(5, 3.14)}");
        Func<int, int, int> func2 = CalculateRectangle;
        Console.WriteLine($"Area of rectangle : {CalculateRectangle(5, 10)}");
        Func<int, int, int,int> func3 = CalculateTriangle;
        Console.WriteLine($"Area of triangle : {CalculateTriangle(5, 10, 3)}");
        Print print = Print1;
        print += Print2;
        print += Print3;
        Console.WriteLine(new string('-',30));
        print.Invoke();
        Console.WriteLine(new string('-',30));
        List<Developer> developers = [new("Ahmad", 1200), new("Tural", 1500)];           
        Console.WriteLine(developers.MyIndex(d => d.Salary == 1200));
       
    }
    public static double CalculateCircle(int r, double p)
    {
        return r * r * p;
    }
    public static int CalculateRectangle(int w, int l)
    {
        return w * l;
    }
    public static int CalculateTriangle(int a, int b, int c)
    {
        return a * b * c;
    }
    public static void Print1()
    {
        Console.Write("Hello");
    }
    public static void Print2()
    {
        Console.Write(" my");
    }
    public static void Print3()
    {
        Console.Write(" friend");
    }
}

public static class ExtentionMethods
{
    public static int MyIndex(this List<Developer> developers, Func<Developer, bool> predicate)
    {
        for (int i = 0; i < developers.Count; i++)
        {
            if (predicate(developers[i]))
            {
                return i;
            }
        }
        return -1;
    }
}

public class Developer
{
    public Developer(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }
    public string Name { get; set; }
    public double Salary { get; set; }
}
