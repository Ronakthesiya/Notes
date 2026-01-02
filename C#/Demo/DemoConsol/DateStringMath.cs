using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// this class used all important methods of date, string, math classes
    /// </summary>
    internal class DateStringMath
    {
        public static void demo()
        {
            Console.WriteLine("Enter Date : 1 , String : 2, Math : 3");

            int val = int.Parse(Console.ReadLine());

            switch (val)
            {
                case 1:
                    DateTimeDemo();
                    break;
                case 2:
                    StringDemo();
                    break;
                case 3:
                    MathDemo();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Mehtod contains all Math lib oprations
        /// </summary>
        private static void MathDemo()
        {
            double price = 199.75;
            double discountPercent = 10;

            double discount = price * discountPercent / 100;
            double finalPrice = price - discount;

            Console.WriteLine(finalPrice);

            Console.WriteLine(Math.Round(finalPrice));
            Console.WriteLine(Math.Ceiling(finalPrice));
            Console.WriteLine(Math.Floor(finalPrice));

            Console.WriteLine(Math.Pow(2, 3));
            Console.WriteLine(Math.Sqrt(25));

            Console.WriteLine(Math.Max(10, 20));
            Console.WriteLine(Math.Min(10, 20));

            Console.WriteLine(Math.Abs(-15));

        }

        /// <summary>
        /// Method contains String related operations
        /// </summary>

        private static void StringDemo()
        {
            string fullName = "  Ronak Thesiya  ";
            string email = "RONAK@GMAIL.COM";
            string message = "Welcome to CSharp Programming";

            string name = fullName.Trim();
            Console.WriteLine($"Name: {name}");

            Console.WriteLine(email.ToLower());

            Console.WriteLine(message.Contains("CSharp"));

            Console.WriteLine(message.Replace("CSharp", "DotNet"));

            string[] words = message.Split(' ');
            Console.WriteLine("Words:");

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine(name.Length);
        }

        /// <summary>
        /// Method contains DateTime related operations
        /// </summary>
        public static void DateTimeDemo()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n===== DateTime Manager =====");
                Console.WriteLine("1. Show current local date & time");
                Console.WriteLine("2. Show current UTC date & time");
                Console.WriteLine("3. Add/Subtract days to a date");
                Console.WriteLine("4. Format a date");
                Console.WriteLine("5. Show day of the week");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Local Date & Time: " + DateTime.Now);
                        break;
                    case "2":
                        Console.WriteLine("UTC Date & Time: " + DateTime.UtcNow);
                        break;
                    case "3":
                        Console.Write("Enter a date (yyyy-MM-dd): ");
                        DateTime dt = DateTime.Parse(Console.ReadLine());
                        
                        Console.Write("Enter number of days to add/subtract: ");
                        int days = int.Parse(Console.ReadLine());
                        
                        DateTime newDate = dt.AddDays(days);
                        Console.WriteLine("New Date: " + newDate);

                        break;
                    case "4":
                        Console.Write("Enter a date (yyyy-MM-dd): ");
                        dt = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter format string (e.g., MM/dd/yyyy): ");
                        string format = Console.ReadLine();
                        Console.WriteLine("Formatted Date: " + dt.ToString(format));
                        
                        break;
                    case "5":
                        Console.Write("Enter a date (yyyy-MM-dd): ");
                        dt = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Day of the Week: " + dt.DayOfWeek);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        return;
                }

                Console.WriteLine("Press any key for next :");
                Console.ReadKey();
            }

        }
    }


}
