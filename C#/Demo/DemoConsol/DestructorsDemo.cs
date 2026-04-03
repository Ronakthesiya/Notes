using DemoConsol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// destructure is used 
    /// and called by GC manualy
    /// </summary>
    public class DestructorsDemo
    {
        public void First()
        {
            Console.WriteLine("First start");

            Temp tmp = new Temp();

            Console.WriteLine("First end");
        }

        public void Sec()
        {
            Console.WriteLine("sec start");

            Temp tmp = new Temp();

            Console.WriteLine("sec end");
        }

        public void Demo()
        {
            Console.WriteLine("demo start");

            First();

            //GC.Collect();

            Sec();

            //GC.Collect();

            Console.WriteLine("demo end");
        }
    }

    
}
