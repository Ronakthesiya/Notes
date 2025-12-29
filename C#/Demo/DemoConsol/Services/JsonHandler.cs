using DemoConsol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoConsol.Services
{
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
}
