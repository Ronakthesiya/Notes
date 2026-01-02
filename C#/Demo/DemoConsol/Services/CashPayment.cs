using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Services
{
    /// <summary>
    /// implement paybyme class
    /// payment done by cash
    /// </summary>
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
