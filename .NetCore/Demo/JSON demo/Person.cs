using System.Text.Json.Serialization;

namespace JSON_demo
{

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(Employee), "employee")]
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
        
    }

    [JsonSerializable(typeof(Person))]
    [JsonSerializable(typeof(Employee))]
    [JsonSerializable(typeof(List<Person>))]

    public partial class PersonJsonContext : JsonSerializerContext
    {
    }
}