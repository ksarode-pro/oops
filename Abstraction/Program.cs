//Abstraction means hinding internal complexities of and showing only necessary features
//Can be achieved using ABSTRACT class and INTERFACES

using System.Diagnostics;

namespace Abstraction
{

    public interface IEmployee
    {
        //Interfaces cannot contain instance fields
        //public int employee; 

        // ALLOWED
        //public int MyProperty { get; set; }

        public void Display();
        public double GetSalary();
    }

    //Abstract class can implement Interface, 
    //method which we dont want to implement should be abstract
    abstract class Employee : IEmployee
    {
        //If const field not initialised - A const field requires a value to be provided. 
        protected const int MAN_DAYS = 30;
        protected int _employeeId;
        protected string? _name;
        protected string? _departmentName;

        public Employee(int empId, string name, string department)
        {
            this._employeeId = empId;
            this._name = name;
            this._departmentName = department;
        }

        public void Display()
        {
            System.Console.WriteLine($"EmployeeId: {this._employeeId}\nName: {this._name}\nDepartment: {this._departmentName}");
        }

        public abstract double GetSalary();
    }

    class FullTimeEmployee : Employee
    {
        private double _manDayRate;
        public FullTimeEmployee(int id, string name, string department, double mdRate) : base(id, name, department)
        {
            this._manDayRate = mdRate;
        }

        public override double GetSalary()
        {
            return MAN_DAYS * this._manDayRate;
        }
    }

    class ContractEmployee : Employee
    {
        private double _contractMDRate;
        public ContractEmployee(int id, string name, string department, double contractRate) : base(id, name, department)
        {
            this._contractMDRate = contractRate;
        }

        public override double GetSalary()
        {
            return MAN_DAYS * this._contractMDRate;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            IEmployee fullTimeEmployee = new FullTimeEmployee(1, "Kiran Sarode", "Technology", 15000);
            fullTimeEmployee.Display();
            System.Console.WriteLine("Salary: " + fullTimeEmployee.GetSalary());
            IEmployee contractor = new ContractEmployee(2, "John Doe", "Finance", 1000);
            contractor.Display();
            System.Console.WriteLine("Salary: " + contractor.GetSalary());
        }
    }
}