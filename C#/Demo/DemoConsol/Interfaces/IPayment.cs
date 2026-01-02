using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Interfaces
{
    /// <summary>
    /// Payment interface that provide Pay method to child classes
    /// </summary>
    public interface IPayment
    {
        void Pay(double amount);
    }

}
