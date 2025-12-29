using DemoConsol.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Services
{
    public abstract class PayByMe : IPayment
    {
        public abstract void Pay(double amount);
    }
}
