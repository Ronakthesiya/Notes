using DemoConsol;

namespace DemoAccess
{
    public class Program : BankAccount
    {
        public static void Main(string[] args)
        {

            Console.WriteLine(AccountHolder);
            Console.WriteLine(AccountNumber);
            //Console.WriteLine(BankAccount.Branch);
            Console.WriteLine(InterestRate);
            //Console.WriteLine(BankAccount.InternalCode);

            ShowBalance();


            Console.WriteLine("heloo from DemoConsol2");
        }
    }
    public class ProgramInternal
    {
        protected internal static int Add(int a, int b)
        {
            return a + b;
        }
    }


    public class ProgramPublic
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}