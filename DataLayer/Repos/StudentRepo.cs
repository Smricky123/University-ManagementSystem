using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management_System;
using University_Management_System.Models;

namespace DataLayer.Repos
{
    public class StudentRepo
    {
        static UMSContext db;

        static StudentRepo()
        {
            db = new UMSContext();
        }

        public static List<Student> Get()
        {
            return db.Students.ToList();
        }

        public static Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public static bool Create(Student student)
        {
            db.Students.Add(student);
            return db.SaveChanges() > 0;        
        }

        public static bool Update(Student student)
        {
            var st = Get(student.StudentId);
            db.Entry(st).CurrentValues.SetValues(student);
            return db.SaveChanges() > 0;
        }

        public static bool Delete(int id)
        {
            var st = Get(id);
            db.Students.Remove(st);
            return db.SaveChanges() > 0;
        }
    }
}
