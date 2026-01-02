using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// define different types of lambda expression
    /// give a demo of lambda expression
    /// </summary>
    internal class LambdaExp
    {
        public static void demo()
        {
            Console.WriteLine("Lamda demo");

            // a+" "+b
            Func<int ,int ,string> ConcateInt = (a,b) => a + " " + b;

            // a*b + c
            Func<int, int, int, int> multiplyAndAdd = (a, b, c) =>
            {
                int product = a * b;
                return product + c;
            };


            Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
            greet("Ronak"); 


            Console.WriteLine(multiplyAndAdd(2, 3, 5)); 


            int factor = 3;
            Func<int, int> multiply = x => x * factor;


            Func<Task> asyncLambda = async () =>
            {
                await Task.Delay(1000);
                Console.WriteLine("Finished after 1 second!");
            };

        }
    }
}
