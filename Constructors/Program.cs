//cunstroctors are special methods 
//which gets involved while object creation

namespace Constructors
{
    #region non_static
    class NonStaticClass
    {
        private int _field1 = 0;
        private static int _static_field = 0;

        public int Field1
        {
            get
            {
                return this._field1;
            }
        }

        public static int StaticField
        {
            get
            {
                return _static_field;
            }
        }

        //default constructor if no 
        // parameterised constructor is added
        public NonStaticClass()
        {
            System.Console.WriteLine("Default constructor NonStaticClass");
            this._field1 += 1;
        }

        //parameterised constructor which accept one or more parameters
        public NonStaticClass(int val)
        {
            System.Console.WriteLine("Parameterised");
            this._field1 = val;
        }

        //copy constructor
        public NonStaticClass(NonStaticClass obj)
        {
            System.Console.WriteLine("Copy");
            this._field1 = obj._field1;
        }

        //static constructor is used to initilialise static field / properties
        //it can be part of static and non-static class
        //called only once
        //class when first object is created OR static member is accessed
        static NonStaticClass()
        {
            System.Console.WriteLine("Static constructor");
            _static_field = 1;
        }

        //private constructor - can only be called from within the class itself
        // use case 1: restricting object creation using new Class();
        // use case 2: object creation within class using public constructor or method
        private NonStaticClass(int x, int y)
        {
            System.Console.WriteLine("Private");
            this._field1 = x + y;
        }

        //calling private constructor using another public constructor
        //constructor chaining in same class
        public NonStaticClass(int x, int y, int z) : this(x, y)
        {
            System.Console.WriteLine("Private using other constructor");
            this._field1 = x + y + z;
        }

        public static NonStaticClass GetInstance(int a, int b)
        {

            //restruicting object creation from public method
            //useful in case of complex object creation is required
            System.Console.WriteLine("Private using other public method");
            return new NonStaticClass(a, b);
        }
    }

    class DerivedNonStaticClass : NonStaticClass
    {
        public DerivedNonStaticClass() : base()
        {
            //first base class constructor is called and then child class
            System.Console.WriteLine("Default constructor DerivedNonStaticClass");
        }
    }

    class Derived2NonStaticClass : DerivedNonStaticClass
    {
        //constructor chaining to base class
        public Derived2NonStaticClass() : base()
        {
            //first TOP PARENT class constructor is called and then followed to botton most constructor
            System.Console.WriteLine("Default constructor Derived2NonStaticClass");
        }
    }
    #endregion
    class Program
    {
        public static void Main(string[] args)
        {
            //default parameterless constructor is called
            NonStaticClass nonStaticClass = new NonStaticClass();
            System.Console.WriteLine(nonStaticClass.Field1);

            //Parameterised constructor call
            NonStaticClass nonStaticClass2 = new NonStaticClass(2);
            System.Console.WriteLine(nonStaticClass2.Field1);

            //Copy constructor call
            NonStaticClass nonStaticClass3 = new NonStaticClass(nonStaticClass2);
            System.Console.WriteLine(nonStaticClass3.Field1);

            //private constructor call
            //using public method
            NonStaticClass nonStaticClass4 = NonStaticClass.GetInstance(1, 2);
            System.Console.WriteLine(nonStaticClass4.Field1);
            //using public constructor
            NonStaticClass nonStaticClass5 = new NonStaticClass(1, 1, 2);
            System.Console.WriteLine(nonStaticClass5.Field1);

            //impact of inheritance on constructors
            Derived2NonStaticClass derived2NonStaticClass = new Derived2NonStaticClass();

            //static is actually called on first object creation
            System.Console.WriteLine(NonStaticClass.StaticField);

        }
    }
}

