using DemoConsol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoConsol.Services
{
    public class XmlHandler
    {
        public static void SerializeToXml(Person person)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            StreamWriter sw = new StreamWriter("demo.xml");
            xmlSerializer.Serialize(sw, person);
            sw.Close();

            Console.WriteLine("XML file is ready ! demo.xml");

        }

        public static void DeserializeFromXml(string str)
        {
            TextReader sr = new StreamReader(str);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            Person p = (Person)xmlSerializer.Deserialize(sr);

            sr.Close();

            Console.WriteLine(p);
        }
    }
}
