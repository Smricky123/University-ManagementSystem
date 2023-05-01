using AutoMapper;
using DataLayer;
using DataLayer.Interface;
using DataLayer.Models;
using LogicLayer.DTOS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.SessionState;
using UMS.DTOS;
using University_Management_System.Models;


namespace LogicLayer.Services
{
    public class AdminService
    {
        private static bool CheckRole(AdminDto admin, Func<RoleAssignDto, bool> roleCheckFunc)
        {
            var roleData = DataAccessFactory.RoleDataAccess().Read();
            var config = new MapperConfiguration(c => { c.CreateMap<Role, RoleAssignDto>(); });
            var mapper = new Mapper(config);
            var mappedRoleData = mapper.Map<List<RoleAssignDto>>(roleData);

            var isAdminInRole = mappedRoleData.Any(r => r.Id == admin.AdminId && roleCheckFunc(r));

            return isAdminInRole;
        }     


        public static AdminDto Add(AdminDto adminDTO)
        {
            var config = new MapperConfiguration(c => { c.CreateMap<Admin, AdminDto>(); 
                c.CreateMap<AdminDto,Admin>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<Admin>(adminDTO);
            var data = DataAccessFactory.AdminDataAccess().Create(mapped);
            if (data != null)
            {
                return mapper.Map<AdminDto>(data);
            }
            return null;
        }


        public static List<AdminDto> Get(int loggedInAdminId)
        {
            var data = DataAccessFactory.AdminDataAccess().Read();
            var config = new MapperConfiguration(c => { c.CreateMap<Admin, AdminDto>(); });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<AdminDto>>(data);
            var loggedInAdmin = mapped.FirstOrDefault(a => a.AdminId == loggedInAdminId);

            if (loggedInAdmin == null)
            {
                throw new Exception("No admin is currently logged in.");
            }

            if (CheckRole(loggedInAdmin, r => r.viewRole))
            {
                return mapped;
            }
            else
            {
                throw new Exception("Admin does not have the required role to perform this action.");
            }
        }


        public static AdminDto Get(int id, int loggedInAdminId, RoleAssignDto role)
        {
            var data = DataAccessFactory.AdminDataAccess().Read(id);
            var config = new MapperConfiguration(c => { c.CreateMap<Admin, AdminDto>(); });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<AdminDto>>(data);
            var loggedInAdmin = mapped.FirstOrDefault(a => a.AdminId == loggedInAdminId);

            if (loggedInAdmin == null)
            {
                throw new Exception("No admin is currently logged in.");
            }

            if (CheckRole(loggedInAdmin, r => r.viewRole))
            {
                var config2 = new MapperConfiguration(c => { c.CreateMap<Role, RoleAssignDto>();
                   
                });
                var mapper2 = new Mapper(config);
                var mapped2 = mapper.Map<Role>(role);

                var data2 = DataAccessFactory.RoleDataAccess().Update(mapped2);
                if (data != null)
                {
                    //return mapper.Map<RoleAssignDto>(data);
                }
                return null;
            }
            else
            {
                throw new Exception("Admin does not have the required role to perform this action.");
            }
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Delete(id);
            return data;
        }

        public static AdminDto Update(AdminDto adminDTO)
        {
            var config = new MapperConfiguration(c => { c.CreateMap<Admin, AdminDto>(); });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<Admin>(adminDTO);
            var data = DataAccessFactory.AdminDataAccess().Update(mapped);
            if (data != null)
            {
                return mapper.Map<AdminDto>(data);
            }
            return null;
        }

        public static RoleAssignDto RoleAssign(RoleAssignDto role,int id, int loggedInAdminId)
        {        
            var config = new MapperConfiguration(c => { c.CreateMap<Role, RoleAssignDto>();
                c.CreateMap<RoleAssignDto, Role>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<Role>(role);
            var data = DataAccessFactory.RoleDataAccess().Create(id, mapped);
            var loggedInAdmin = DataAccessFactory.RoleDataAccess().GetChecker(id);

            if (loggedInAdmin != null && loggedInAdmin.masterRole)
            {                      
                    if (data != null)
                    {
                        return mapper.Map<RoleAssignDto>(data);
                    }
                    return null;          
            }
            throw new Exception("Only master admin can assign roles.");
        }





    }
}

