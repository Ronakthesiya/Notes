using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    internal static class ExtensionMethod
    {
        public static bool isEmail(this string str)
        {
            return str.Contains("@") && str.Contains(".");
        }

        public static bool isEven(this int val)
        {
            return val % 2 == 0;
        }

        public static IEnumerable<string> joinOneByOne(this IEnumerable<string> list1, IEnumerable<string> list2)
        {
            var enum1 = list1.GetEnumerator();
            var enum2 = list2.GetEnumerator();

            while (enum1.MoveNext() && enum2.MoveNext())
            {
                yield return $"{enum1.Current} - {enum2.Current}";
            }
        }

        public static void demo()
        {
            Console.WriteLine("Enter two list to join ");

            string a = Console.ReadLine();  
            string b = Console.ReadLine();

            string[] list1 = a.Split(",");
            string[] list2 = b.Split(",");

            IEnumerable<string>? finalist = list1.joinOneByOne(list2);

            //list1[1] = "asdf";

            foreach (var item in finalist)
            {
                Console.WriteLine(item);
            }
        }
    }
}
