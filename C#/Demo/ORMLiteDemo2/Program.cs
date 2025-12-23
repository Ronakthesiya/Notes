using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Legacy;
using ServiceStack.OrmLite.MySql;
using System;
using System.Collections.Generic;
using System.Linq;

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


            using (var db = dbFactory.Open())
            {

                var res = db.GetTableColumns<Employee>();

                foreach (var item in res)
                {
                  
                    Console.WriteLine(item.ColumnName+" "+item.DataType);
                }

                //var cnt = db.Count<Employee>();

                //Console.WriteLine(cnt);
                //var q1 = db.From<Employee>().Where(e => e.Age > 1);

                //Console.WriteLine(q1.ToSelectStatement());
                //Console.WriteLine(q1.Params[0].Value);

                //Console.WriteLine();
                //Console.WriteLine(q1.ToMergedParamsSelectStatement());

                //Console.WriteLine();
                //Console.WriteLine(db.GetLastSql());

                //using (var tran = db.OpenTransaction())
                //{
                //    var sv = tran.SavePoint("FirstSavePoint");

                //    db.Insert(new Employee() { Name = "abcd" });

                //    sv.Rollback();

                //    db.Insert(new Employee() { Name = "abcd" });

                //    tran.Rollback();
                //}

                //cnt = db.Count<Employee>();

                //Console.WriteLine(cnt);



                //db.CreateTable<Employee>(overwrite: false);

                //var q = db.From<Employee>()
                //              .Join<Department>((e, d) => e.DepartmentId == d.Id);


                //var q1 = db.LoadSelect(q);

                //foreach (var e in q1)
                //{   
                //    Console.Write(e.Name);
                //    Console.Write(e.Age);
                //    Console.WriteLine(e.Department.name);
                //}

                //int[] arr = { 1, 2, 3, 4 };

                //var val1 = db.From<Employee>().Select(e => Sql.Max(e.Age));

                //var val = db.SqlScalar<int>(val1);

                //var emp = db.LoadSelect<Employee>(e => e.Age == val);

                //foreach (var e in emp)
                //{
                //    Console.WriteLine(e.Name);
                //    Console.WriteLine(e.Age);
                //    Console.WriteLine(e.Department.name);
                //}

                //db.CreateTable<Employee>();

                //var val = db.Insert(new Employee() { Name = "Ronak" }, selectIdentity:true);

                //Console.WriteLine(val);

                //db.UpdateOnly(() => new Employee() {Name = "RRRR" },e => e.Id==7);


                //Console.WriteLine(emp.Count);

                //db.AlterTable<Employee1>("add column temp varchar(50)");

                //var e = db.Single<Employee>(x => x.Id < 8);
                //db.AlterTable<Employee>("drop COLUMN temp");
                //Console.WriteLine(e.Id);

                //using (var tran = db.OpenTransaction())
                //{

                //    //db.Insert<Employee>(new Employee() { });
                //    db.ExecuteSql("SavePoint p1");


                //    db.ExecuteSql("ROLLBACK TO SAVEPOINT p1");

                //    tran.Commit();
                //}


                //var emp = db.SqlList<Employee>("Select * from Employee");

                //Console.WriteLine(emp.Count);
                //foreach (var item in emp)
                //{
                //    //Console.WriteLine(item);
                //    Console.WriteLine(item.Name);
                //    Console.WriteLine(item.Id);
                //}
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
            //Console.WriteLine("Inserted one employee.");


            //using (var db = dbFactory.Open())
            //{


            //var emp2 = db.SingleById<Employee>(1);

            //Console.WriteLine(emp2.Age);

            //emp2.Age = 1000;

            //db.Update(emp2);

            //db.Delete<Employee>(e => e.Id == 1);

            //db.AlterTable<Employee>("drop COLUMN temp");

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
            //}
        }
    }
}