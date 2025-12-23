using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    internal class EnumDemo
    {
        public enum OrderStatus
        {
            Pending = 1,    
            Processing, 
            Shipped,    
            Delivered,  
            Cancelled 
        }

        public void demo()
        {

            Console.WriteLine("Enter Order Status code (1-5)");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Current Status : ");
            Console.WriteLine((OrderStatus)n);

            Console.Write("Next Status : ");
            Console.WriteLine((OrderStatus)n+1);
            
            //Console.WriteLine(OrderStatus.Shipped+2);

            Console.WriteLine("Enter Order Status (Pending, Processing, Shipped, Delivered, Cancelled)");
            string str = Console.ReadLine();

            Console.Write("Current Status : ");
            Console.WriteLine((int)Enum.Parse<OrderStatus>(str));
        }
    }
}
