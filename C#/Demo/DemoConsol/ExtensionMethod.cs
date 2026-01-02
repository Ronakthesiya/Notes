using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// class have demo of Extension Method
    /// three extension method is define for demo purpose
    /// </summary>
    internal static class ExtensionMethod
    {

        /// <summary>
        /// check whether the string is email or not
        /// </summary>
        /// <param name="str">take the string for extension method <param>
        /// <returns>boolean value true or false</returns>
        public static bool IsEmail(this string str)
        {
            return str.Contains("@") && str.Contains(".");
        }


        /// <summary>
        /// check whether the number is even or not
        /// </summary>
        /// <param name="val">takes the number to check</param>
        /// <returns>boolean value true or false</returns>
        public static bool IsEven(this int val)
        {
            return val % 2 == 0;
        }

        /// <summary>
        /// Method join to list index by index
        /// </summary>
        /// <param name="list1">list 1</param>
        /// <param name="list2">list 2</param>
        /// <returns>combined list</returns>
        public static IEnumerable<string> JoinOneByOne(this IEnumerable<string> list1, IEnumerable<string> list2)
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

            IEnumerable<string>? finalist = list1.JoinOneByOne(list2);

            //list1[1] = "asdf";

            foreach (var item in finalist)
            {
                Console.WriteLine(item);
            }
        }
    }
}
