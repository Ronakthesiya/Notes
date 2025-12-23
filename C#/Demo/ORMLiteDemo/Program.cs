using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ORMLiteDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbFactory = new OrmLiteConnectionFactory(
                    "Server=127.0.0.1;Port=3306;Database=OrmLiteDemoDB;User Id=Admin;Password=gs@123;",
                    MySqlDialect.Provider
                );


            try
            {
                using (var db = dbFactory.Open())
                {
                    db.DropTable<Employee1>();
                    db.CreateTable<Employee>();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exceptions");
                throw;
            }

            //using (var db = dbFactory.Open())
            //{
            //    db.CreateTableIfNotExists<Employee>();
            //}
            //    Console.WriteLine("Employee table created successfully!");

            //using (var db = dbFactory.Open())
            //{
            //    db.Insert(new Employee
            //    {
            //        Name = "John Doe",
            //        Age = 30,
            //        Department = "IT"
            //    });

            //}
            Console.WriteLine("Inserted one employee.");


            //using (var db = dbFactory.Open())
            //{


            //var emp2 = db.SingleById<Employee>(1);

            //Console.WriteLine(emp2.Age);

            //emp2.Age = 1000;

            //db.Update(emp2);

            //db.Delete<Employee>(e => e.Id == 1);

            //db.AlterTable<Employee>("drop COLUMN temp ");

            //db.DropTable<Employee>();

            //db.Insert<Employee>(new Employee { Age = 1 , Department = "asdf", Name="sdg"},true);

            //db.Update<Employee>(new Employee { Age = 1 , Department = "IT" , Name = "RONAK" , Id = 4});

            //db.UpdateOnly<Employee>(() => new Employee { Age = 3 }, x => x.Id == 2);

            //db.Delete<Employee>(x => x.Age<5);

            //db.DeleteById<Employee>(3);


            //var emplist = db.Select<Employee>();

            //var emplist = db.Select<Employee>(x => x.Age > 30);

            //var emp = db.Single<Employee>(x => x.Age>=30);

            //var emp = db.SingleById<Employee>(4);

            //foreach (var emp in emplist)
            //{
            //    Console.WriteLine(emp.Name);
            //    Console.WriteLine(emp.Age);
            //    Console.WriteLine(emp.Department);
            //}

            //Console.WriteLine(db.Exists<Employee>(x => x.Name == "ronak"));

            //Console.WriteLine(db.Count<Employee>(x => x.Name == "ronak"));

            //db.DropTable<Employee>();

            //db.CreateTable<Employee>();

            //db.Insert<Employee>(new Employee { Age = 1, DepartmentId = 1, Name = "demo1" }, true);
            //db.Insert<Employee>(new Employee { Age = 10, DepartmentId = 2, Name = "demo3" }, true);
            //db.Insert<Employee>(new Employee { Age = 100, DepartmentId = 1, Name = "demo2" }, true);
            //db.Insert<Employee>(new Employee { Age = 1000, DepartmentId = 2, Name = "demo2" }, true);


            //db.CreateTable<Department>();

            //List<Department> departmentList = new List<Department>(){new Department()
            //{
            //    Id = 1,
            //    name = "IT"
            //},
            //new Department()
            //{
            //    Id= 2,
            //    name = "ML"
            //}
            //} ;

            //db.InsertAll(departmentList);

            //var dept = db.LoadSelect<Department>();

            //foreach (var d in dept)
            //{
            //    Console.WriteLine($"Department: {d.name}");

            //        foreach (var emp in d.emps)
            //        {
            //            Console.WriteLine($"   Employee: {emp.Name}");
            //        }
            //}
            //}


            //var emplist = db.Execute("insert into department values(3,'temptemp')");

            //var emplist = db.SqlScalar<string>("select * from employee");

            //var emplist = db.SqlList<Employee>("select * from employee");

            //using(var trans = db.OpenTransaction())
            //{
            //    trans.Rollback();
            //    trans.Commit();
            //}

            //var q = db.From<Employee>().Where(a => a.Age > 1);

            //var emplist = db.Select(q.OrderByDescending(x => x.Age).Limit(2,1));



            //Console.WriteLine(emplist);

            //foreach (var emp in emplist)
            //{
            //Console.WriteLine(emp.Name);
            //Console.WriteLine(emp.Age);
            //Console.WriteLine(emp.DepartmentId);
            //    Console.WriteLine(emp);
            //}

            //var s = Console.ReadKey();
            //Console.WriteLine(s);
            Console.ReadKey();
            //}
        }
    }
}