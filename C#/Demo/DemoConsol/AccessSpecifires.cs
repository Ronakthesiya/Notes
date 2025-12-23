using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    internal class AccessSpecifires
    {
        public void demo()
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.ShowBalance();
            Console.WriteLine();

            SavingsAccount savingsAccount = new SavingsAccount();
            savingsAccount.ShowDetails();
            Console.WriteLine();


            Bank bank = new Bank();
            bank.Display();
        }
    }

    public class BankAccount
    {
        public string AccountHolder = "Ronak Thesiya";
        private decimal Balance = 10000;
        protected string AccountNumber = "123123123123";
        internal string Branch = "ABCD";
        protected internal decimal InterestRate = 0.05m;
        private protected string InternalCode = "XYZ";

        public void ShowBalance()
        {
            Console.WriteLine($"Balance: {Balance}");
        }
    }

    public class SavingsAccount : BankAccount
    {
        public void ShowDetails()
        {
            Console.WriteLine(AccountHolder);
            Console.WriteLine(AccountNumber);
            Console.WriteLine(Branch);
            Console.WriteLine(InterestRate);
            Console.WriteLine(InternalCode);
        }
    }

    public class Bank
    {
        public void Display()
        {
            BankAccount account = new BankAccount();
            Console.WriteLine(account.AccountHolder);
            Console.WriteLine(account.Branch);
            Console.WriteLine(account.InterestRate);
        }
    }
}
