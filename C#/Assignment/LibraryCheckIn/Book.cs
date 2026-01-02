using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckIn
{
    public enum enumBookCondition { New = -1, Good = 1, Worn = 3, Damaged = 10, Notgiven = 0 };


    /// <summary>
    /// Book class with all book properties, constructor, methods
    /// </summary>
    public class Book
    {
        // private = Only access by the class
        private int Id { get; set; }

        public string Title { get; set; }
        
        // public =  Condition can be change by others
        public enumBookCondition Condition { get; set; }

        public string Author { get; set; }

        public Book(int a, string b, string d, enumBookCondition c)
        {
            Id = a;
            Title = b;
            Condition = c;
            Author = d;
        }

        public void display()
        {
            Console.WriteLine(Id + " " + Title + " " + Author + " " + Condition);
        }
    }

}
