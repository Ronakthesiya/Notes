using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMDemo4
{
    public class Student
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [AllowNull]
        public string Description { get; set; }

        [Required]
        public int Age { get; set; }

        [ForeignKey(typeof(Course))]
        public int CourseId { get; set; }

        [Reference]
        public Course Course { get; set; }

    }
}
