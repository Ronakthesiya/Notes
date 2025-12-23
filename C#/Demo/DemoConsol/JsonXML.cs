using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DemoConsol
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Email: {Email}";
        }

        public void GetPerson()
        {
            Console.Write("Enter Name : ");
            Name = Console.ReadLine();
            Console.Write("Enter Age : ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Email : ");
            Email = Console.ReadLine();
        }
    }
    public class JsonXML
    {
        public static void demo()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== JSON XML ======");
                Console.WriteLine("Enter 1 : OBJ -> JSON");
                Console.WriteLine("Enter 2 : JSON -> OBJ");
                Console.WriteLine("Enter 3 : OBJ -> XML");
                Console.WriteLine("Enter 4 : XML -> OBJ");
                Console.WriteLine("Enter 0 : break");


                int val = int.Parse(Console.ReadLine());

                if (val == 0) break;

                switch (val)
                {
                    case 1: 
                        Person p = new Person();
                        p.GetPerson();
                        JsonHandler.SerializeToJson(p);
                        break;
                    case 2:
                        Console.Write("Enter JSON : ");
                        string str = Console.ReadLine();
                        JsonHandler.DeserializeFromJson(str);
                        break;
                    case 3:
                        Person p1 = new Person();
                        p1.GetPerson();
                        XmlHandler.SerializeToXml(p1);
                        break;
                    case 4:
                        Console.Write("Enter XML File path : ");
                        string str1 = Console.ReadLine();
                        XmlHandler.DeserializeFromXml(str1);
                        break;
                }

                Console.ReadKey();
            }
        }
    }

    public class JsonHandler
    {
        public static void SerializeToJson(Person person)
        {
            string json = JsonSerializer.Serialize(person);

            Console.WriteLine(json);
        }

        public static void DeserializeFromJson(string json)
        {
            Person person = JsonSerializer.Deserialize<Person>(json);

            Console.WriteLine(person);
        }
    }

    public class XmlHandler
    {
        public static void SerializeToXml(Person person)
        {  
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            StreamWriter sw = new StreamWriter("demo.xml");
            xmlSerializer.Serialize(sw,person);
            sw.Close();

            Console.WriteLine("XML file is ready ! demo.xml");

        }

        public static void DeserializeFromXml(string str)
        {
            TextReader sr = new StreamReader(str);

            XmlSerializer xmlSerializer = new XmlSerializer (typeof(Person));
            Person p = (Person)xmlSerializer.Deserialize(sr);

            sr.Close();

            Console.WriteLine(p);
        }
    }
    
}
