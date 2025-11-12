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

### StreamReader 

```c#
using (StreamReader reader = new StreamReader("data.txt")) {
    string line;
    while ((line = reader.ReadLine()) != null) {
        Console.WriteLine(line);
    }
}
```

### Create a File

File.CreateText()

```c#
using (StreamWriter writer = File.CreateText("data.txt")) {
    writer.WriteLine("This is the first line.");
    writer.WriteLine("This is the second line.");
}
```

### Append to a File

```c#
 using (StreamWriter writer = File.AppendText("data.txt")) {
    writer.WriteLine("This line is appended.");
}
```


### Delete a File

```c#
string path = "data.txt";
if (File.Exists(path)) {
    File.Delete(path);
    Console.WriteLine("File deleted.");
} else {
    Console.WriteLine("File does not exist.");
}
```


### Check if a File Exists

```c#
string path = "data.txt";
if (File.Exists(path)) {
    Console.WriteLine("File exists.");
} else {
    Console.WriteLine("File does not exist.");
}
```

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

foreach (DataRow row in sorted)
{
    Console.WriteLine($"{row["Name"]} - {row["Marks"]}");
}


// Update
dt.Rows[0]["Marks"] = 88.5;

// Delete
dt.Rows[2].Delete();


dt.AcceptChanges(); 


DataTable copy = dt.Copy();   // Copies both structure + data
DataTable clone = dt.Clone(); // Copies only structure (no data)

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

1. List<T>
2. Dictionary<TKey, TValue>
3. Stack<T>
4. HashSet<T>
5. SortedList<TKey, TValue>


## Serialization

<!-- baki -->

## Lambda syntax


