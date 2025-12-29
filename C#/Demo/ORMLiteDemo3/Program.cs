using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json.Linq;
using ORMLiteDemo3;
using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using System.Data;

class Program
{
    static void Main()
    {
        var dbFactory = new OrmLiteConnectionFactory(
                    "Server=127.0.0.1;Port=3306;Database=OrmLiteDemoDB2;User Id=Admin;Password=gs@123;",
                    MySqlDialect.Provider
                );

        Student s = new Student(); 

       

        using (var db = dbFactory.Open())
        {

            var q = db.From<Course>().Where(c => c.Name == "Course1").Select(c => new { c.Id, c.Description });

            List<Course> list = db.Select(q);

            var q1 = db.From<Student>()
                                        .Join<Course>((s, c) => s.CourseId == c.Id)
                                        .Select<Student, Course>((s, c) => new { name = s.Name, temp = c.Id });

            var list2 = db.Select<object>(q1);



            foreach (object val in list2)
            {
                Console.WriteLine(JObject.Parse(val.ToJson())["name"]);
                Console.WriteLine(JObject.Parse(val.ToJson())["temp"]);
            }


            foreach (object val in list2)
            {
                var dict = (IDictionary<string, object>)val;
                Console.WriteLine(dict["name"]);
                Console.WriteLine(dict["temp"]);
            }

            //db.CreateTableIfNotExists<Course>();
            //db.CreateTableIfNotExists<Student>();

            //while (true)
            //{
            //    Console.Clear();
            //    Console.WriteLine("1. Student Operations");
            //    Console.WriteLine("2. Course Operations");
            //    Console.Write("Select option: ");
            //    var mainChoice = Console.ReadLine();

            //    if (mainChoice == "1")
            //        StudentMenu(db);
            //    else if (mainChoice == "2")
            //        CourseMenu(db);
            //}


            //Student st = new Student() { 
            //    CourseId = 1,
            //    Name = "UpdatedUpdated",
            //    Description = "Updated"
            //};

            //var list = db.Select<Student>();
            //list.ForEach(PrintStudent);


            //db.UpdateOnlyFields<Student>(st , s => new { s.Description , s.Name} , s => s.Id == 10);

            //Console.WriteLine();
            //list = db.Select<Student>();

            //var list = db.Column<string>(db.From<Student>().Select(x => x.Name));
            //Console.WriteLine(list);
            //list.ForEach(Console.WriteLine); 
            //PrintStudent(list);
            //list.ForEach(PrintStudent);



            //var q = db.From<Student>().Where(e => e.Id>2).Select(e => e.Name);

            //var list = db.Select<Student>(q);

            //Console.WriteLine(q.ToMergedParamsSelectStatement());
            //Console.WriteLine(q.ToSelectStatement());
            //Console.WriteLine(q.Params[0]);

            //Console.WriteLine(db.GetLastSql());
            //Console.WriteLine(db.GetMergedParamsLastSql());
            //db.SetLastCommandText("Select * from students");
            ////Console.WriteLine();

            //Console.WriteLine(db.GetLastSql());



        }
    }

    static void StudentMenu(IDbConnection db)
    {
        //Console.Clear();
        //Console.WriteLine("1. Insert");
        //Console.WriteLine("2. Update");
        //Console.WriteLine("3. Delete");
        //Console.WriteLine("4. Select");
        //Console.Write("Choose: ");
        //var choice = Console.ReadLine();

        


        //switch (choice)
        //{
        //    case "1": InsertStudent(db); break;
        //    case "2": UpdateStudent(db); break;
        //    case "3": DeleteStudent(db); break;
        //    case "4": SelectStudent(db); break;
        //}

        //Console.WriteLine("\nPress any key to continue...");
        //Console.ReadKey();
    }

    static void InsertStudent(IDbConnection db)
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();
        Console.Write("Description: ");
        var desc = Console.ReadLine();
        Console.Write("Age: ");
        var age = int.Parse(Console.ReadLine());
        Console.Write("CourseId: ");
        var courseId = int.Parse(Console.ReadLine());

        db.Insert(new Student
        {
            Name = name,
            Description = desc,
            Age = age,
            CourseId = courseId
        });

        Console.WriteLine("Student inserted");
    }

    static void UpdateStudent(IDbConnection db)
    {
        Console.Write("Enter Student Id: ");
        int id = int.Parse(Console.ReadLine());

        var student = db.SingleById<Student>(id);
        if (student == null)
        {
            Console.WriteLine("Not found.");
            return;
        }

        Console.Write("New Name: ");
        student.Name = Console.ReadLine();

        Console.Write("New Age: ");
        student.Age = int.Parse(Console.ReadLine());

        Console.Write("New Description: ");
        student.Description = Console.ReadLine();

        Console.Write("New CourseId: ");
        student.CourseId = int.Parse(Console.ReadLine());

        db.Update(student);
        Console.WriteLine("Student updated.");
    }

    static void DeleteStudent(IDbConnection db)
    {
        Console.Write("Enter Student Id: ");
        int id = int.Parse(Console.ReadLine());
        db.DeleteById<Student>(id);
        Console.WriteLine("Student deleted.");
    }

    static void SelectStudent(IDbConnection db)
    {
        Console.WriteLine("Select by:");
        Console.WriteLine("0. All");
        Console.WriteLine("1. Id");
        Console.WriteLine("2. Name");
        Console.WriteLine("3. Age");
        var opt = Console.ReadLine();

        if (opt == "0")
        {
            var c = db.LoadSelect<Student>();

            c.ForEach(PrintStudent);
        }
        else if (opt == "1")
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            var s = db.SingleById<Student>(id);
            PrintStudent(s);
        }
        else if (opt == "2")
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            var list = db.Select<Student>(x => x.Name==name);
            list.ForEach(PrintStudent);
        }
        else if (opt == "3")
        {
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            var list = db.Select<Student>(x => x.Age == age);
            list.ForEach(PrintStudent);
        }
    }

    static void CourseMenu(IDbConnection db)
    {
        Console.Clear();
        Console.WriteLine("1. Insert");
        Console.WriteLine("2. Update");
        Console.WriteLine("3. Delete");
        Console.WriteLine("4. Select");
        Console.Write("Choose: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1": InsertCourse(db); break;
            case "2": UpdateCourse(db); break;
            case "3": DeleteCourse(db); break;
            case "4": SelectCourse(db); break;
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void InsertCourse(IDbConnection db)
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();
        Console.Write("Description: ");
        var desc = Console.ReadLine();

        db.Insert(new Course { Name = name, Description = desc });
        Console.WriteLine("Course inserted.");
    }

    static void UpdateCourse(IDbConnection db)
    {
        Console.Write("Enter Course Id: ");
        int id = int.Parse(Console.ReadLine());

        var course = db.SingleById<Course>(id);
        if (course == null)
        {
            Console.WriteLine("Not found.");
            return;
        }

        Console.Write("New Name: ");
        course.Name = Console.ReadLine();

        Console.Write("New Description: ");
        course.Description = Console.ReadLine();

        db.UpdateOnly<Course>(() => new Course(){ Name = course.Name , Description = course.Description }, c => c.Id == id);
        Console.WriteLine("Course updated.");
    }

    static void DeleteCourse(IDbConnection db)
    {
        Console.Write("Enter Course Id: ");
        int id = int.Parse(Console.ReadLine());
        db.DeleteById<Course>(id);
        Console.WriteLine("Course deleted.");
    }

    static void SelectCourse(IDbConnection db)
    {
        Console.WriteLine("Select by:");
        Console.WriteLine("0. All");
        Console.WriteLine("1. Id");
        Console.WriteLine("2. Name");
        var opt = Console.ReadLine();

        if(opt == "0") {
            var c = db.LoadSelect<Course>();

            c.ForEach(PrintCourse);
        }
        else if (opt == "1")
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            var c = db.SingleById<Course>(id);
            PrintCourse(c);
        }
        else if (opt == "2")
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            var list = db.Select<Course>(x => x.Name==name);
            list.ForEach(PrintCourse);
        }
    }

    static void PrintStudent(Student s)
    {
        if (s == null) return;
        Console.WriteLine($"Id:{s.Id}, Name:{s.Name}, Age:{s.Age}, CourseId:{s.CourseId}, Desc:{s.Description}");
    }

    static void PrintCourse(Course c)
    {
        if (c == null) return;
        Console.WriteLine($"Id:{c.Id}, Name:{c.Name}, Desc:{c.Description}");
    }

   
}
