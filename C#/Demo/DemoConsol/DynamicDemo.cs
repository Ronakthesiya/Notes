using DemoConsol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// this class get dynamic data from getRandomData method and 
    /// print it's value and datatype
    /// </summary>
    internal class DynamicDemo
    {
        public static void demo()
        {
            dynamic data = getRandomData();

            Console.WriteLine($"Value: {data}");
            Console.WriteLine($"Type: {data?.GetType()}");

            switch (data)
            {
                case int i:
                    Console.WriteLine($"Integer value: {i}");
                    break;

                case double d:
                    Console.WriteLine($"Double value: {d}");
                    break;

                case string s:
                    Console.WriteLine($"String length: {s.Length}");
                    break;

                case bool b:
                    Console.WriteLine($"Boolean value: {b}");
                    break;

                case DateTime dt:
                    Console.WriteLine($"Date: {dt:yyyy-MM-dd}");
                    break;

                case Emp e:
                    Console.WriteLine($"Employee Name: {e.Name}");
                    break;

                case List<int> numbers:
                    Console.WriteLine($"List Count: {numbers.Count}");
                    break;

                case int[] arr:
                    Console.WriteLine($"Array Length: {arr.Length}");
                    break;

                case Dictionary<string, int> dict:
                    Console.WriteLine("Dictionary values:");
                    foreach (var item in dict)
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    break;

                case null:
                    Console.WriteLine("Value is null");
                    break;

                default:
                    Console.WriteLine("Unknown type");
                    break;
            }
        }

        /// <summary>
        /// Method have list of different datatypes
        /// </summary>
        /// <returns>random datatype => dynamic</returns>
        public static dynamic getRandomData()
        {
            List<dynamic> list = new List<dynamic>
                    {
                        123,
                        99.5,
                        "Ronak",
                        true,
                        DateTime.Now,
                        new Emp { Name = "Ronak" },
                        new List<int> { 1, 2, 3, 4, 5 },
                        new int[] { 10, 20, 30 },
                        new Dictionary<string, int>
                        {
                            { "Math", 90 },
                            { "Science", 85 }
                        },
                        null
                    };

            Random random = new Random();
            return list[random.Next(list.Count)];
        }

    }
}
