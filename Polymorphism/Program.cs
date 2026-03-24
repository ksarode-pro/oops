/**
Polymorphism is same method behaves differently based in context
Two types: 
1. Runtime / Dynamic
2. Compile-time / static
    - same method anme; but different parameters (different datatype or number of params)
    - 
*/

namespace Polymorphism
{
    class StaticPolymorphism
    {
        // Same method name, different parameters
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public string Add(string a, string b)  // concatenation
        {
            return a + b;
        }

    }

    class Program
    {
        public static void Main(string[] args)
        {
            StaticPolymorphism staticPolymorphism = new StaticPolymorphism();
            System.Console.WriteLine(staticPolymorphism.Add(5, 5));
            System.Console.WriteLine(staticPolymorphism.Add(5, 5, 5));
            System.Console.WriteLine(staticPolymorphism.Add("5", "5 - This is string concatination of 5 and 5"));
        }
    }
}
