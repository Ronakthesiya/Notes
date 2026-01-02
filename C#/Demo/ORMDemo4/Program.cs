using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStack.Script;
using System.Data;

namespace ORMDemo4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(
                    "Server=127.0.0.1;Port=3306;Database=OrmLiteDemoDB2;User Id=Admin;Password=gs@123;",
                    MySqlDialect.Provider
                );


            using (IDbConnection db = dbFactory.Open())
            {

                #region Select
                /*
                // Select

                // Select All
                List<Student> students = db.Select<Student>();
                students.ForEach(DisplayStudent);

                // Select Pridicate
                students = db.Select<Student>(s => s.Age>10);
                students.ForEach(DisplayStudent);

                // Single Student
                Student student = db.Single<Student>(s => s.Name == "Ronak");
                DisplayStudent(student);

                // Single By Id
                student = db.SingleById<Student>(5);

                // select with course
                students = db.LoadSelect<Student>();
                students.ForEach(DisplayStudent);

                // Select Scaler
                int cnt = db.SqlScalar<int>("Select Count(*) from Student");
                Console.WriteLine(cnt);

                // Select List
                List<string> names = db.SqlList<string>("Select Name from Student");
                names.ForEach(Console.WriteLine);

                // Select Dictionary
                Dictionary<int, int> ages = db.Dictionary<int,int>("Select Id,Age from Student");
                foreach (var item in ages.Keys)
                {
                    Console.WriteLine(item + " : key   val : " + ages[item]);
                }

                // Select column
                List<string> names1 = db.Column<string>("select name from student");
                names1.ForEach(Console.WriteLine);
                */
                #endregion

                #region Insert
                /*
                 //object insert
                Student student1 = new Student()
                {
                    Name = "asdf",
                    Age = 10,
                    CourseId = 2,
                    Description = "asdfasdf"
                };

                int id = (int)db.Insert(student1, selectIdentity: true);
                Console.WriteLine(id);


                // Insert only
                id = (int)db.InsertOnly<Student>(() => new Student() { Name = "roank", CourseId = 1 }, true);
                Console.WriteLine(id);


                // last inserted id
                id = (int)db.LastInsertId();
                Console.WriteLine(id);


                // insert all
                List<Student> stds = new List<Student>()
                {
                    new Student(){ Name = "111", Age = 10, CourseId=1},
                    new Student(){ Name = "121", Age = 10, CourseId=2},
                };

                db.InsertAll(stds);
                */

                #endregion

                #region Update
                /*
                // Update by id

                Student std2 = new Student()
                {
                    Id = 2,
                    Name = "Updated 2",
                    Age = 10,
                    CourseId = 2,
                };
                db.Update(std2);
                Console.WriteLine(db.GetLastSql());


                // update with where
                std2.Name = "Updated 3";
                db.Update(std2,s => s.Name=="Updated 2");

                Console.WriteLine(db.GetLastSql());


                // update only
                db.UpdateOnly(()=> new Student() { Name = "Updated 3"}, s => s.Id==2);
                Console.WriteLine(db.GetLastSql());


                // Update Add
                db.UpdateAdd(()=>new Student() { Age = 2}, s=>s.Id==2);
                Console.WriteLine(db.GetLastSql());


                // Update only feild
                std2.Name = "Updated 4";
                db.UpdateOnlyFields(std2,s=> new { s.Name , s.Age},s=>s.Id==2);
                Console.WriteLine(db.GetLastSql());


                // Update Non Defaults
                std2.Name = "Updated 5";
                db.UpdateNonDefaults(std2, s => s.Id == 2);
                Console.WriteLine(db.GetLastSql());

                // Update All
                db.UpdateAll(list);
                

                */
                #endregion

                #region Delete
                /*
                // delete object
                Student std3 = db.SingleById<Student>(13);
                db.Delete(std3);
                Console.WriteLine(db.GetLastSql());


                // delete by Id
                db.DeleteById<Student>(14);
                Console.WriteLine(db.GetLastSql());


                // delete by ids
                db.DeleteByIds<Student>(new int[] {11,12});
                Console.WriteLine(db.GetLastSql());


                // delete by where
                db.Delete<Student>(s => s.Id>15);
                Console.WriteLine(db.GetLastSql());


                // delete all
                //db.DeleteAll<Student>();
                */
                #endregion

                #region Transaction

                //using (IDbTransaction tran = db.OpenTransaction())
                //{
                //    tran.Commit();

                //    tran.Rollback();

                //    SavePoint sv1 =tran.SavePoint("sv1");

                //    sv1.Rollback();

                //}
                #endregion

                #region Queries

                //var q = db.From<Student>().Where(s=>s.Name == "raonk").Select(s => s.Age);

                //var q1 = db.From<Student>().OrderBy(s => s.Name).ThenBy(s => s.Age).Limit(5,10);

                //var q2 = db.From<Student>().Join<Course>((s,o)=>s.CourseId==o.Id).Select<Student,Course>((s,c) => new { std = s.Name , course =  c.Name});

                //List<(string student, string course)> list = db.Select<(string student,string course)>(q2);
                #endregion
            }
        }
        
        public static void DisplayStudent(Student student)
        {
            Console.WriteLine(student.Id+" "+student.Name+" "+student.Age+" "+student.Description+" "+student.CourseId+" "+student.CourseId??"");
        }

    }


}