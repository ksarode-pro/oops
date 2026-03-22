//Encapsulation is 
//1. wrapping data and methods/behaviour inside class
//2. hinding internal data outside of class using ACCESS MODIFIRES
//3. exposing and manipulating internal data using properties and public methods

namespace Encapsulation
{
    class BankAccount
    {
        // PRIVATE FIELDS — hidden outside class
        #region access_modifiers_reference
        /*
        Modifier                Accessible From
        public                  Anywhere
        private                 Same class only
        protected               Same class + derived classes
        internal                Same assembly (project)
        protected internal      Same assembly OR derived class
        private protected       Same class + derived class in same assembly
        */
        #endregion
        private double _balance;
        private string _accountNumber;

        public BankAccount(string accountNo, double initialBalance = 0)
        {
            this._accountNumber = accountNo;
            this._balance = initialBalance;
        }

        // PROPERTIES - controlled access to private fields
        public double Balance
        {
            get { return this._balance; }
            private set { this._balance = value; }
        }

        public string AccountNumber
        {
            get { return this._accountNumber; }
        }

        //PUBLIC METHODS to manipulate internal private fields
        public void Deposite(double amount)
        {
            if (amount < 1)
            {
                throw new ArgumentException("Deposite failed: Invalid data");
            }
            this._balance += amount;
            System.Console.WriteLine($"INR {amount} deposited in account {AccountNumber}. Updated balance is INR {this._balance}.");
        }

        public void Withdraw(double amount)
        {
            if (amount < 1)
            {
                throw new ArgumentException("Withdraw failed: Invalid data");
            }

            if (amount > Balance)
            {
                throw new ArgumentException("Withdraw failed: Insufficient funds");
            }
            this._balance -= amount;
            System.Console.WriteLine($"INR {amount} withdrawn from account {AccountNumber}. Updated balance is INR {this._balance}.");
        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            BankAccount account = new BankAccount("ACC001971");
            account.Deposite(500);
            account.Deposite(1500);
            account.Withdraw(1000);
            account.Withdraw(200);
            System.Console.WriteLine("Final Balance of Account : " + account.AccountNumber + " is INR " + account.Balance);
            account.Withdraw(2000);

        }
    }
}