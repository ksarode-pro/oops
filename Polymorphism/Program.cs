

using System.ComponentModel;


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
    #region Static Polymorphism
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
    #endregion

    #region Dynamic Polymorphism
    class DynamicPolymorphism_Base
    {
        //1. method signature should be same in both base and subclass. 
        //Number of parameters, type of each parameter and return type shold be exactly same.   
        // Else shows compile time error - no suitable method found to override

        //2. virtual keyword is important - 
        // compile time error : cannot override inherited member, 
        // because it is not marked virtual, abstract, or override
        public virtual int Add(int a, int b)
        {
            System.Console.WriteLine("Parent class method");
            return a + b;
        }
    }

    class DynamicPolymorphism_Sub : DynamicPolymorphism_Base
    {
        //1. override keyword is necessary for polymorphism
        //without override keyword, it hides base class implementation like new keyword
        //2. only warning is shown -  hides inherited member method. 
        // To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
        public override int Add(int a, int b)
        {
            System.Console.WriteLine("Subclass method");
            return a - b;
        }
    }
    #endregion

    class Program
    {
        public static void Main(string[] args)
        {
            StaticPolymorphism staticPolymorphism = new StaticPolymorphism();
            System.Console.WriteLine(staticPolymorphism.Add(5, 5));
            System.Console.WriteLine(staticPolymorphism.Add(5, 5, 5));
            System.Console.WriteLine(staticPolymorphism.Add("5", "5 - This is string concatination of 5 and 5"));

            DynamicPolymorphism_Base baseObj = new DynamicPolymorphism_Base();
            System.Console.WriteLine(baseObj.Add(5, 5));
            baseObj = new DynamicPolymorphism_Sub();
            System.Console.WriteLine(baseObj.Add(5, 5));
        }
    }
}
