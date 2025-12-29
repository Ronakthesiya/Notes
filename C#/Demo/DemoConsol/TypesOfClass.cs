using DemoConsol.Interfaces;
using DemoConsol.Services;
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
}
