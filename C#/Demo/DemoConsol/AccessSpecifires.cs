using DemoConsol.Models;
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
            BankAccount.ShowBalance();
            Console.WriteLine();

            SavingsAccount savingsAccount = new SavingsAccount();
            savingsAccount.ShowDetails();
            Console.WriteLine();

            Bank bank = new Bank();
            bank.Display();
        }
    }
}
