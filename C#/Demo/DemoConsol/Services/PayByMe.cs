using DemoConsol.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Services
{
    /// <summary>
    /// abstract class implement Ipayment interfase
    /// </summary>
    public abstract class PayByMe : IPayment
    {
        public abstract void Pay(double amount);
    }
}
