using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Services
{
    public class NotificationService<T> where T : class
    {
        public void Send(T notification)
        {
            Console.WriteLine($"Sending notification: {typeof(T).Name}");
        }

    }
}
