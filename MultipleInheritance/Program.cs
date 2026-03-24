/*
Why C# does not support multiple inheritance
The core problem: The Diamond Problem
Imagine class A has a method called Show(). 
Class B and class C both inherit from A and both override Show(). 
Now class D tries to inherit from both B and C. 
When you call Show() on an object of D, the compiler gets confused — which version of Show() should it use? B's or C's? This ambiguity is called the Diamond Problem.

C# designers made a deliberate decision: no multiple inheritance of classes. This keeps the language simple, predictable, and free of ambiguity.
*/


/*
C# solves this using interfaces. 
You can implement multiple interfaces on a single class — interfaces have no method bodies (in the traditional sense), 
so there's no ambiguity about which implementation to pick.
*/
interface IFlyable
{
    void Fly();
}

interface ISwimmable
{
    void Swim();
}

// A Duck can fly AND swim — no diamond problem!
class Duck : IFlyable, ISwimmable
{
    public void Fly() => Console.WriteLine("Duck is flying!");
    public void Swim() => Console.WriteLine("Duck is swimming!");
}

class Program
{
    public static void Main(string[] args)
    {
        Duck d = new Duck();
        d.Fly();
        d.Swim();
    }
}


