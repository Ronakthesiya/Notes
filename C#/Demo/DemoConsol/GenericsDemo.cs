using DemoConsol.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoConsol
{
    public class GenericsDemo
    {
        public static void demo()
        {
            NotificationService<EmailNotification> email = new NotificationService<EmailNotification>();
            email.Send(new EmailNotification() { Email = "abcd@gmail.com", Subject = "hello" });


            NotificationService<SmsNotification> sms = new NotificationService<SmsNotification>();
            sms.Send(new SmsNotification() { PhoneNumber = "1234567890", Message = "hello" });

        }
    }

}
