using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management_System;
using University_Management_System.Models;

namespace DataLayer.Repos
{
    internal class StudentRepo : Repo, IRepo<Student, int,Student>
    { 
        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Students.Remove(ex);
            return db.SaveChanges() > 0;
        }

        Student IRepo<Student,int, Student>.Create(Student obj)
        {
            db.Students.Add(obj);
            if(db.SaveChanges()>0)
            return obj;
            return null;
        }

        public List<Student>Read()
        {
            return db.Students.ToList();
        }

        public Student Read(int id)
        {
            return db.Students.Find(id);
        }

       public Student Update(Student obj)
        {
            var ex = Read(obj.StudentId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;
                    return null;
        }

        public List<Student> Get()
        {
            throw new NotImplementedException();
        } 
        
    }
}
