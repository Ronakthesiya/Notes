using System;
using System.Text.Json;

namespace JSON_demo.Repository
{
    public class EmployeeRepository
    {
        public string filePath = "product.txt";
        public string filePath2 = "xyz.json";

        public List<Employee> Get()
        {
            List<Employee> employees = new List<Employee>();

            if (!File.Exists(filePath))
                return employees;

            string jsonData = File.ReadAllText(filePath);

            Console.WriteLine(jsonData);


            employees = JsonSerializer.Deserialize<List<Employee>>(jsonData);
            
            return employees;
        }


        public void Add(Employee employee)
        {
            List<Employee> employees = Get();

            List<Person> persons = new List<Person>();

            foreach (Employee emp in employees)
            {
                persons.Add(emp);
            }

            persons.Add(employee);

            string jsonData = JsonSerializer.Serialize(
                persons,
                PersonJsonContext.Default.ListPerson
            );


            Console.WriteLine(jsonData);

            File.WriteAllText(filePath, jsonData);

            writeFile(employee.Name,employee.Age);

            readFile();
        }

        public void readFile()
        {
            byte[] jsonBytes = File.ReadAllBytes(filePath2);

            Utf8JsonReader reader = new Utf8JsonReader(jsonBytes);

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        Console.WriteLine($"Property: {reader.GetString()}");
                        break;
                    case JsonTokenType.String:
                        Console.WriteLine($"String: {reader.GetString()}");
                        break;
                    case JsonTokenType.Number:
                        Console.WriteLine($"Number: {reader.GetInt32()}");
                        break;
                }
            }
        }

        public void writeFile(string name, int age)
        {
            using FileStream fs = File.Create(filePath2);
            using Utf8JsonWriter writer = new Utf8JsonWriter(fs, new JsonWriterOptions { Indented = true });

            writer.WriteStartObject();
            writer.WriteString("Name", name);
            writer.WriteNumber("Age", age);
            writer.WriteEndObject();

            writer.Flush(); // make sure data is written to the file

        }


    }
}
