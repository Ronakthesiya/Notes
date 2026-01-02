using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Services
{
    /// <summary>
    /// Generic class use to send notification
    /// </summary>
    /// <typeparam name="T"> define the type of notification Email, Sms</typeparam>
    public class NotificationService<T> where T : class
    {
        public void Send(T notification)
        {
            Console.WriteLine($"Sending notification: {typeof(T).Name}");
        }

    }
}
