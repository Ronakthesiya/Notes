using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// class cover Exception handling with try catch finally block
    /// also created a user defined exception
    /// </summary>
    internal class ExceptionDemo
    {
        public static void demo()   
        {

            /*
            NullReferenceException
            IndexOutOfRangeException
            DivideByZeroException
            FileNotFoundException
            StackOverflowException
            OutOfMemoryException
             */

            try
            {
                throw new MyException("demo exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                int c = 0;
                double b = 1 / c;
            }
            catch (Exception ex) when (ex is DivideByZeroException) 
            {
                Console.WriteLine(ex.ToString());
            }


        }
    }

    /// <summary>
    /// Class inherit Exception class and call the base constructor
    /// </summary>
    class MyException : Exception { 
        public MyException(string msg) : base(msg)
        { 
        
        }
    }
}
