using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
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
            finally
            {

            }
        }
    }

    class MyException : Exception { 
        public MyException(string msg) : base(msg)
        { 
        
        }
    }
}
