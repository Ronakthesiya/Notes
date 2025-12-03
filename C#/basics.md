<!-- ## C# Data types

## 1. Value Types in C#

1. Integral types (int, byte, long, etc.)
2. Floating-point types (float, double, decimal)
3. Character type (char)
4. Boolean type (bool)
5. Enumerations (enum)
6. Structs (struct)

## Integral Data Types

byte	1 byte	0 to 255
sbyte	1 byte	-128 to 127
short	2 bytes	-32,768 to 32,767
ushort	2 bytes	0 to 65,535
int	4 bytes	-2,147,483,648 to 2,147,483,647
uint	4 bytes	0 to 4,294,967,295
long	8 bytes	-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
ulong	8 bytes	0 to 18,446,744,073,709,551,615


## Floating-Point Data Types

Data Type	Size	Precision
float	4 bytes	6-7 decimal places
double	8 bytes	15-16 decimal places
decimal	16 bytes	28-29 decimal places


## Character and Boolean Data Types

Data Type	Size	Description
char	2 bytes	Stores a single character
bool	1 byte	Stores true or false


## Enumerations (enum)
An enum is a special data type used for defining named constant values.

using System;

class Program
{
    enum JobLevel { Intern, Junior, Mid, Senior, Manager }

    static void Main()
    {
        JobLevel currentLevel = JobLevel.Mid;
        Console.WriteLine("Current Job Level: " + currentLevel);
    }
}


## Structs
A struct is a value type used to encapsulate related data.

using System;

struct Employee
{
    public int ID;
    public string Name;
    public double Salary;
}

class Program
{
    static void Main()
    {
        Employee emp;
        emp.ID = 101;
        emp.Name = "Zoya";
        emp.Salary = 60000.50;

        Console.WriteLine("Employee ID: " + emp.ID);
        Console.WriteLine("Employee Name: " + emp.Name);
        Console.WriteLine("Employee Salary: $" + emp.Salary);
    }
}


## 2. Reference Types in C#

- The reference types do not contain the actual data stored in a variable, but they contain a reference to the variables.

- In other words, they refer to a memory location. Using multiple variables, the reference types can refer to a memory location. If the data in the memory location is changed by one of the variables, the other variable automatically reflects this change in value. Example of built-in reference types are: object, dynamic, string, and array.

## Object Type
- The Object Type is the ultimate base class for all data types in C# Common Type System (CTS). Object is an alias for System.Object class. The object types can be assigned values of any other types, value types, reference types, predefined or user-defined types. However, before assigning values, it needs type conversion.

- When a value type is converted to object type, it is called boxing and on the other hand, when an object type is converted to a value type, it is called unboxing.

```c#
using System;

class Program
{
    static void Main()
    {
        object obj = 1001; // Student ID
        Console.WriteLine("Student ID: " + obj);

        obj = "Sudhir Sharma"; // Student Name
        Console.WriteLine("Student Name: " + obj);
    }
}
```


## Dynamic Type
You can store any type of value in the dynamic data type variable. Type checking for these types of variables takes place at run-time.

```c#
using System;

class Program
{
    static void Main()
    {
        dynamic value = 10;
        Console.WriteLine("Dynamic value: " + value);

        value = "Hello, World!";
        Console.WriteLine("Dynamic now contains: " + value);
    }
}
```

## String Type

The String Type allows you to assign any string values to a variable. 


## Array Type
Arrays store multiple values of the same type in a single variable.

## 3. Pointer Type in C#

Pointer type variables store the memory address of another type. 

```c#
using System;

unsafe class Program
{
    static void Main()
    {
        int grade = 90;
        int* ptr = &grade;

        Console.WriteLine("Original Grade: " + grade);
        Console.WriteLine("Memory Address: " + (ulong)ptr);

        *ptr = 95; // Modifying value using pointer
        Console.WriteLine("Updated Grade: " + grade);
    }
}
```

 -->


# C# Data Types

## 📘 Index

1. [Value Types in C#](#1-value-types-in-c)
   - [Integral Data Types](#integral-data-types)
   - [Floating-Point Data Types](#floating-point-data-types)
   - [Character and Boolean Data Types](#character-and-boolean-data-types)
   - [Enumerations (enum)](#enumerations-enum)
   - [Structs](#structs)
2. [Reference Types in C#](#2-reference-types-in-c)
   - [Object Type](#object-type)
   - [Dynamic Type](#dynamic-type)
   - [String Type](#string-type)
   - [Array Type](#array-type)
3. [Pointer Type in C#](#3-pointer-type-in-c)

---

<details>
<summary><h2>1. Value Types in C#</h2></summary>

Value types directly contain their data. Examples include integers, floating-point numbers, characters, booleans, enums, and structs.

**Types of Value Types:**
1. Integral types (`int`, `byte`, `long`, etc.)
2. Floating-point types (`float`, `double`, `decimal`)
3. Character type (`char`)
4. Boolean type (`bool`)
5. Enumerations (`enum`)
6. Structs (`struct`)

---

<details>
<summary><b>Integral Data Types</b></summary>

| Data Type | Size | Range |
|------------|-------|-------|
| `byte` | 1 byte | 0 to 255 |
| `sbyte` | 1 byte | -128 to 127 |
| `short` | 2 bytes | -32,768 to 32,767 |
| `ushort` | 2 bytes | 0 to 65,535 |
| `int` | 4 bytes | -2,147,483,648 to 2,147,483,647 |
| `uint` | 4 bytes | 0 to 4,294,967,295 |
| `long` | 8 bytes | -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 |
| `ulong` | 8 bytes | 0 to 18,446,744,073,709,551,615 |

</details>

---

<details>
<summary><b>Floating-Point Data Types</b></summary>

| Data Type | Size | Precision |
|------------|------|------------|
| `float` | 4 bytes | 6–7 decimal places |
| `double` | 8 bytes | 15–16 decimal places |
| `decimal` | 16 bytes | 28–29 decimal places |

</details>

---

<details>
<summary><b>Character and Boolean Data Types</b></summary>

| Data Type | Size | Description |
|------------|------|-------------|
| `char` | 2 bytes | Stores a single character |
| `bool` | 1 byte | Stores `true` or `false` |

</details>

---

<details>
<summary><b>Enumerations (enum)</b></summary>
An enum is a special data type used for defining named constant values.

```csharp
using System;

class Program
{
    enum JobLevel { Intern, Junior, Mid, Senior, Manager }

    static void Main()
    {
        JobLevel currentLevel = JobLevel.Mid;
        Console.WriteLine("Current Job Level: " + currentLevel);
    }
}
```

</details>
<details> <summary><b>Structs</b></summary>
A struct is a value type used to encapsulate related data.

```csharp
using System;

struct Employee
{
    public int ID;
    public string Name;
    public double Salary;
}

class Program
{
    static void Main()
    {
        Employee emp;
        emp.ID = 101;
        emp.Name = "Zoya";
        emp.Salary = 60000.50;

        Console.WriteLine("Employee ID: " + emp.ID);
        Console.WriteLine("Employee Name: " + emp.Name);
        Console.WriteLine("Employee Salary: $" + emp.Salary);
    }
}
```

</details> </details>
<details> <summary><h2>2. Reference Types in C#</h2></summary>

Reference types do not store actual data. Instead, they store a reference (memory address) pointing to the data’s location in memory.

If two variables reference the same memory location and one changes the data, the other reflects that change automatically.

Examples of reference types:

- object
- dynamic
- string
- array

<details> <summary><b>Object Type</b></summary>

```csharp
using System;

class Program
{
    static void Main()
    {
        object obj = 1001; // Student ID
        Console.WriteLine("Student ID: " + obj);

        obj = "Sudhir Sharma"; // Student Name
        Console.WriteLine("Student Name: " + obj);
    }
}
```

</details>
<details> <summary><b>Dynamic Type</b></summary>

```csharp
using System;

class Program
{
    static void Main()
    {
        dynamic value = 10;
        Console.WriteLine("Dynamic value: " + value);

        value = "Hello, World!";
        Console.WriteLine("Dynamic now contains: " + value);
    }
}

```

</details>
<details> <summary><b>String Type</b></summary>

```csharp
string message = "Welcome to C#!";
Console.WriteLine(message);
```

</details>
<details> <summary><b>Array Type</b></summary>

```csharp
int[] scores = { 85, 90, 95 };
Console.WriteLine("First Score: " + scores[0]);
```

</details> </details>
<details> <summary><h2>3. Pointer Type in C#</h2></summary>

Pointer type variables store the memory address of another variable.
Pointers can only be used in an unsafe context.

```csharp
using System;

unsafe class Program
{
    static void Main()
    {
        int grade = 90;
        int* ptr = &grade;

        Console.WriteLine("Original Grade: " + grade);
        Console.WriteLine("Memory Address: " + (ulong)ptr);

        *ptr = 95; // Modifying value using pointer
        Console.WriteLine("Updated Grade: " + grade);
    }
}
```
</details>
























## Types of Variables in C#

1. Primitive Variables
The primitive variables are basic data types like int, float, char, and bool.
```c#
int number = 10;
double pi = 3.14;
```

2. Reference Variables
The reference variables hold references to objects in memory, like arrays and classes.
```c#
string name = "Alice";
int[] numbers = new int[] { 1, 2, 3 };
```

3. Constants
The constants are variables whose value cannot be changed once assigned.
```c#
const double PI = 3.14159;
```

4. Nullable Variables
The nullable variables can hold a null value.
```c#
int? age = null;
```





## Access Specifier

- Public = Any public member can be accessed from outside the class.

- Private = Private access specifier allows a class to hide its member variables and member functions from other functions and objects. Only functions of the same class can access its private members. Even an instance of a class cannot access its private members.

- Protected = Protected access specifier allows a child class to access the member variables and member functions of its base class. 

- Internal = Internal access specifier allows a class to expose its member variables and member functions to other functions and objects in the current assembly. In other words, any member with internal access specifier can be accessed from any class or method defined within the application in which the member is defined.

- Protected internal = The protected internal access specifier allows a class to hide its member variables and member functions from other class objects and functions, except a child class within the same application. This is also used while implementing inheritance.

| **Access Specifier** | **Derived Classes** | **Same Assembly** | **Other Assemblies** |
| -------------------- | ------------------- | ----------------- | -------------------- |
| `public`             | ✅                 | ✅               | ✅                   |
| `private`            | ❌                 | ❌               | ❌                   |
| `protected`          | ✅                 | ❌               | ❌                   |
| `internal`           | ❌                 | ✅               | ❌                   |
| `protected internal` | ✅                 | ✅               | ❌                   |
| `private protected`  | ✅                 | ❌               | ❌                   |

| **Specifier**        | **Access Scope**                             |
| -------------------- | -------------------------------------------- |
| `public`             | Accessible from anywhere                     |
| `private`            | Only inside the same class                   |
| `protected`          | Inside the same class and derived classes    |
| `internal`           | Within the same assembly                     |
| `protected internal` | Within the same assembly or derived classes  |
| `private protected`  | Within the same assembly and derived classes |


    


## Structure

```c#
struct Books {
   public string title;
   public string author;
   public string subject;
   public int book_id;
};  

struct Person {
    public string name;
    public int age;
    public string empid;

    // Parameterized Constructor
    public Person(string name, int age, string empid) {
        this.name = name;
        this.age = age;
        this.empid = empid;
    }
}


Person p1 = new Person(); // Default initialization

Person p1;
p1.name = "Sudhir Sharma"; 
p1.age = 27;
p1.empid = "SEO01";
```

- Structures can have methods, fields, indexers, properties, operator methods, and events.
- Structures can have defined constructors, but not destructors. However, you cannot define a default constructor for a structure. The default constructor is automatically defined and cannot be changed.
- Unlike classes, structures cannot inherit other structures or classes.
- Structures cannot be used as a base for other structures or classes.
- A structure can implement one or more interfaces.
- Structure members cannot be specified as abstract, virtual, or protected.
- When you create a struct object using the New operator, it gets created and the appropriate constructor is called. Unlike classes, structs can be instantiated without using the New operator.
- If the New operator is not used, the fields remain unassigned and the object cannot be used until all the fields are initialized.

#### Class versus Structure

- classes are reference types and structs are value types
- structures do not support inheritance
- structures cannot have default constructor


#### Structure with Methods and Interfaces

```c#
using System;

interface IPerson {
    string GetDetails();
}

struct Person : IPerson {
    public string name;
    public int age;
    public string empid;

    // Constructor to initialize fields
    public Person(string name, int age, string empid) {
        this.name = name;
        this.age = age;
        this.empid = empid;
    }

    // Implementing the interface method
    public string GetDetails() => $"Name: {name}, Age: {age}, Employee ID: {empid}";
}

class Program {
    static void Main() {
        // Creating an instance of Person
        Person p1 = new Person("Sudhir Sharma", 27, "SEO01");
        Console.WriteLine(p1.GetDetails());
    }
}
```


## enum

```c#
enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };

enum StatusCode
{
   Success = 200,
   NotFound = 404,
   ServerError = 500
}

class Program
{
   static void Main()
   {
        StatusCode status = StatusCode.NotFound;
        Console.WriteLine("Status: " + status);
        Console.WriteLine("Numeric Value: " + (int)status);

        int WeekdayStart = (int)Days.Mon;
        int WeekdayEnd = (int)Days.Fri;
        
        Console.WriteLine("Monday: {0}", WeekdayStart);
        Console.WriteLine("Friday: {0}", WeekdayEnd);
   }
}

// output
Status: NotFound
Numeric Value: 404
Monday: 1
Friday: 5
```

## C# Constructors

- A constructor has exactly the same name as that of class and it does not have any return type.

## C# Destructors

- A destructor is a special member function of a class that is executed whenever an object of its class goes out of scope. A destructor has exactly the same name as that of the class with a prefixed tilde (~) and it can neither return a value nor can it take any parameters.

- Destructor can be very useful for releasing memory resources before exiting the program. Destructors cannot be inherited or overloaded.

```c#
using System;
namespace LineApplication {
   class Line {
      private double length;   // Length of a line
      
      public Line() {   // constructor
         Console.WriteLine("Object is being created");
      }
      ~Line() {   //destructor
         Console.WriteLine("Object is being deleted");
      }
      public void setLength( double len ) {
         length = len;
      }
      public double getLength() {
         return length;
      }
      static void Main(string[] args) {
         Line line = new Line();

         // set line length
         line.setLength(6.0);
         Console.WriteLine("Length of line : {0}", line.getLength());           
      }
   }
}
```


## Inheritance

1. Single Inheritance
2. Multi-Level Inheritance
3. Hierarchical Inheritance
4. Multiple Inheritance : C# does not support 


## Polymorphism

### Compile Time Polymorphism / Static Polymorphism
1. Function overloading = the function must differ from each other by the types and/or the number of arguments in the argument list
2. Operator overloading
- You can redefine or overload most of the built-in operators available in C#. Thus a programmer can use operators with user-defined types as well. Overloaded operators are functions with special names the keyword operator followed by the symbol for the operator being defined. similar to any other function, an overloaded operator has a return type and a parameter list.

```c#
public static Box operator+ (Box b, Box c) {
   Box box = new Box();
   box.length = b.length + c.length;
   box.breadth = b.breadth + c.breadth;
   box.height = b.height + c.height;
   return box;
}

 // Add two object as follows:
Box3 = Box1 + Box2;
```
| **Sr. No.** | **Operators**                                         | **Description**                                                                                               | **Overloadable?**
| ----------- | ----------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | -----------------
| 1           | `+`, `-`, `!`, `~`, `++`, `--`                        | **Unary operators** — take one operand.                                                                       | ✅ Yes            
| 2           | `+`, `-`, `*`, `/`, `%`                               | **Binary arithmetic operators** — take two operands.                                                          | ✅ Yes            
| 3           | `==`, `!=`, `<`, `>`, `<=`, `>=`                      | **Comparison (relational) operators.**                                                                        | ✅ Yes            
| 5           | `+=`, `-=`, `*=`, `/=`, `%=`                          | **Compound assignment operators** — cannot be overloaded directly (they use the overloaded binary operators). | ⚠️ Not directly  
| 6           | `=`, `.`, `?:`, `->`, `new`, `is`, `sizeof`, `typeof` | **Miscellaneous operators** — not overloadable in C#.                                                         | ❌ No             


### Run-Time Polymorphism / Dynamic Polymorphism
1. Method Overriding = Dynamic polymorphism is implemented by abstract classes and virtual functions.


## Regex

| **Pattern** | **Description**                  | **Example**                                     |
| ----------- | -------------------------------- | ----------------------------------------------- |
| `.`         | Any single character             | `"h.t"` → matches `"hat"`, `"hit"`              |
| `\d`        | Any digit (0–9)                  | `"abc123"` → matches `123`                      |
| `\w`        | Any word char (a–z, A–Z, 0–9, _) | `"hello_world"`                                 |
| `\s`        | Any whitespace                   | `"hello world"`                                 |
| `\b`        | Word boundary                    | `"\bcat\b"` → matches `"cat"`, not `"category"` |
| `^`         | Start of string                  | `"^Hello"` → matches `"Hello"` at start         |
| `$`         | End of string                    | `"World$"` → matches `"World"` at end           |
| `*`         | 0 or more occurrences            | `"A*"` → `"A"`, `"AA"`, `""`                    |
| `+`         | 1 or more occurrences            | `"A+"` → `"A"`, `"AA"`, not `""`                |
| `{n,m}`     | Between *n* and *m* occurrences  | `"\d{2,4}"` → `12`, `123`, `1234`               |


```c#
string email = "test@example.com";
string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

Regex rgx = new Regex(pattern);
bool isValid = rgx.IsMatch(email);
```


## Exception Handling

- try − A try block identifies a block of code for which particular exceptions is activated. It is followed by one or more catch blocks.

- catch − A program catches an exception with an exception handler at the place in a program where you want to handle the problem. The catch keyword indicates the catching of an exception.

- finally − The finally block is used to execute a given set of statements, whether an exception is thrown or not thrown. For example, if you open a file, it must be closed whether an exception is raised or not.

- throw − A program throws an exception when a problem shows up. This is done using a throw keyword.


## File I/O

<details>
<summary><h3>File Creation / Deletion</h3></summary>

| Method                         | Return Type    | Description                               | Example                              |
| ------------------------------ | -------------- | ----------------------------------------- | ------------------------------------ |
| `File.Create(string path)`     | `FileStream`   | Creates a new file; overwrites if exists. | `var fs = File.Create("a.txt");`     |
| `File.CreateText(string path)` | `StreamWriter` | Creates text file (UTF-8) for writing.    | `var sw = File.CreateText("a.txt");` |
| `File.Delete(string path)`     | `void`         | Deletes specified file.                   | `File.Delete("a.txt");`              |

</details>


<details>
<summary><h3>Copy / Move / Exists</h3></summary>

| Method                            | Return Type | Description                 | Example                              |
| --------------------------------- | ----------- | --------------------------- | ------------------------------------ |
| `File.Copy(src, dest)`            | `void`      | Copies file.                | `File.Copy("a.txt", "b.txt");`       |
| `File.Copy(src, dest, overwrite)` | `void`      | Copies file with overwrite. | `File.Copy("a.txt", "b.txt", true);` |
| `File.Move(src, dest)`            | `void`      | Moves/renames file.         | `File.Move("a.txt", "c.txt");`       |
| `File.Exists(path)`               | `bool`      | Checks if file exists.      | `if (File.Exists("a.txt")) { }`      |

</details>


<details>
<summary><h3>Open / Stream Access</h3></summary>

| Method                                 | Return Type    | Description                         | Example                                                               |
| -------------------------------------- | -------------- | ----------------------------------- | --------------------------------------------------------------------- |
| `File.Open(path, mode)`                | `FileStream`   | Opens with file mode.               | `var fs = File.Open("a.txt", FileMode.Open);`                         |
| `File.Open(path, mode, access)`        | `FileStream`   | Opens with mode + access.           | `File.Open("a.txt", FileMode.Open, FileAccess.Read);`                 |
| `File.Open(path, mode, access, share)` | `FileStream`   | Opens with mode + access + sharing. | `File.Open("a.txt", FileMode.Open, FileAccess.Read, FileShare.Read);` |
| `File.OpenRead(path)`                  | `FileStream`   | Opens read-only.                    | `var r = File.OpenRead("a.txt");`                                     |
| `File.OpenWrite(path)`                 | `FileStream`   | Opens write-only.                   | `var w = File.OpenWrite("a.txt");`                                    |
| `File.OpenText(path)`                  | `StreamReader` | Opens text for reading.             | `var reader = File.OpenText("a.txt");`                                |

</details>


<details>
<summary><h3>Read All / Write All</h3></summary>

| Method                             | Return Type    | Description                      | Example                                         |
| ---------------------------------- | -------------- | -------------------------------- | ----------------------------------------------- |
| `File.ReadAllText(path)`           | `string`       | Reads entire file as text.       | `string s = File.ReadAllText("a.txt");`         |
| `File.ReadAllLines(path)`          | `string[]`     | Reads all lines.                 | `var lines = File.ReadAllLines("a.txt");`       |
| `File.ReadAllBytes(path)`          | `byte[]`       | Reads entire file as bytes.      | `var bytes = File.ReadAllBytes("a.bin");`       |
| `File.WriteAllText(path, text)`    | `void`         | Writes text to file.             | `File.WriteAllText("a.txt", "Hello");`          |
| `File.WriteAllLines(path, lines)`  | `void`         | Writes string array.             | `File.WriteAllLines("a.txt", new[]{"a","b"});`  |
| `File.WriteAllBytes(path, bytes)`  | `void`         | Writes bytes to file.            | `File.WriteAllBytes("a.bin", bytes);`           |
| `File.AppendAllText(path, text)`   | `void`         | Appends text.                    | `File.AppendAllText("a.txt", "More");`          |
| `File.AppendAllLines(path, lines)` | `void`         | Appends lines.                   | `File.AppendAllLines("a.txt", new[]{ "end" });` |
| `File.AppendText(path)`            | `StreamWriter` | Opens file to append via writer. | `var sw = File.AppendText("a.txt");`            |

</details>


<details>
<summary><h3>File Metadata (Times & Attributes)</h3></summary>

| Method                               | Return Type       | Description            | Example                                                 |
| ------------------------------------ | ----------------- | ---------------------- | ------------------------------------------------------- |
| `File.GetAttributes(path)`           | `FileAttributes`  | Gets attributes.       | `var attr = File.GetAttributes("a.txt");`               |
| `File.SetAttributes(path, attr)`     | `void`            | Sets attributes.       | `File.SetAttributes("a.txt", FileAttributes.ReadOnly);` |
| `File.GetCreationTime(path)`         | `DateTime`        | Gets creation time.    | `var t = File.GetCreationTime("a.txt");`                |
| `File.SetCreationTime(path, time)`   | `void`            | Sets creation time.    | `File.SetCreationTime("a.txt", DateTime.Now);`          |
| `File.GetLastAccessTime(path)`       | `DateTime`        | Gets last access.      | `File.GetLastAccessTime("a.txt");`                      |
| `File.SetLastAccessTime(path, time)` | `void`            | Sets last access.      | `File.SetLastAccessTime("a.txt", DateTime.Now);`        |
| `File.GetLastWriteTime(path)`        | `DateTime`        | Gets last write.       | `File.GetLastWriteTime("a.txt");`                       |
| `File.SetLastWriteTime(path, time)`  | `void`            | Sets last write.       | `File.SetLastWriteTime("a.txt", DateTime.Now);`         |
| UTC Versions                         | `DateTime / void` | Same as above but UTC. | `File.GetCreationTimeUtc("a.txt");`                     |

</details>

## DataTable

```c#
DataTable dt = new DataTable("Students");

// Add columns
dt.Columns.Add("ID", typeof(int));
dt.Columns.Add("Name", typeof(string));
dt.Columns.Add("Marks", typeof(double));

// Add rows
dt.Rows.Add(1, "Ali", 85.5);
dt.Rows.Add(2, "Sara", 90.2);
dt.Rows.Add(3, "John", 78.9);

// Display data
foreach (DataRow row in dt.Rows)
{
    Console.WriteLine($"{row["ID"]} - {row["Name"]} - {row["Marks"]}");
}
```

#### Filtering and Searching Rows

```c#
DataRow[] highScores = dt.Select("Marks > 80");

foreach (DataRow row in highScores)
{
    Console.WriteLine($"{row["Name"]} scored above 80");
}
```

#### Sorting Data

```c#
DataRow[] sorted = dt.Select("", "Marks DESC");

// Update
dt.Rows[0]["Marks"] = 88.5;
// Delete
dt.Rows[2].Delete();

dt.AcceptChanges(); 

DataTable copy = dt.Copy();   // Copies both structure + data
DataTable clone = dt.Clone(); // Copies only structure (no data)

```

#### Constraint
```c#
DataTable dt = new DataTable("Student");

dt.Columns.Add("Id", typeof(int));
dt.Columns[0].AutoIncrement = true;
dt.Columns[0].AutoIncrementSeed = 1;
dt.Columns[0].AutoIncrementStep = 1;

DataColumn dc = new DataColumn();
dc.AllowDBNull = false;
dc.Unique = true;
dc.DefaultValue = "abcd";
dc.DataType = typeof(string);
dc.ColumnName = "Name";
dt.Columns.Add(dc);

// Add Auto Generated Column => Expression Use
dt.Columns.Add("IdName", typeof(string),"id+Name");

dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };

dt.RowChanged += (s, e) =>
{
    Console.WriteLine("Row changed: " + e.Row["Name"]);
    //Console.WriteLine(s.GetId());
};

dt.Rows.Add(null,"C");
dt.Rows.Add(null,"B");
dt.Rows.Add(null,"D");
dt.Rows.Add(null,"A");
```

#### ForeignKey

```c#
DataSet ds = new DataSet("CompanyDB");

// Add tables to dataset
ds.Tables.Add(dept);
ds.Tables.Add(emp);

// Relation
DataRelation rel = new DataRelation(
    "Dept_Employees",
    dept.Columns["DeptId"],
    emp.Columns["DeptId"]
);
ds.Relations.Add(rel);


// Access via relation => GetChildRows(relationName) , GetParentRow(relationName)
foreach (DataRow d in dept.Rows)
{
    Console.WriteLine("Department: " + d["DeptName"]);
    foreach (DataRow e in d.GetChildRows("Dept_Employees"))
        Console.WriteLine(" - " + e["Name"]);
}

DataRow parent = employees.Rows[0].GetParentRow("Dept_Employees");

```



## DateTime

| **Category**         | **Property / Method**         | **Description**             | **Example**                        | **Output / Note**       |
| -------------------- | ----------------------------- | --------------------------- | ---------------------------------- | ----------------------- |
| **Creation**         | `DateTime.Now`                | Current date and time       | `DateTime now = DateTime.Now;`     | `11/06/2025 10:30 AM`   |
|                      | `DateTime.Today`              | Current date (time = 00:00) | `DateTime today = DateTime.Today;` | `11/06/2025 12:00 AM`   |
|                      | `new DateTime(y,m,d)`         | Create custom date          | `new DateTime(2025,11,6)`          | `11/06/2025 00:00`      |
| **Properties**       | `.Day`, `.Month`, `.Year`     | Extract parts of date       | `now.Day`                          | `6`                     |
|                      | `.Hour`, `.Minute`, `.Second` | Extract time parts          | `now.Hour`                         | `10`                    |
|                      | `.DayOfWeek`                  | Returns weekday             | `now.DayOfWeek`                    | `Thursday`              |
| **Add/Subtract**     | `.AddDays(n)`                 | Add or subtract days        | `now.AddDays(5)`                   | Adds 5 days             |
|                      | `.AddMonths(n)`               | Add months                  | `now.AddMonths(1)`                 | Adds 1 month            |
|                      | `.AddYears(n)`                | Add years                   | `now.AddYears(-2)`                 | Subtract 2 years        |
|                      | `.AddHours(n)`                | Add hours                   | `now.AddHours(3)`                  | Adds 3 hours            |
| **Formatting**       | `.ToShortDateString()`        | Short date                  | `"11/06/2025"`                     |                         |
|                      | `.ToLongDateString()`         | Full date                   | `"Thursday, November 06, 2025"`    |                         |
|                      | `.ToString("dd/MM/yyyy")`     | Custom format               | `"06/11/2025"`                     |                         |
|                      | `.ToString("hh:mm tt")`       | 12-hour time                | `"10:30 AM"`                       |                         |
| **Comparison**       | `==`, `<`, `>`                | Compare dates               | `if(d1 < d2)`                      | Checks which is earlier |
|                      | `.Compare(d1, d2)`            | Returns int (-1,0,1)        | `DateTime.Compare(d1,d2)`          | -1 if d1<d2             |
| **Difference**       | `TimeSpan diff = d2 - d1`     | Finds duration              | `diff.Days`                        | Number of days          |
| **Parse / TryParse** | `DateTime.Parse(string)`      | Convert string to date      | `DateTime.Parse("11/06/2025")`     | `DateTime` object       |


## String

| **Category**            | **Method / Property**         | **Description**               | **Example**                     | **Output / Note** |
| ----------------------- | ----------------------------- | ----------------------------- | ------------------------------- | ----------------- |
| **Basics**              | `.Length`                     | Number of characters          | `"Hello".Length`                | `5`               |
|                         | `.ToUpper()`                  | Converts to uppercase         | `"hello".ToUpper()`             | `"HELLO"`         |
|                         | `.ToLower()`                  | Converts to lowercase         | `"HELLO".ToLower()`             | `"hello"`         |
|                         | `.Trim()`                     | Removes spaces from start/end | `"  Hi  ".Trim()`               | `"Hi"`            |
|                         | `.TrimStart()` / `.TrimEnd()` | Remove spaces from one side   | `"  Hi".TrimStart()`            | `"Hi"`            |
| **Searching**           | `.Contains(str)`              | Check substring               | `"Hello".Contains("lo")`        | `true`            |
|                         | `.StartsWith(str)`            | Starts with substring         | `"Hello".StartsWith("He")`      | `true`            |
|                         | `.EndsWith(str)`              | Ends with substring           | `"Hello".EndsWith("lo")`        | `true`            |
|                         | `.IndexOf(str)`               | Index of substring            | `"Hello".IndexOf("e")`          | `1`               |
| **Modification**        | `.Replace(a,b)`               | Replace text                  | `"C#".Replace("#","Sharp")`     | `"CSharp"`        |
|                         | `.Substring(start,len)`       | Extract substring             | `"Hello".Substring(1,3)`        | `"ell"`           |
|                         | `.Insert(pos,str)`            | Insert string                 | `"ABC".Insert(1,"x")`           | `"AxBC"`          |
|                         | `.Remove(start,len)`          | Remove part                   | `"Hello".Remove(2,2)`           | `"Heo"`           |
| **Splitting & Joining** | `.Split(delimiter)`           | Split string to array         | `"A,B,C".Split(',')`            | `["A","B","C"]`   |
|                         | `string.Join(delimiter, arr)` | Join array to string          | `string.Join("-", arr)`         | `"A-B-C"`         |
| **Comparison**          | `.Equals(str)`                | Compare case-sensitive        | `"Hi".Equals("hi")`             | `false`           |
|                         | `.Compare(str1,str2)`         | Returns int (-1,0,1)          | `string.Compare("a","b")`       | `-1`              |
| **Formatting**          | `string.Format()`             | Insert values                 | `string.Format("Age: {0}", 25)` | `"Age: 25"`       |
|                         | **Interpolation**             | Insert variables              | `$"Hi {name}"`                  | `"Hi Ali"`        |
| **Conversion**          | `ToCharArray()`               | Convert to char array         | `"Hi".ToCharArray()`            | `['H','i']`       |
| **Empty & Null**        | `string.IsNullOrEmpty()`      | Check empty string            | `string.IsNullOrEmpty("")`      | `true`            |
|                         | `string.IsNullOrWhiteSpace()` | Checks space-only string      | `"   "`                         | `true`            |


## Math

| **Category**         | **Method / Constant** | **Description**  | **Example**               | **Output / Note** |
| -------------------- | --------------------- | ---------------- | ------------------------- | ----------------- |
| **Constants**        | `Math.PI`             | Pi constant      | `Math.PI`                 | `3.1415926535`    |
|                      | `Math.E`              | Euler’s number   | `Math.E`                  | `2.7182818284`    |
| **Basic Operations** | `Math.Abs(x)`         | Absolute value   | `Math.Abs(-10)`           | `10`              |
|                      | `Math.Sign(x)`        | Sign (-1, 0, 1)  | `Math.Sign(-20)`          | `-1`              |
|                      | `Math.Max(a,b)`       | Larger value     | `Math.Max(5,9)`           | `9`               |
|                      | `Math.Min(a,b)`       | Smaller value    | `Math.Min(5,9)`           | `5`               |
| **Rounding**         | `Math.Round(x)`       | Round to nearest | `Math.Round(4.6)`         | `5`               |
|                      | `Math.Ceiling(x)`     | Round up         | `Math.Ceiling(4.1)`       | `5`               |
|                      | `Math.Floor(x)`       | Round down       | `Math.Floor(4.9)`         | `4`               |
|                      | `Math.Truncate(x)`    | Remove decimal   | `Math.Truncate(4.7)`      | `4`               |
| **Powers & Roots**   | `Math.Pow(x,y)`       | x raised to y    | `Math.Pow(2,3)`           | `8`               |
|                      | `Math.Sqrt(x)`        | Square root      | `Math.Sqrt(25)`           | `5`               |
| **Logarithmic**      | `Math.Log(x)`         | Natural log      | `Math.Log(10)`            | `2.302`           |
|                      | `Math.Log10(x)`       | Base-10 log      | `Math.Log10(100)`         | `2`               |
| **Trigonometric**    | `Math.Sin(radians)`   | Sine             | `Math.Sin(Math.PI/2)`     | `1`               |
|                      | `Math.Cos(radians)`   | Cosine           | `Math.Cos(0)`             | `1`               |
|                      | `Math.Tan(radians)`   | Tangent          | `Math.Tan(Math.PI/4)`     | `1`               |
|                      | `Math.Asin(x)`        | Inverse sine     | `Math.Asin(1)`            | `1.57 rad`        |
| **Random**           | `Random.Next()`       | Random integer   | `new Random().Next(1,10)` | `1–9`             |



## Types of clases


1. Regular Class

Can be instantiated using new.
Can contain fields, methods, properties, constructors.
Can participate in inheritance (unless sealed).

```c#
class Employee
{
    public string Name;
    public void Work()
    {
        Console.WriteLine($"{Name} is working");
    }
}

// Usage
Employee e = new Employee();
e.Name = "Alice";
e.Work();
```

2. Abstract Class

Cannot be instantiated directly.
Can have abstract methods (without body) and regular methods.
Child class must implement abstract methods.

```c#

abstract class Employee
{
    public string Name;
    public abstract void Work(); // Must be implemented in derived class
}

class Manager : Employee
{
    public override void Work()
    {
        Console.WriteLine($"{Name} is managing the team");
    }
}

// Usage
Manager m = new Manager();
m.Name = "Bob";
m.Work();

```

3. Static Class

Cannot be instantiated.
All members must be static.
Commonly used for utility/helper functions.

```c#
static class MathHelper
{
    public static int Add(int a, int b) => a + b;
}

// Usage
int sum = MathHelper.Add(5, 10);
Console.WriteLine(sum); // 15
```

4. Sealed Class

Cannot be inherited.
Useful when you want to prevent extension of a class.
```c#

sealed class Employee
{
    public string Name;
    public void Work()
    {
        Console.WriteLine($"{Name} is working");
    }
}

// class Manager : Employee {} // ❌ Not allowed
```

5. Partial Class

Allows splitting class definition across multiple files.
Useful in large projects or auto-generated code.
```c#

// File1.cs
partial class Employee
{
    public string Name;
}

// File2.cs
partial class Employee
{
    public void Work()
    {
        Console.WriteLine($"{Name} is working");
    }
}
```


| Class Type | Can Instantiate? | Can Inherit?        | Members           | Purpose                       |
| ---------- | ---------------- | ------------------- | ----------------- | ----------------------------- |
| Concrete   | Yes              | Yes                 | Instance & Static | Normal class                  |
| Abstract   | No               | Yes                 | Both              | Base class                    |
| Sealed     | Yes              | No                  | Both              | Prevent inheritance           |
| Static     | No               | No                  | Static only       | Utilities, helpers            |
| Partial    | Yes              | Yes                 | Both              | Split definition across files |
| Nested     | Yes              | Yes                 | Both              | Encapsulate helper class      |
| Generic    | Yes              | Yes                 | Both              | Type-safe reusable class      |
| Record     | Yes              | Yes (with `record`) | Both              | Immutable data storage        |


## Generic class

```c#

class Box<T>
{
    public T Content;
    public void ShowContent()
    {
        Console.WriteLine($"Content: {Content}");
    }
}

// Usage
Box<int> intBox = new Box<int>();
intBox.Content = 123;
intBox.ShowContent();  // Output: Content: 123

Box<string> strBox = new Box<string>();
strBox.Content = "Hello";
strBox.ShowContent();  // Output: Content: Hello

```


## Generic Methods

```c#
class Program
{
    public static T DisplayValue<T>(T value)
    {
        Console.WriteLine(value);
        return value;
    }

    static void Main()
    {
        DisplayValue<int>(100);       // Output: 100
        DisplayValue<string>("Hi");   // Output: Hi
    }
}

```

## Generic Collections

<details><summary><b>1. List<Type></b></summary>
Methods with Examples

| Method                                                         | Description                            | Return Type             | Example                                                                                                      |
| -------------------------------------------------------------- | -------------------------------------- | ----------------------- | ------------------------------------------------------------------------------------------------------------ |
| `Add(T item)`                                                  | Adds an element to the end of the list | `void`                  | `List<int> list = new(); list.Add(5);`                                                                       |
| `AddRange(IEnumerable<T> collection)`                          | Adds multiple elements                 | `void`                  | `list.AddRange(new int[]{6,7});`                                                                             |
| `AsReadOnly()`                                                 | Returns a read-only wrapper            | `ReadOnlyCollection<T>` | `var readOnly = list.AsReadOnly();`                                                                          |
| `BinarySearch(T item)`                                         | Searches a sorted list                 | `int`                   | `list.Sort(); int index = list.BinarySearch(5);`                                                             |
| `BinarySearch(T item, IComparer<T> comparer)`                  | Binary search with comparer            | `int`                   | `int idx = list.BinarySearch(5, Comparer<int>.Default);`                                                     |
| `Clear()`                                                      | Removes all elements                   | `void`                  | `list.Clear();`                                                                                              |
| `Contains(T item)`                                             | Checks if item exists                  | `bool`                  | `bool has5 = list.Contains(5);`                                                                              |
| `ConvertAll<TResult>(Converter<T, TResult> converter)`         | Converts to another type               | `List<TResult>`         | `List<string> strs = list.ConvertAll(x => x.ToString());`                                                    |
| `CopyTo(T[] array)`                                            | Copies all elements to array           | `void`                  | `int[] arr = new int[5]; list.CopyTo(arr);`                                                                  |
| `CopyTo(T[] array, int arrayIndex)`                            | Copies starting at array index         | `void`                  | `list.CopyTo(arr, 2);`                                                                                       |
| `CopyTo(int index, T[] array, int arrayIndex, int count)`      | Copies a range                         | `void`                  | `list.CopyTo(1, arr, 0, 2);`                                                                                 |
| `Exists(Predicate<T> match)`                                   | Checks if any element matches          | `bool`                  | `bool hasEven = list.Exists(x => x%2==0);`                                                                   |
| `Find(Predicate<T> match)`                                     | Returns first matching element         | `T`                     | `int firstEven = list.Find(x => x%2==0);`                                                                    |
| `FindAll(Predicate<T> match)`                                  | Returns all matching elements          | `List<T>`               | `var evens = list.FindAll(x => x%2==0);`                                                                     |
| `FindIndex(Predicate<T> match)`                                | Returns index of first match           | `int`                   | `int idx = list.FindIndex(x => x>5);`                                                                        |
| `FindIndex(int startIndex, Predicate<T> match)`                | Start searching from index             | `int`                   | `int idx = list.FindIndex(2, x=>x>5);`                                                                       |
| `FindIndex(int startIndex, int count, Predicate<T> match)`     | Search in range                        | `int`                   | `int idx = list.FindIndex(1,2,x=>x>5);`                                                                      |
| `FindLast(Predicate<T> match)`                                 | Returns last matching element          | `T`                     | `int lastEven = list.FindLast(x=>x%2==0);`                                                                   |
| `FindLastIndex(Predicate<T> match)`                            | Index of last match                    | `int`                   | `int idx = list.FindLastIndex(x=>x%2==0);`                                                                   |
| `FindLastIndex(int startIndex, Predicate<T> match)`            | Search backward from index             | `int`                   | `int idx = list.FindLastIndex(3,x=>x%2==0);`                                                                 |
| `FindLastIndex(int startIndex, int count, Predicate<T> match)` | Search backward in range               | `int`                   | `int idx = list.FindLastIndex(3,2,x=>x%2==0);`                                                               |
| `ForEach(Action<T> action)`                                    | Performs action on each element        | `void`                  | `list.ForEach(x=>Console.WriteLine(x));`                                                                     |
| `GetEnumerator()`                                              | Returns enumerator                     | `List<T>.Enumerator`    | `var enumerator = list.GetEnumerator(); while(enumerator.MoveNext()) Console.WriteLine(enumerator.Current);` |
| `IndexOf(T item)`                                              | Index of first occurrence              | `int`                   | `int idx = list.IndexOf(5);`                                                                                 |
| `IndexOf(T item, int index)`                                   | Start searching from index             | `int`                   | `int idx = list.IndexOf(5,1);`                                                                               |
| `IndexOf(T item, int index, int count)`                        | Search in range                        | `int`                   | `int idx = list.IndexOf(5,0,3);`                                                                             |
| `Insert(int index, T item)`                                    | Inserts element at index               | `void`                  | `list.Insert(1, 10);`                                                                                        |
| `InsertRange(int index, IEnumerable<T> collection)`            | Inserts collection at index            | `void`                  | `list.InsertRange(1, new int[]{11,12});`                                                                     |
| `LastIndexOf(T item)`                                          | Last occurrence index                  | `int`                   | `int idx = list.LastIndexOf(5);`                                                                             |
| `LastIndexOf(T item, int index)`                               | Backward search from index             | `int`                   | `int idx = list.LastIndexOf(5,3);`                                                                           |
| `LastIndexOf(T item, int index, int count)`                    | Backward search in range               | `int`                   | `int idx = list.LastIndexOf(5,3,2);`                                                                         |
| `Remove(T item)`                                               | Removes first occurrence               | `bool`                  | `list.Remove(5);`                                                                                            |
| `RemoveAll(Predicate<T> match)`                                | Removes all matching elements          | `int`                   | `int removed = list.RemoveAll(x=>x%2==0);`                                                                   |
| `RemoveAt(int index)`                                          | Removes element at index               | `void`                  | `list.RemoveAt(0);`                                                                                          |
| `RemoveRange(int index, int count)`                            | Removes range of elements              | `void`                  | `list.RemoveRange(0,2);`                                                                                     |
| `Reverse()`                                                    | Reverses entire list                   | `void`                  | `list.Reverse();`                                                                                            |
| `Reverse(int index, int count)`                                | Reverses a portion                     | `void`                  | `list.Reverse(1,3);`                                                                                         |
| `Sort()`                                                       | Sorts list                             | `void`                  | `list.Sort();`                                                                                               |
| `Sort(Comparison<T> comparison)`                               | Sorts using comparison                 | `void`                  | `list.Sort((a,b)=>b-a);`                                                                                     |
| `Sort(IComparer<T> comparer)`                                  | Sorts with comparer                    | `void`                  | `list.Sort(Comparer<int>.Default);`                                                                          |
| `Sort(int index, int count, IComparer<T> comparer)`            | Sorts portion with comparer            | `void`                  | `list.Sort(0,3,Comparer<int>.Default);`                                                                      |
| `ToArray()`                                                    | Copies to new array                    | `T[]`                   | `int[] arr = list.ToArray();`                                                                                |
| `TrimExcess()`                                                 | Reduces capacity if needed             | `void`                  | `list.TrimExcess();`                                                                                         |
| `TrueForAll(Predicate<T> match)`                               | Checks if all elements match           | `bool`                  | `bool allEven = list.TrueForAll(x=>x%2==0);`                                                                 |


Properties Examples

| Property          | Description                       | Example                                        |
| ----------------- | --------------------------------- | ---------------------------------------------- |
| `Capacity`        | Number of elements list can store | `int cap = list.Capacity; list.Capacity = 20;` |
| `Count`           | Number of elements in list        | `int cnt = list.Count;`                        |
| `Item[int index]` | Access element at index           | `int val = list[0]; list[0] = 100;`            |

</details>

<details><summary><b>2. SortedList<TKey, TValue></b></summary>
Properties

| Property         | Description                      | Example                                    |
| ---------------- | -------------------------------- | ------------------------------------------ |
| `Count`          | Number of key-value pairs        | `int cnt = sl.Count;`                      |
| `Capacity`       | Maximum elements before resizing | `int cap = sl.Capacity; sl.Capacity = 20;` |
| `Keys`           | Gets a collection of keys        | `var keys = sl.Keys;`                      |
| `Values`         | Gets a collection of values      | `var values = sl.Values;`                  |
| `Item[TKey key]` | Access value by key              | `int val = sl["Alice"]; sl["Alice"] = 30;` |
| `Comparer`       | Gets the comparer used for keys  | `var comparer = sl.Comparer;`              |


Methods

| Method                                    | Description                | Return Type                          | Example                                                                 |
| ----------------------------------------- | -------------------------- | ------------------------------------ | ----------------------------------------------------------------------- |
| `Add(TKey key, TValue value)`             | Adds a new key-value pair  | `void`                               | `sl.Add("Alice", 25);`                                                  |
| `Clear()`                                 | Removes all elements       | `void`                               | `sl.Clear();`                                                           |
| `ContainsKey(TKey key)`                   | Checks if key exists       | `bool`                               | `bool hasAlice = sl.ContainsKey("Alice");`                              |
| `ContainsValue(TValue value)`             | Checks if value exists     | `bool`                               | `bool has25 = sl.ContainsValue(25);`                                    |
| `IndexOfKey(TKey key)`                    | Returns index of key       | `int`                                | `int idx = sl.IndexOfKey("Alice");`                                     |
| `IndexOfValue(TValue value)`              | Returns index of value     | `int`                                | `int idx = sl.IndexOfValue(25);`                                        |
| `Remove(TKey key)`                        | Removes element by key     | `bool`                               | `sl.Remove("Alice");`                                                   |
| `RemoveAt(int index)`                     | Removes element by index   | `void`                               | `sl.RemoveAt(0);`                                                       |
| `TryGetValue(TKey key, out TValue value)` | Tries to get value by key  | `bool`                               | `if(sl.TryGetValue("Alice", out int val)) Console.WriteLine(val);`      |
| `GetEnumerator()`                         | Returns enumerator         | `SortedList<TKey,TValue>.Enumerator` | `foreach(var kvp in sl) Console.WriteLine(kvp.Key + ": " + kvp.Value);` |
| `EnsureCapacity(int min)`                 | Ensures capacity           | `int`                                | `sl.EnsureCapacity(50);`                                                |
| `TrimExcess()`                            | Reduces capacity if unused | `void`                               | `sl.TrimExcess();`                                                      |

</details>

<details><summary><b>3. Dictionary<TKey, TValue></b></summary>
Properties

| Property         | Description               | Example                                        |
| ---------------- | ------------------------- | ---------------------------------------------- |
| `Count`          | Number of key-value pairs | `int cnt = dict.Count;`                        |
| `Keys`           | Collection of all keys    | `var keys = dict.Keys;`                        |
| `Values`         | Collection of all values  | `var values = dict.Values;`                    |
| `Item[TKey key]` | Access value by key       | `dict["Alice"] = 25; int age = dict["Alice"];` |
| `Comparer`       | Gets the key comparer     | `var cmp = dict.Comparer;`                     |


Methods

| Method                                    | Description                                            | Return Type                          | Example                                                                 |
| ----------------------------------------- | ------------------------------------------------------ | ------------------------------------ | ----------------------------------------------------------------------- |
| `Add(TKey key, TValue value)`             | Adds a key-value pair                                  | `void`                               | `dict.Add("Alice", 25);`                                                |
| `Clear()`                                 | Removes all elements                                   | `void`                               | `dict.Clear();`                                                         |
| `ContainsKey(TKey key)`                   | Checks if key exists                                   | `bool`                               | `bool hasAlice = dict.ContainsKey("Alice");`                            |
| `ContainsValue(TValue value)`             | Checks if value exists                                 | `bool`                               | `bool has25 = dict.ContainsValue(25);`                                  |
| `Remove(TKey key)`                        | Removes element by key                                 | `bool`                               | `dict.Remove("Alice");`                                                 |
| `TryGetValue(TKey key, out TValue value)` | Tries to get value by key                              | `bool`                               | `if(dict.TryGetValue("Alice", out int val)) Console.WriteLine(val);`    |
| `GetEnumerator()`                         | Returns enumerator                                     | `Dictionary<TKey,TValue>.Enumerator` | `foreach(var kvp in dict) Console.WriteLine($"{kvp.Key}:{kvp.Value}");` |
| `EnsureCapacity(int capacity)`            | Ensures dictionary can hold at least this many entries | `int`                                | `dict.EnsureCapacity(50);`                                              |
| `TrimExcess()`                            | Reduces capacity if many unused entries                | `void`                               | `dict.TrimExcess();`                                                    |

</details>

<details><summary><b>4. SortedDictionary<TKey,TValue></b></summary>
Properties

| Property         | Description                     | Example                                    |
| ---------------- | ------------------------------- | ------------------------------------------ |
| `Count`          | Number of key-value pairs       | `int cnt = sd.Count;`                      |
| `Keys`           | Collection of keys              | `var keys = sd.Keys;`                      |
| `Values`         | Collection of values            | `var values = sd.Values;`                  |
| `Item[TKey key]` | Access value by key             | `sd["Alice"] = 25; int age = sd["Alice"];` |
| `Comparer`       | Gets the comparer used for keys | `var cmp = sd.Comparer;`                   |


Methods

| Method                                    | Description               | Return Type                                | Example                                                               |
| ----------------------------------------- | ------------------------- | ------------------------------------------ | --------------------------------------------------------------------- |
| `Add(TKey key, TValue value)`             | Adds a new key-value pair | `void`                                     | `sd.Add("Alice", 25);`                                                |
| `Clear()`                                 | Removes all elements      | `void`                                     | `sd.Clear();`                                                         |
| `ContainsKey(TKey key)`                   | Checks if key exists      | `bool`                                     | `bool hasAlice = sd.ContainsKey("Alice");`                            |
| `ContainsValue(TValue value)`             | Checks if value exists    | `bool`                                     | `bool has25 = sd.ContainsValue(25);`                                  |
| `Remove(TKey key)`                        | Removes element by key    | `bool`                                     | `sd.Remove("Alice");`                                                 |
| `TryGetValue(TKey key, out TValue value)` | Tries to get value by key | `bool`                                     | `if(sd.TryGetValue("Alice", out int val)) Console.WriteLine(val);`    |
| `GetEnumerator()`                         | Returns enumerator        | `SortedDictionary<TKey,TValue>.Enumerator` | `foreach(var kvp in sd) Console.WriteLine($"{kvp.Key}:{kvp.Value}");` |


</details>

<details><summary><b>5. Stack<Type></b></summary>
Properties

| Property     | Description                              | Example                             |
| ------------ | ---------------------------------------- | ----------------------------------- |
| `Count`      | Number of elements in the stack          | `int cnt = stack.Count;`            |
| `IsReadOnly` | Indicates if stack is read-only          | `bool readOnly = stack.IsReadOnly;` |
| `Peek`       | Returns the top element without removing | `T top = stack.Peek();`             |


Methods

| Method             | Description                           | Return Type           | Example                                               |
| ------------------ | ------------------------------------- | --------------------- | ----------------------------------------------------- |
| `Push(T item)`     | Adds an item to the top of the stack  | `void`                | `stack.Push(10);`                                     |
| `Pop()`            | Removes and returns the top item      | `T`                   | `int top = stack.Pop();`                              |
| `Peek()`           | Returns the top item without removing | `T`                   | `int top = stack.Peek();`                             |
| `Clear()`          | Removes all items                     | `void`                | `stack.Clear();`                                      |
| `Contains(T item)` | Checks if item exists in stack        | `bool`                | `bool has10 = stack.Contains(10);`                    |
| `ToArray()`        | Copies stack elements to a new array  | `T[]`                 | `int[] arr = stack.ToArray();`                        |
| `TrimExcess()`     | Reduces capacity if unused            | `void`                | `stack.TrimExcess();`                                 |
| `GetEnumerator()`  | Returns enumerator to iterate         | `Stack<T>.Enumerator` | `foreach(var item in stack) Console.WriteLine(item);` |

</details>

<details><summary><b>6. Queue<Type></b></summary>
Properties

| Property     | Description                                | Example                             |
| ------------ | ------------------------------------------ | ----------------------------------- |
| `Count`      | Number of elements in the queue            | `int cnt = queue.Count;`            |
| `IsReadOnly` | Indicates if queue is read-only            | `bool readOnly = queue.IsReadOnly;` |
| `Peek`       | Returns the front element without removing | `T front = queue.Peek();`           |


Methods

| Method             | Description                             | Return Type           | Example                                               |
| ------------------ | --------------------------------------- | --------------------- | ----------------------------------------------------- |
| `Enqueue(T item)`  | Adds an item to the end of the queue    | `void`                | `queue.Enqueue(10);`                                  |
| `Dequeue()`        | Removes and returns the front item      | `T`                   | `int front = queue.Dequeue();`                        |
| `Peek()`           | Returns the front item without removing | `T`                   | `int front = queue.Peek();`                           |
| `Clear()`          | Removes all items                       | `void`                | `queue.Clear();`                                      |
| `Contains(T item)` | Checks if item exists in the queue      | `bool`                | `bool has10 = queue.Contains(10);`                    |
| `ToArray()`        | Copies queue elements to a new array    | `T[]`                 | `int[] arr = queue.ToArray();`                        |
| `TrimExcess()`     | Reduces capacity if unused              | `void`                | `queue.TrimExcess();`                                 |
| `GetEnumerator()`  | Returns enumerator to iterate           | `Queue<T>.Enumerator` | `foreach(var item in queue) Console.WriteLine(item);` |

</details>

<details><summary><b>7. HashSet<Type></b></summary>
Properties

| Property     | Description                                 | Example                          |
| ------------ | ------------------------------------------- | -------------------------------- |
| `Count`      | Number of elements in the set               | `int cnt = hs.Count;`            |
| `Comparer`   | Gets the equality comparer used for the set | `var cmp = hs.Comparer;`         |
| `IsReadOnly` | Indicates if set is read-only               | `bool readOnly = hs.IsReadOnly;` |


Methods

| Method                                      | Description                                    | Return Type             | Example                                            |
| ------------------------------------------- | ---------------------------------------------- | ----------------------- | -------------------------------------------------- |
| `Add(T item)`                               | Adds an element if it doesn’t exist            | `bool`                  | `hs.Add(10);`                                      |
| `Remove(T item)`                            | Removes an element                             | `bool`                  | `hs.Remove(10);`                                   |
| `Contains(T item)`                          | Checks if element exists                       | `bool`                  | `bool has10 = hs.Contains(10);`                    |
| `Clear()`                                   | Removes all elements                           | `void`                  | `hs.Clear();`                                      |
| `UnionWith(IEnumerable<T> other)`           | Adds all elements from another collection      | `void`                  | `hs.UnionWith(new int[]{1,2,3});`                  |
| `IntersectWith(IEnumerable<T> other)`       | Keeps only elements present in both sets       | `void`                  | `hs.IntersectWith(new int[]{2,3,4});`              |
| `ExceptWith(IEnumerable<T> other)`          | Removes elements present in another collection | `void`                  | `hs.ExceptWith(new int[]{1,4});`                   |
| `SymmetricExceptWith(IEnumerable<T> other)` | Keeps elements in either set, but not both     | `void`                  | `hs.SymmetricExceptWith(new int[]{2,5});`          |
| `IsSubsetOf(IEnumerable<T> other)`          | Checks if set is subset of another             | `bool`                  | `hs.IsSubsetOf(new int[]{1,2,3,4});`               |
| `IsSupersetOf(IEnumerable<T> other)`        | Checks if set is superset of another           | `bool`                  | `hs.IsSupersetOf(new int[]{2,3});`                 |
| `SetEquals(IEnumerable<T> other)`           | Checks if sets have same elements              | `bool`                  | `hs.SetEquals(new int[]{2,3,5});`                  |
| `Overlaps(IEnumerable<T> other)`            | Checks if sets share any elements              | `bool`                  | `hs.Overlaps(new int[]{3,4});`                     |
| `GetEnumerator()`                           | Returns enumerator                             | `HashSet<T>.Enumerator` | `foreach(var item in hs) Console.WriteLine(item);` |


</details>

<details><summary><b>8. LinkedList<Type></b></summary>
Properties

| Property     | Description                    | Example                                   |
| ------------ | ------------------------------ | ----------------------------------------- |
| `Count`      | Number of nodes in the list    | `int cnt = list.Count;`                   |
| `First`      | Gets the first node            | `LinkedListNode<int> first = list.First;` |
| `Last`       | Gets the last node             | `LinkedListNode<int> last = list.Last;`   |
| `IsReadOnly` | Indicates if list is read-only | `bool readOnly = list.IsReadOnly;`        |


Methods

| Method                                       | Description                       | Return Type                | Example                                              |
| -------------------------------------------- | --------------------------------- | -------------------------- | ---------------------------------------------------- |
| `AddFirst(T value)`                          | Adds a node at the start          | `LinkedListNode<T>`        | `list.AddFirst(10);`                                 |
| `AddLast(T value)`                           | Adds a node at the end            | `LinkedListNode<T>`        | `list.AddLast(20);`                                  |
| `AddBefore(LinkedListNode<T> node, T value)` | Adds before a specific node       | `LinkedListNode<T>`        | `list.AddBefore(node, 15);`                          |
| `AddAfter(LinkedListNode<T> node, T value)`  | Adds after a specific node        | `LinkedListNode<T>`        | `list.AddAfter(node, 25);`                           |
| `Remove(T value)`                            | Removes first occurrence of value | `bool`                     | `list.Remove(10);`                                   |
| `RemoveFirst()`                              | Removes the first node            | `void`                     | `list.RemoveFirst();`                                |
| `RemoveLast()`                               | Removes the last node             | `void`                     | `list.RemoveLast();`                                 |
| `Find(T value)`                              | Finds first node with value       | `LinkedListNode<T>`        | `var node = list.Find(20);`                          |
| `FindLast(T value)`                          | Finds last node with value        | `LinkedListNode<T>`        | `var node = list.FindLast(20);`                      |
| `Contains(T value)`                          | Checks if value exists            | `bool`                     | `list.Contains(15);`                                 |
| `Clear()`                                    | Removes all nodes                 | `void`                     | `list.Clear();`                                      |
| `GetEnumerator()`                            | Returns enumerator                | `LinkedList<T>.Enumerator` | `foreach(var item in list) Console.WriteLine(item);` |

</details>


<details><summary><b>Array<Type></b></summary>

| Method                                    | Description                                | Return Type             | Example                                                   |
| ----------------------------------------- | ------------------------------------------ | ----------------------- | --------------------------------------------------------- |
| **Array.Sort(array)**                     | Sorts the array in ascending order.        | `void`                  | `Array.Sort(nums);`                                       |
| **Array.Reverse(array)**                  | Reverses the array order.                  | `void`                  | `Array.Reverse(nums);`                                    |
| **Array.IndexOf(array, value)**           | Returns first index of value.              | `int`                   | `int i = Array.IndexOf(nums, 4);`                         |
| **Array.LastIndexOf(array, value)**       | Returns last index of value.               | `int`                   | `int i = Array.LastIndexOf(nums, 4);`                     |
| **Array.Copy(src, dst, len)**             | Copies elements from one array to another. | `void`                  | `Array.Copy(a, b, 5);`                                    |
| **Array.Clone()**                         | Creates a shallow copy.                    | `object`                | `int[] copy = (int[])nums.Clone();`                       |
| **Array.Clear(array, index, len)**        | Resets elements to default.                | `void`                  | `Array.Clear(nums, 0, 3);`                                |
| **Array.Resize(ref array, newSize)**      | Changes size (creates new array).          | `void`                  | `Array.Resize(ref nums, 10);`                             |
| **Array.Exists(array, predicate)**        | Checks if any element matches condition.   | `bool`                  | `bool ok = Array.Exists(nums, x => x > 10);`              |
| **Array.Find(array, predicate)**          | Returns first match.                       | `T`                     | `int v = Array.Find(nums, x => x > 10);`                  |
| **Array.FindAll(array, predicate)**       | Returns all matches.                       | `T[]`                   | `int[] result = Array.FindAll(nums, x => x > 10);`        |
| **Array.FindIndex(array, predicate)**     | Gets index of first match.                 | `int`                   | `int i = Array.FindIndex(nums, x => x == 5);`             |
| **Array.FindLast(array, predicate)**      | Gets last matching element.                | `T`                     | `int v = Array.FindLast(nums, x => x > 10);`              |
| **Array.FindLastIndex(array, predicate)** | Gets last matching index.                  | `int`                   | `int i = Array.FindLastIndex(nums, x => x == 5);`         |
| **Array.TrueForAll(array, predicate)**    | Checks if all elements match condition.    | `bool`                  | `bool ok = Array.TrueForAll(nums, x => x >= 0);`          |
| **Array.ForEach(array, action)**          | Executes action for each element.          | `void`                  | `Array.ForEach(nums, x => Console.WriteLine(x));`         |
| **Array.BinarySearch(array, value)**      | Binary search in sorted array.             | `int`                   | `int i = Array.BinarySearch(nums, 10);`                   |
| **Array.ConvertAll(src, converter)**      | Converts elements to another type.         | `TOutput[]`             | `string[] s = Array.ConvertAll(nums, x => x.ToString());` |
| **Array.AsReadOnly(array)**               | Creates read-only wrapper.                 | `ReadOnlyCollection<T>` | `var ro = Array.AsReadOnly(nums);`                        |
| **Array.Fill(array, value)**              | Sets all elements to value.                | `void`                  | `Array.Fill(nums, 7);`                                    |
| **Array.Empty<T>()**                      | Returns an empty array of type T.          | `T[]`                   | `var empty = Array.Empty<int>();`                         |


</details>


## Serialization

<details><summary><b>Json<Type></b></summary>

 ```c#
    unsing System.Text.Json;

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

 ```
</details>


<details><summary><b>XML<Type></b></summary>

 ```c#
    public class XmlHandler
    {
        public static void SerializeToXml(Person person)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            StreamWriter sw = new StreamWriter("demo.xml");
            xmlSerializer.Serialize(sw,person);
            sw.Close();

            Console.WriteLine("XML file is ready !");

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

 ```
</details>

## Lambda

```c#
Func<int ,int ,string> temp = (a,b) => a + " " + b;
Func<int, int, int> multiplyAndAdd = (a, b) =>
{
    int product = a * b;
    return product + 10;
};

Console.WriteLine(multiplyAndAdd(2, 3)); // Output: 16
```

Action is used when a lambda doesn’t return a value

```c#
Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
greet("Alice");
```

Capturing Variables(Closures)

```c#
int factor = 3;
Func<int, int> multiply = x => x * factor;
```

Lambdas with Async  
```c#
Func<Task> asyncLambda = async () =>
{
    await Task.Delay(1000);
    Console.WriteLine("Finished after 1 second!");
};
```

## Extension Methods

- An extension method in C# is a special kind of static method of static class that can be called as if it were an instance method on the type it extends.
- Extension methods are defined in a static class.
- The first parameter starts with the "this" keyword, followed by the type you want to extend.
- You cannot override existing methods with extension methods.
- Extension methods are often used to add helper or utility methods.
- How to Declare an Extension Method

```c#
public static class ClassName{
    public static returnType MethodName(this TypeToExtend obj, parameters) {

    }
}
```
### Types of Extension Methods

<details><summary>Extension Method on Built-in Type</summary>

- In this type of extension method, we can add new methods to built-in types like string, int, double, etc., without modifying their original definition.

```c#
using System;
public static class IntExtensions {
   // Extension method for int type
   public static bool IsEven(this int number){
      return number % 2 == 0;
   }
}

class Program {
   static void Main(){
      int num = 10;
      // Output: True
      Console.WriteLine(num.IsEven());
   }
}
```
</details>


<details><summary>Extension Method on User-defined Class</summary>

- An extension method on a user-defined class can help you create an extension method for your own classes to add extra functionality without modifying the class directly.

```c#
public class Student {
   public string Name { get; set; }
}

public static class StudentExtensions {
   // Extension method for Student class
   public static void DisplayWelcome(this Student s){
      Console.WriteLine($"Welcome, {s.Name}!");
   }
}
```
</details>


<details><summary>Extension Method on Interface</summary>

- In this type, we can define extension methods for interfaces, which means all those classes that implement a given interface can use the extension method.

```c#
public interface IAnimal {
   void Speak();
}

public static class AnimalExtensions {
   // Extension method for IAnimal interface
   public static void Eat(this IAnimal animal) {
      Console.WriteLine("Animal is eating...");
   }
}
```
</details>



## LinQ

| Function             | Explanation                                 | Example                                                                         |
| -------------------- | ------------------------------------------- | ------------------------------------------------------------------------------- |
| Where()              | Filters elements based on condition.        | `numbers.Where(n => n > 5)`                                                     |
| OfType<T>()          | Returns elements of a specified type.       | `list.OfType<int>()`                                                            |
| Select()             | Transforms each element.                    | `numbers.Select(n => n * n)`                                                    |
| SelectMany()         | Flattens nested collections.                | `depts.SelectMany(d => d.Employees)`                                            |
| OrderBy()            | Sorts ascending.                            | `people.OrderBy(p => p.Name)`                                                   |
| OrderByDescending()  | Sorts descending.                           | `people.OrderByDescending(p => p.Age)`                                          |
| ThenBy()             | Secondary sort (asc).                       | `people.OrderBy(p=>p.Last).ThenBy(p=>p.First)`                                  |
| ThenByDescending()   | Secondary sort (desc).                      | `people.OrderBy(p=>p.City).ThenByDescending(p=>p.Age)`                          |
| GroupBy()            | Groups elements by key.                     | `people.GroupBy(p => p.City)`                                                   |
| Join()               | Inner join between sequences.               | `customers.Join(orders,c=>c.Id,o=>o.CustId,(c,o)=>new{c.Name,o.Product})`       |
| GroupJoin()          | Groups join results (left join style).      | `customers.GroupJoin(orders,c=>c.Id,o=>o.CustId,(c,os)=>new{c.Name,Orders=os})` |
| Distinct()           | Removes duplicates.                         | `numbers.Distinct()`                                                            |
| Union()              | Combines two sequences, removes duplicates. | `a.Union(b)`                                                                    |
| Intersect()          | Common elements of sequences.               | `a.Intersect(b)`                                                                |
| Except()             | Elements in first sequence not in second.   | `a.Except(b)`                                                                   |
| Any()                | True if any element matches.                | `nums.Any(n => n > 10)`                                                         |
| All()                | True if all match condition.                | `nums.All(n => n > 0)`                                                          |
| Contains()           | Checks if element exists.                   | `nums.Contains(5)`                                                              |
| First()              | Returns first element; error if empty.      | `nums.First()`                                                                  |
| FirstOrDefault()     | First or default value.                     | `nums.FirstOrDefault()`                                                         |
| Last()               | Last element; error if empty.               | `nums.Last()`                                                                   |
| LastOrDefault()      | Last or default value.                      | `nums.LastOrDefault()`                                                          |
| Single()             | Exactly one match; error if 0 or >1.        | `nums.Single(n => n == 5)`                                                      |
| SingleOrDefault()    | One match or default.                       | `nums.SingleOrDefault(n => n == 5)`                                             |
| ElementAt()          | Returns element at index.                   | `nums.ElementAt(2)`                                                             |
| ElementAtOrDefault() | Returns default if index invalid.           | `nums.ElementAtOrDefault(100)`                                                  |
| Count()              | Counts elements; optional condition.        | `nums.Count(n => n > 5)`                                                        |
| Sum()                | Sums values.                                | `nums.Sum()`                                                                    |
| Average()            | Average of values.                          | `nums.Average()`                                                                |
| Min()                | Minimum value.                              | `nums.Min()`                                                                    |
| Max()                | Maximum value.                              | `nums.Max()`                                                                    |
| Aggregate()          | Custom aggregator.                          | `nums.Aggregate((a,b)=>a+b)`                                                    |
| ToList()             | Converts to List.                           | `nums.ToList()`                                                                 |
| ToArray()            | Converts to Array.                          | `nums.ToArray()`                                                                |
| Take()               | Takes first N elements.                     | `nums.Take(3)`                                                                  |
| Skip()               | Skips first N elements.                     | `nums.Skip(3)`                                                                  |
| TakeWhile()          | Takes while condition true.                 | `nums.TakeWhile(n < 10)`                                                        |
| SkipWhile()          | Skips while condition true.                 | `nums.SkipWhile(n < 10)`                                                        |
| Reverse()            | Reverses sequence.                          | `nums.Reverse()`                                                                |


## ORM

### Table Management
| Method                        | Description                                 | Example                                  |
| ----------------------------- | ------------------------------------------- | ---------------------------------------- |
| `CreateTable<T>()`            | Creates table for type T (throws if exists) | `db.CreateTable<Employee>();`            |
| `CreateTableIfNotExists<T>()` | Creates table if it doesn’t exist           | `db.CreateTableIfNotExists<Employee>();` |
| `DropTable<T>()`              | Drops table                                 | `db.DropTable<Employee>();`              |
| `DropTableIfExists<T>()`      | Drops table if exists                       | `db.DropTableIfExists<Employee>();`      |
| `AlterTable<T>()`             | Updates table schema                        | `db.AlterTable<Employee>();`             |
| `TruncateTable<T>()`          | Deletes all rows                            | `db.TruncateTable<Employee>();`          |

### Insert / Create
| Method                             | Description                           | Example                                              |
| ---------------------------------- | ------------------------------------- | ---------------------------------------------------- |
| `Insert(obj)`                      | Inserts a single object               | `db.Insert(new Employee { Name="John" });`           |
| `InsertAll(IEnumerable<T>)`        | Inserts multiple objects              | `db.InsertAll(listOfEmployees);`                     |
| `Insert(obj, selectIdentity:true)` | Inserts and returns auto-increment ID | `int id = db.Insert(emp, true);`                     |
| `InsertOnly(obj, fields)`          | Inserts only specific fields          | `db.InsertOnly(() => new Employee { Name="John" });` |

### Update

| Method                              | Description                        | Example                                                            |
| ----------------------------------- | ---------------------------------- | ------------------------------------------------------------------ |
| `Update(obj)`                       | Updates full object by primary key | `db.Update(emp);`                                                  |
| `UpdateOnly(obj, fields, where)`    | Updates only selected fields       | `db.UpdateOnly(() => new Employee { Age=30 }, x=>x.Name=="John");` |
| `UpdateAdd<T>(field, value, where)` | Increment numeric fields           | `db.UpdateAdd(() => new Employee { Age=1 }, x=>x.Id==1);`          |


### Delete
| Method                 | Description                     | Example                             |
| ---------------------- | ------------------------------- | ----------------------------------- |
| `Delete(obj)`          | Deletes object by primary key   | `db.Delete(emp);`                   |
| `Delete<T>(predicate)` | Deletes rows matching condition | `db.Delete<Employee>(x=>x.Age<25);` |
| `DeleteAll<T>()`       | Deletes all rows                | `db.DeleteAll<Employee>();`         |
| `DeleteById<T>(id)`    | Deletes row by primary key      | `db.DeleteById<Employee>(1);`       |


### Select / Read
| Method                          | Description                                 | Example                                                    |
| ------------------------------- | ------------------------------------------- | ---------------------------------------------------------- |
| `Select<T>()`                   | Returns all rows                            | `var emps = db.Select<Employee>();`                        |
| `Select<T>(predicate)`          | Returns rows matching condition             | `var itEmps = db.Select<Employee>(x=>x.Department=="IT");` |
| `Single<T>(predicate)`          | Returns single row; throws if none/multiple | `var emp = db.Single<Employee>(x=>x.Id==1);`               |
| `SingleById<T>(id)`             | Returns row by PK                           | `var emp = db.SingleById<Employee>(1);`                    |
| `Exists<T>(predicate)`          | Checks if row exists                        | `bool exist = db.Exists<Employee>(x=>x.Name=="John");`     |
| `Count<T>()`                    | Returns total rows                          | `int total = db.Count<Employee>();`                        |
| `Count<T>(predicate)`           | Returns count with condition                | `int count = db.Count<Employee>(x=>x.Age>30);`             |
| `LoadSelect<T>()`               | Loads rows with referenced children         | `var depts = db.LoadSelect<Department>();`                 |


### Raw SQL Execution

| Method                            | Description                 | Example                                                                    |
| --------------------------------- | --------------------------- | -------------------------------------------------------------------------- |
| `ExecuteSql(sql, params)`         | Executes SQL (non-query)    | `db.ExecuteSql("UPDATE Employee SET Age=30");`                             |
| `SqlScalar<T>(sql, params)`       | Returns single scalar value | `int cnt = db.SqlScalar<int>("SELECT COUNT(*) FROM Employee");`            |
| `SqlList<T>(sql, params)`         | Returns list from SQL       | `var emps = db.SqlList<Employee>("SELECT * FROM Employee");`               |
| `SqlDictionary<K,V>(sql, params)` | Returns dictionary from SQL | `var dict = db.SqlDictionary<int,string>("SELECT Id,Name FROM Employee");` |


### Transactions
| Method              | Description            | Example                                                       |
| ------------------- | ---------------------- | ------------------------------------------------------------- |
| `OpenTransaction()` | Begins a transaction   | `using(var trans=db.OpenTransaction()){... trans.Commit(); }` |
| `Commit()`          | Commits transaction    | `trans.Commit();`                                             |
| `Rollback()`        | Rolls back transaction | `trans.Rollback();`                                           |


### Fluent / LINQ Queries

| Method                    | Description           | Example                                                                |
| ------------------------- | --------------------- | ---------------------------------------------------------------------- |
| `db.From<T>()`            | Starts a fluent query | `var q = db.From<Employee>();`                                         |
| `Where(expr)`             | Adds WHERE clause     | `var q = db.From<Employee>().Where(x=>x.Age>30);`                      |
| `OrderBy(expr)`           | ORDER BY ASC          | `db.Select(q.OrderBy(x=>x.Name));`                                     |
| `OrderByDescending(expr)` | ORDER BY DESC         | `db.Select(q.OrderByDescending(x=>x.Age));`                            |
| `ThenBy(expr)`            | Secondary sort ASC    | `db.Select(q.OrderBy(x=>x.Name).ThenBy(x=>x.Age));`                    |
| `Limit(skip, rows)`       | Pagination            | `db.Select(q.Limit(10,5));`                                            |
| `Join<T1,T2>(...)`        | Joins another table   | `var q = db.From<Employee>().Join<Department>((e,d)=>e.DeptId==d.Id);` |


## Cryptography 

### AES (Advanced Encryption Standard)

- Uses the same secret key for encryption and decryption.
- symmetric cryptographic algorithm.

```c#
using (Aes aes = Aes.Create())
{
    aes.Key = key;
    aes.IV = iv;

    ICryptoTransform encryptor = aes.CreateEncryptor();
    byte[] encrypted = encryptor.TransformFinalBlock(data, 0, data.Length);
}
```

### RSA (Rivest–Shamir–Adleman)

- It uses two keys:
    1. Public Key – can be shared openly; used to encrypt data or verify signatures
    2. Private Key – must be kept secret; used to decrypt data or sign data
- asymmetric cryptographic algorithm.

```c#
using System.Security.Cryptography;

RSA rsa = RSA.Create(2048);  // Key size 2048-bit

string publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
string privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());

Console.WriteLine("Public Key: " + publicKey);
Console.WriteLine("Private Key: " + privateKey);
```
