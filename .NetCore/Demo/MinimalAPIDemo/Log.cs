using MinimalAPIDemo.Interface;

namespace MinimalAPIDemo
{
    public class Log : ILog
    {
        void ILog.Log(string message)
        {
            Console.WriteLine("-------------------------------------------<<<<>>>>-------------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("-------------------------------------------<<<<>>>>-------------------------------------------");
        }
    }
}
