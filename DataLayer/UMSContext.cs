using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_System.Models;
using DataLayer.Models;

namespace University_Management_System
{
    internal class UMSContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}