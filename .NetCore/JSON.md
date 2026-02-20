## Source Generators

### Why Source Generators Exist

- System.Text.Json relied entirely on reflection-based metadata generation

- When you call:
```c#
JsonSerializer.Serialize(obj);
```

- Internally:
    - It inspects obj.GetType()
    - Reflects over properties
    - Builds JsonTypeInfo
    - Caches metadata
    - Uses reflection-based delegates

- Problems:
    - Runtime cost
    - Higher allocations
    - Slower cold start
    - Not trimming-safe
    - Not NativeAOT-friendly
    - Harder for Blazor WASM

- Source generators solve this by:
    - Generating the metadata and serialization logic at compile time.

- No runtime reflection needed.

### What Actually Gets Generated

- When you create:

```c#
[JsonSerializable(typeof(Person))]
public partial class MyJsonContext : JsonSerializerContext
{
}
```

- The compiler generates:
    - A derived JsonTypeInfo `<Person>`
    - Optimized property metadata
    - Delegates for getters/setters
    - (Optionally) direct serialization code


```c#
var person = new Person
{
    Name = "Ronak",
    Age = 22
};

string json = JsonSerializer.Serialize(person, AppJsonContext.Default.Person);
```

### How Source Generators Work

1. You mark a type `[JsonSerializable(typeof(T))]`
2. Compiler generates **helper classes** at build time
    - Writes code for reading/writing JSON properties
    - Strongly typed
3. At runtime:
    - Generated code is used
    - No reflection needed
    - Very fast


## Polymorphism

Polymorphism means:
- A variable of a base type can hold objects of derived types.

### Default Behavior (Without Polymorphism Configuration)

```cs
public abstract class Animal
{
    public string Name { get; set; } = default!;
}

public class Dog : Animal
{
    public bool Barks { get; set; }
}

Animal animal = new Dog { Name = "Rex", Barks = true };

string json = JsonSerializer.Serialize(animal);
Console.WriteLine(json);

```

> ouput

```cs
{
  "Name": "Rex"
}
```

- 🚨 Problem:
    - Barks is lost.
    - Runtime type ignored.
    - Only base type properties serialized.

### Solution (.NET 7+)

.NET 7 introduced built-in polymorphism support using:

- [JsonPolymorphic]
- [JsonDerivedType]
- Type discriminators

```cs
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(Dog), "dog")]
[JsonDerivedType(typeof(Cat), "cat")]
public abstract class Animal {
    public string Name { get; set; } = default!;
}

public class Dog : Animal {
    public bool Barks { get; set; }
}

public class Cat : Animal {
    public int Lives { get; set; }
}
```

- Serialization Example
```cs
Animal animal = new Dog{
    Name = "Rex",
    Barks = true
};

string json = JsonSerializer.Serialize(animal, new JsonSerializerOptions{
    WriteIndented = true
});

Console.WriteLine(json);
```

- Output:
```json
{
  "$type": "dog",
  "Name": "Rex",
  "Barks": true
}
```


- Deserialization Example
```cs
Animal deserialized =
    JsonSerializer.Deserialize<Animal>(json)!;

Console.WriteLine(deserialized.GetType().Name);
```

- Output:
```json
Dog
```

### Collections of Polymorphic Types

```cs
var animals = new List<Animal>
{
    new Dog { Name = "Rex", Barks = true },
    new Cat { Name = "Whiskers", Lives = 9 }
};

string json = JsonSerializer.Serialize(animals, new JsonSerializerOptions
{
    WriteIndented = true
});

Console.WriteLine(json);
```

- Output:
```json
[
  { "$type": "dog", "Name": "Rex", "Barks": true },
  { "$type": "cat", "Name": "Whiskers", "Lives": 9 }
]
```

- deserialize

```cs
var deserialized =
    JsonSerializer.Deserialize<List<Animal>>(json)!;

foreach (var animal in deserialized)
{
    Console.WriteLine(animal.GetType().Name);
}
```

## Utf8JsonReader & Utf8JsonWriter

- These are high-performance, low-level APIs for streaming large JSON without allocating huge objects in memory.

### Parse Large JSON with Utf8JsonReader

```cs
using System.Text;
using System.Text.Json;

string json = @"[{""Name"":""Alice"",""Age"":30},{""Name"":""Bob"",""Age"":25}]";
byte[] jsonData = Encoding.UTF8.GetBytes(json);
var reader = new Utf8JsonReader(jsonData);

while (reader.Read())
{
    if (reader.TokenType == JsonTokenType.PropertyName)
    {
        Console.WriteLine($"Property: {reader.GetString()}");
    }
    else if (reader.TokenType == JsonTokenType.String)
    {
        Console.WriteLine($"Value: {reader.GetString()}");
    }
    else if (reader.TokenType == JsonTokenType.Number)
    {
        Console.WriteLine($"Value: {reader.GetInt32()}");
    }
}
```

### Write JSON Efficiently with Utf8JsonWriter


```cs
 var stream = new MemoryStream();
 var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });

writer.WriteStartArray();
writer.WriteStartObject();
writer.WriteString("Name", "Ronak");
writer.WriteNumber("Age", 22);
writer.WriteEndObject();
writer.WriteEndArray();
writer.Flush();

string output = Encoding.UTF8.GetString(stream.ToArray());
Console.WriteLine(output);
```


