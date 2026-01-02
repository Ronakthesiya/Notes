using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// this class specifice the demo of DataTable
    /// All the Constraint and some method and propertices are cover in this
    /// </summary>
    internal class DatatableDemo
    {
        public void demo()
        {

            DataTable Student = new DataTable("Student");

            Student.Columns.Add("Id", typeof(int));
            Student.PrimaryKey = new DataColumn[] { Student.Columns["Id"] };

            DataColumn name = new DataColumn();
            name.ColumnName = "Name";
            name.DataType = typeof(string);
            name.AllowDBNull = false;

            Student.Columns.Add(name);

            Student.Columns.Add("CourseId", typeof(int));

            //Console.WriteLine(Student.Columns.Count);

            Student.Rows.Add(1, "abc", 1);
            Student.Rows.Add(2, "def", 2);
            Student.Rows.Add(3, "xyz", 3);


            //Student.Rows[1].Delete();

            foreach (DataRow row in Student.Rows)
            {
                Console.Write(row["Id"] + " ");
                Console.WriteLine(row["Name"]);
            }



            DataTable Course = new DataTable("Course");

            Course.Columns.Add("CourseId", typeof(int));
            Course.Columns.Add("CourseName", typeof(string));

            Course.Rows.Add(1, "IT");
            Course.Rows.Add(2, "CS");
            Course.Rows.Add(3, "CSE");


            //DataSet school = new DataSet();

            //school.Tables.Add(Student);
            //school.Tables.Add(Course);


            //DataRelation rel = new DataRelation
            //(
            //    "stdcourse",
            //    Student.Columns["CourseId"],
            //    Course.Columns["CourseId"]
            //);

            //school.Relations.Add(rel);

        }
    }
}
