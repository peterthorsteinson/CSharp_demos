using System;

namespace StaticMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount ba1 = new BankAccount();
            ba1.Deposit(1000);
            BankAccount ba2 = new BankAccount();
            ba2.Deposit(2000);

            BankAccount.SetInterestRate(0.03m);

            Console.WriteLine("{0:C}", ba1.Balance);
            ba1.AccrueInterest();
            Console.WriteLine("{0:C}", ba1.Balance);
        }
    }

    class BankAccount
    {
        private static decimal _interestRate;

        private decimal _balance;
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }

        public static void SetInterestRate(decimal interestRate)
        {
            _interestRate = interestRate;
        }
        public decimal Deposit(decimal amount)
        {
            _balance += amount;
            return _balance;
        }

        public void AccrueInterest()
        {
            _balance += _balance * BankAccount._interestRate;
        }
    }
}
