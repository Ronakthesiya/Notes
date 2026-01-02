using DemoConsol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// This class if for demo of Access Specifiers, 
    /// covers all Access Specifires like public, private, protected, internal
    /// </summary>
    internal class AccessSpecifires 
    {
        /// <summary>
        /// method to access and check the use of access specifires
        /// </summary>
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
