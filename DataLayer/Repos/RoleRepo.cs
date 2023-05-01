using DataLayer.Interface;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management_System.Models;

namespace DataLayer.Repos
{
    internal class RoleRepo : Repo, IRole<Role, int, Role>
    {
        public Role Create(int id,Role obj)
        {          
            db.Roles.Add(obj);
            obj.Id = id;
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }
      

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> Read()
        {
            return db.Roles.ToList();
        }

        public Role Read(int id)
        {
            return db.Roles.Find(id);
        }

        public Role Update(Role obj)
        {
            var data = Read(obj.RoleId);
            db.Entry(data).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public Role GetChecker(int id)
        {
            var obj = db.Roles.FirstOrDefault(x => x.Id.Equals(id));
            return obj;
        }
    }
}
