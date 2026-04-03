namespace StaticVariableDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            Student.school = "ABC";
            Student s1 = new Student();
            s1.stdName = "std1";
            s1.stdID = 1;

            Console.WriteLine(Student.school);

            Student s2 = new Student();
            s2.stdID = 2;
            s2.stdName = "std2";

            //change school name
            Student.school = "XYZ";

            Console.WriteLine(Student.school);
        }
    }
}