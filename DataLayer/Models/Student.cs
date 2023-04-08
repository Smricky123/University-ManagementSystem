using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [StringLength(8)]
        public string Pass { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Dept { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}