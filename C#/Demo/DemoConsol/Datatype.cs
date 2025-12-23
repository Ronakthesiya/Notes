using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
     class Datatype
    {

        enum temp { red, blue, pink };

        struct emp
        {
            public int ID;
            public string Name;
            public double Salary;
        }

         public static void Data() {
            //Value type
            int a = 1;
            byte b = 2;
            short c = 3;
            long d = 4;

            double e = 5;
            decimal f = 6;
            float g = 7;

            char h = 'c';

            bool i = false;

            

            //Reference type

            Object obj = 10;

            dynamic val = "dsaf";
            //val = obj;

            string msg = "asdf";
            int[] arr = { 1, 2, 3, 4, 5, 6 };


        }

    }
}
