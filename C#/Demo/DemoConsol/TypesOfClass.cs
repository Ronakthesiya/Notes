using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    internal class TypesOfClass
    {
        public static void demo()
        {
            IPayment payment = new UpiPayment();
            payment.Pay(500);

            payment = new CashPayment();
            payment.Pay(500);

        }
    }


    // Partial class

    // in Account details File
    public partial class Account
    {
        public string AccountHolder { get; set; }
        public decimal Balance { get; set; }

    }


    // in Account method File
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




    // Sealed Class

    sealed class PaymentValidator
    {
        public static bool Validate(double amount)
        {
            return amount > 0 && amount <= 100000;
        }
    }



    // Interface Demo + Abstract Class
    public interface IPayment
    {
        void Pay(double amount);
    }

    public abstract class PayByMe : IPayment
    {
        public abstract void Pay(double amount);
    }

    public class UpiPayment : PayByMe
    {
        public override void Pay(double amount)
        {
            if (PaymentValidator.Validate(amount))
            {
                Console.WriteLine($"Paid {amount} using UPI");
            }
            else
            {
                Console.WriteLine("Amount is not valid");
            }
        }
    }

    public class CashPayment : PayByMe
    {
        public override void Pay(double amount)
        {
            if (PaymentValidator.Validate(amount))
            {
                Console.WriteLine($"Paid {amount} using Cash");
            }
            else
            {
                Console.WriteLine("Amount is not valid");
            }
        }
    }

}
