using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DemoConsol
{
    internal class DataViewdemo
    {
        public void demo() {

            DataTable students = new DataTable();

            students.Columns.Add("StudentID", typeof(int));
            students.Columns.Add("Name", typeof(string));
            students.Columns.Add("Class", typeof(string));
            students.Columns.Add("Marks", typeof(int));
            students.Columns.Add("Status", typeof(string));

            students.Rows.Add(1, "Alice", "10A", 85, "Pass");
            students.Rows.Add(2, "Bob", "10A", 35, "Fail");
            students.Rows.Add(3, "Charlie", "10B", 72, "Pass");
            students.Rows.Add(4, "David", "10B", 40, "Fail");

            //DataView dv = new DataView(students);

            //dv.Sort = "Class desc, Marks desc";

            //foreach (DataRowView row in dv)
            //{
            //    Console.WriteLine(row["Class"] + " " + row["Marks"]);
            //}

            //Admin View
            //      See all students
            //      Sort by Marks(Descending)

            DataView adminView = students.DefaultView;
            adminView.Sort = "Marks Desc";

            Console.WriteLine("Admin View");
            foreach (DataRowView row in adminView)
            {
                Console.WriteLine(row["StudentID"] + " " + row["Name"] + " " + row["Marks"] + " " + row["Status"]);
            }
            Console.WriteLine();

            //Teacher View
            //        See only students who passed
            //        Sort by Name
            DataView teacherView = students.DefaultView;
            //DataView teacherView = new DataView(students);
            teacherView.RowFilter = "Status = 'Pass'";
            teacherView.Sort = "Name";

            Console.WriteLine("Teacher View");
            foreach (DataRowView row in teacherView)
            {
                Console.WriteLine(row["StudentID"] + " " + row["Name"] + " " + row["Marks"] + " " + row["Status"]);
            }
            Console.WriteLine();


            //Search Student by ID
            teacherView.Sort = "StudentID";
            int index = teacherView.Find(3);
            if (index != -1)
            {
                Console.WriteLine("Found: " + teacherView[index]["Name"]);
            }
            Console.WriteLine();

            //Update Marks
            //        Changes reflect automatically in both views

            students.Rows[1]["Marks"] = 60;
            students.Rows[1]["Status"] = "Pass";

            Console.WriteLine("Teacher View");
            foreach (DataRowView row in teacherView)
            {
                Console.WriteLine(row["StudentID"] + " " + row["Name"] + " " + row["Marks"] + " " + row["Status"]);
            }
            Console.WriteLine();


            // change by dataview reflect in datatable

            teacherView[1]["Name"] = "Ronak";

            foreach (DataRow row in students.Rows)
            {
                Console.WriteLine(row["StudentID"] + " " + row["Name"] + " " + row["Marks"] + " " + row["Status"]);
            }

        }
    }
}
