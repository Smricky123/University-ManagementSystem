using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management_System.Models;

namespace DataLayer.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, Admin>, IAuth<Admin, int>, IAuthC<Admin, string>
    {
        public Admin Authenticate(int id, string pass)
        {
            var obj = db.Admins.FirstOrDefault(x => x.AdminId.Equals(id) && x.Pass.Equals(pass));
            return obj;
        }

        public Admin Create(Admin obj)
        {                  
            db.Admins.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var data = db.Admins.Find(id);
            db.Admins.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

           
        public Admin GetChecker(string email)
        {
            var obj = db.Admins.FirstOrDefault(x => x.AdminId.Equals(email));
            return obj;
        }

        public List<Admin> Read()
        {
            return db.Admins.ToList();
        }

        public Admin Read(int id)
        {     
            return db.Admins.Find(id);
        }

        public Admin Update(Admin obj)
        {
            var data = Read(obj.AdminId);
            db.Entry(data).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }
    }
}
