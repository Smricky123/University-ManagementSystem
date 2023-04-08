using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public virtual Faculty FacultyMember { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}