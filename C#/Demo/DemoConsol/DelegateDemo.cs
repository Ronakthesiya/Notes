using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// this class is used to define the demo of delegate
    /// also cover the multicast delegate
    /// </summary>
    internal class DelegateDemo
    {

        public delegate void Print(string s);
        public void demo()
        {

            Print p = Console.WriteLine;
            p += (string s) => Console.WriteLine(s.ToUpper());
            p += (string s) => Console.WriteLine(s.ToLower());


            p("hello");
        }
    }
}
