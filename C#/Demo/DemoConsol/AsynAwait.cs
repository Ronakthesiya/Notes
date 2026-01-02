using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// this class is used to define hoe Async Await works in c#
    /// </summary>
    internal class AsynAwait
    {
        public void demo()
        {
            Console.WriteLine("Start");
            Stopfor1sec();
            Console.WriteLine("End");
            Console.ReadKey();
        }

        /// <summary>
        /// method to stop execution for 1 sec
        /// </summary>
        /// <returns></returns>
        public async Task Stopfor1sec()
        {
            await Task.Delay(10000);
            Console.WriteLine("Continue . . .");
        }
    }

}
