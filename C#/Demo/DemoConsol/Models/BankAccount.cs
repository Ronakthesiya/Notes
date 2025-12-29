using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Models
{
    public class BankAccount
    {
        public static string AccountHolder = "Ronak Thesiya";
        private static decimal Balance = 10000;
        protected static string AccountNumber = "123123123123";
        internal static string Branch = "ABCD";
        protected static internal decimal InterestRate = 0.05m;
        private static protected string InternalCode = "XYZ";

        public static void ShowBalance()
        {
            Console.WriteLine($"Balance: {Balance}");
        }
    }
}
