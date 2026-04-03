using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Models
{
    
    /// <summary>
    /// provide demo of partial class
    /// </summary>
    public partial class Account
    {
        public string AccountHolder { get; set; }
        public decimal Balance { get; set; }

    }


    /// <summary>
    /// second part of the demo of partial class 
    /// </summary>
    public partial class Account
    {
        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"{amount} deposited. New Balance: {Balance}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }
            Balance -= amount;
            Console.WriteLine($"{amount} withdrawn. New Balance: {Balance}");
        }
    }

}
