using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol.Services
{
    /// <summary>
    /// use to define and send Sms notification
    /// </summary>
    public class SmsNotification
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
