using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Services
{
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
}
