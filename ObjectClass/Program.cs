//Object is the top level class for all types.
// Every class in C# inherits from System.Object automatically
using System.Runtime.InteropServices;

public class Student  // implicitly : Object
{
    public string? Name;
    public int Roll;

    // Override ToString() from Object
    public override string ToString()
    {
        return $"Student[{Roll}]: {Name}";
    }

    // Override Equals() from Object
    public override bool Equals(object? obj)
    {
        if (obj is Student s)
            return Roll == s.Roll;
        return false;
    }

    // Override GetHashCode() — always override when you override Equals
    public override int GetHashCode() => Roll.GetHashCode();
}


/*
IMPORTANT!

object? (Reference)
This is a nullable reference type. object already refers to an object, and ? tells the compiler null is allowed.

int? (Value)
This is shorthand for Nullable<int>. It changes a value type into one that can also store null.
*/

class Program
{
    public static void Main(string[] args)
    {
        Student student = new Student()
        {
            Name = "Kiran Sarode",
            Roll = 1
        };

        System.Console.WriteLine(student.ToString());
        System.Console.WriteLine(student.GetHashCode());
        System.Console.WriteLine(student.Equals(student));
        System.Console.WriteLine(student.GetHashCode());
        System.Console.WriteLine(student.GetType());
    }
}