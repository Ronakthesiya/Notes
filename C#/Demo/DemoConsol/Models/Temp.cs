using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Models
{
    public class Temp
    {
        ~Temp()
        {
            Console.WriteLine("Destructor of Temp called...");
        }
    }
}
