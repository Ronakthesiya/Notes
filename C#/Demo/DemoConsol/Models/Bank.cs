using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Models
{
    /// <summary>
    /// Bank class is used see the account details
    /// </summary>
    public class Bank
    {
        public void Display()
        {
            Console.WriteLine(BankAccount.AccountHolder);
            Console.WriteLine(BankAccount.Branch);
            Console.WriteLine(BankAccount.InterestRate);
        }
    }
}
