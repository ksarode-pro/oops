/*
    Inheritance is
    1. Child class creation by extending Parent class
    2. Reusability is main purpose
    3. In C#, one child can only have one parent class but it can implement multiple interfaces
*/

namespace Inheritance
{
    // BASE CLASS (Parent)
    public class Animal
    {
        public string Name;
        public int Age;

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }

        public virtual void MakeSound()  // virtual = can be overridden
        {
            Console.WriteLine($"{Name} makes a sound.");
        }
    }

    // DERIVED CLASS (Child)
    public class Dog : Animal
    {
        public string Breed;

        public Dog(string name, int age, string breed)
            : base(name, age)  // calling parent constructor
        {
            Breed = breed;
        }

        public override void MakeSound()  // overriding parent method
        {
            Console.WriteLine($"{Name} says: Woof! Woof!");
        }

        public void Fetch()
        {
            Console.WriteLine($"{Name} is fetching the ball!");
        }
    }

    // MULTI-LEVEL INHERITANCE
    //sealed keyword stops further inheritance
    public sealed class GuideDog : Dog//, Animal - Not allowed - Compile time error - Class cannot have multiple base classes
    {
        public string Owner;

        public GuideDog(string name, int age, string breed, string owner)
            : base(name, age, breed)
        {
            Owner = owner;
        }

        //sealed method cannot be further overrrid
        public sealed override void MakeSound()
        {
            //base keyword refers to parent class method or constructor
            base.MakeSound();  // calling parent's version
            Console.WriteLine("(Guide dog bark)");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog("Rex", 3, "Labrador");
            dog.Eat();          // Inherited from Animal
            dog.MakeSound();    // Overridden — "Rex says: Woof!"
            dog.Fetch();        // Own method

            Dog guideDog = new GuideDog("Tommy", 5, "Dobber Man", "Kiran");
            guideDog.Eat();
            guideDog.MakeSound();
            guideDog.Fetch();
        }
    }
}