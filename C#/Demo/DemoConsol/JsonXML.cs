using DemoConsol.Models;
using DemoConsol.Services;
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
}
