using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    public class Employee
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Department
    {
        public string Name { get; set; }    
        public int Id { get; set; }
    }
    internal class Linq
    {
        public static void demo()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Error when you modify : 
            //var newlist = numbers.Where(x => x > 1);

            //numbers.Remove(3);

            //foreach (var num in newlist)
            //{
            //    Console.WriteLine(num);
            //    if (num == 8)
            //    {
            //        numbers.Remove(num); // give error of modify number
            //    }
            //}
            numbers.Single(x => x>1); // Error mulityple match

            // where
            numbers.Where((val, index) => val == index);
            // oftype
            numbers.OfType<int>();


            // select
            numbers.Select(val => val * val);
            // selectMany
            var listOfLists = new List<List<int>> {
                new List<int> { 1, 2 },
                new List<int> { 3, 4 },
                new List<int> { 5, 6 }
            };
            var flatList = listOfLists.SelectMany(innerList => innerList); // [1, 2, 3, 4, 5, 6]


            // orderby
            numbers.OrderBy(val => val);
            // orderbydescending
            numbers.OrderByDescending(val => val);
            // thenby
            numbers.OrderBy(val => val).ThenBy(val => val);
            // ThenByDescending
            numbers.OrderBy(val => val).ThenByDescending(val => val);


            // groupby
            var employees = new List<Employee>
            {
                new Employee { Name = "Alice", DepartmentId = 1 },
                new Employee { Name = "Bob", DepartmentId = 2 },
                new Employee { Name = "Charlie", DepartmentId = 2 },
                new Employee { Name = "Eva", DepartmentId = 1 }
            };

            var deptCounts = employees
                                    .GroupBy(e => e.DepartmentId)
                                    .Select(g => new
                                    {
                                        Department = g.Key,
                                        Count = g.Count()
                                    });

            foreach (var d in deptCounts)
            {
                Console.WriteLine($"{d.Department}: {d.Count}");
            }


            //join

            var departments = new List<Department>
            {
                new Department { Id = 1, Name = "IT" },
                new Department { Id = 2, Name = "HR" }
            };

            var joinresult = employees.Join(
                    departments,
                    e => e.DepartmentId,
                    d => d.Id,
                    (e, d) => new { emp = e.Name, dept = d.Name }
                );

            foreach (var item in joinresult)
            {
                Console.WriteLine($"{item.emp} - {item.dept}");
            }


            // groupjoin

            var groupjoinresult = departments.GroupJoin(
                    employees,
                    d => d.Id,
                    e => e.DepartmentId,
                    (d, e) => new { emp = e, dept = d.Name }
                );

            foreach (var item in groupjoinresult)
            {
                Console.WriteLine($"{item.dept} :- ");

                foreach(var val in item.emp)
                {
                    Console.WriteLine(val.Name);
                }
            }


            //Distinct
            numbers.Distinct();

            //Union
            numbers.Union(numbers);

            //intersect
            numbers.Intersect(numbers);

            //Except
            numbers.Except(numbers);


            //Any
            numbers.Any(val => val > 0);

            //All
            numbers.All(val => val > 0);

            //Contains
            numbers.Contains(10);


            //First() / FirstOrDefault() / Last() / LastOrDefault()
            numbers.FirstOrDefault(val => val > 0);

            //Single() / SingleOrDefault()
            numbers.Single(n => n == 5);

            //ElementAt() / ElementAtOrDefault()
            numbers.ElementAt(2);


            //Count()
            numbers.Count(n => n > 5);

            //Sum() / Average() / Min() / Max()

            numbers.Sum();
            numbers.Average();
            numbers.Min();

            //Aggregate()
            numbers.Aggregate((a, b) => a * b);



            var q = employees.
                OrderBy(e => e.Name)
                .GroupBy(
                e => e.DepartmentId
                );

        }

    }
}
