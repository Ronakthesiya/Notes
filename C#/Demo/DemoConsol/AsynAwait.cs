using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    internal class AsynAwait
    {
        public void demo()
        {
            Console.WriteLine("Start");
            stopfor1sec();
            Console.WriteLine("End");
            Console.ReadKey();
        }

        public async Task stopfor1sec()
        {
            await Task.Delay(10000);
            Console.WriteLine("Continue . . .");
        }
    }

}
