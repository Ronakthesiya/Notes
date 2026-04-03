using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Models
{
    /// <summary>
    /// saving account is chiled class of bank account 
    /// for demo of access speciofires
    /// </summary>
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
}
