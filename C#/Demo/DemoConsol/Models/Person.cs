using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Models
{
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
