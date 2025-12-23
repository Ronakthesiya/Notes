using ServiceStack.DataAnnotations;
using System.Collections.Generic;

public class Employee
{
    [AutoIncrement]        // PK auto increment
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public int Age { get; set; }

    public int DepartmentId { get; set; }

    [Reference]
    public Department Department { get; set; }

    

}

public class Employee1
{
    [AutoIncrement]        // PK auto increment
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public int Age { get; set; }

    public int DepartmentId { get; set; }

    [Reference]
    public Department Department { get; set; }



}

public class Department
{
    public int Id { get; set; }

    public string name { get; set; }

    [Reference]
    public List<Employee> emps { get; set; }
}
