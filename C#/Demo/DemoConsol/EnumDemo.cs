using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    internal class EnumDemo
    {
        public enum enumOrderStatus
        {
            Pending = 1,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }

        // flaged enum
        [Flags]
        public enum enumAccess
        {
            Read = 1,
            Write = 2,
            Delete = 4,
            None = 8,
        }

        public void demo()
        {

            Console.WriteLine("Enter Order Status code (1-5)");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Current Status : ");
            Console.WriteLine((enumOrderStatus)n);

            Console.Write("Next Status : ");
            Console.WriteLine((enumOrderStatus)n + 1);

            //Console.WriteLine(enumOrderStatus.Shipped+2);

            Console.WriteLine("Enter Order Status (Pending, Processing, Shipped, Delivered, Cancelled)");
            string str = Console.ReadLine();

            Console.Write("Current Status : ");
            Console.WriteLine((int)Enum.Parse<enumOrderStatus>(str));


            enumAccess onlyread = enumAccess.Read;
            enumAccess onlywrite = enumAccess.Write;
            enumAccess onlydelete = enumAccess.Delete;
            enumAccess readwrite = onlyread | onlywrite;
            enumAccess readwritedelete = readwrite | onlydelete;
            enumAccess readdelete = onlyread | onlydelete;
            enumAccess none = enumAccess.None;

            Console.WriteLine("checking...");

            if ((readwritedelete & onlydelete) == onlydelete)
            {
                Console.WriteLine("delete accessed");
            }


        }
    }
}
