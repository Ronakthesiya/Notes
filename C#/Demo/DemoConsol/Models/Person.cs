using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Models
{
    /// <summary>
    /// Person class define persion details and method to access and print the details
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Email: {Email}";
        }

        public void GetPerson()
        {
            Console.Write("Enter Name : ");
            Name = Console.ReadLine();
            Console.Write("Enter Age : ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Email : ");
            Email = Console.ReadLine();
        }
    }
}
