using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class ViewIdOnly
    {
        public List<StudentViewModel> Students { get; set; }
        public List<FacultyViewModel> Faculties { get; set; }
        public List<AdminViewModel> Admins { get; set; }
        public Admin Admin { get; set; }
    }

    public class StudentViewModel
    {
        public int StudentId { get; set; }
    }

    public class FacultyViewModel
    {
        public int FacultyId { get; set; }
    }

    public class AdminViewModel
    {
        public int AdminId { get; set; }
    }
}
