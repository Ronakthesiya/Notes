using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Services
{
    // Sealed Class

    sealed class PaymentValidator
    {
        public static bool Validate(double amount)
        {
            return amount > 0 && amount <= 100000;
        }
    }
}
