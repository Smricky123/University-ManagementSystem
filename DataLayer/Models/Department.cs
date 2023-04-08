using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Faculty> FacultyMembers { get; set; }
    }
}