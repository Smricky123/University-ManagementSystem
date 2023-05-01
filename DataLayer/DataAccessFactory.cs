using DataLayer.Interface;
using DataLayer.Models;
using DataLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management_System.Models;

namespace DataLayer
{
    public class DataAccessFactory
    {
        public static IRepo<Admin, int, Admin> AdminDataAccess()
        {
            return new AdminRepo();
        }

        public static IAuth<Admin,int> AdminAuthDataAccess()
        {
            return new AdminRepo();
        }
      
        public static IRepo<Student, int, Student> StudentDataAccess()
        {
            return new StudentRepo();
        }

        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }

        public static IRole<Role, int, Role> RoleDataAccess()
        {
            return new RoleRepo();
        }
    }
}
