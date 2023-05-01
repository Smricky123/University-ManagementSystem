using LogicLayer.DTOS;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using UMS.DTOS;

namespace UMS.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        [Route("student/add")]
        public HttpResponseMessage CreateSt(StudentDto student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = StService.Create(student);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("admin/add")]
        public HttpResponseMessage Create(AdminDto admin)
        {      
                try
                {
                    if (ModelState.IsValid)
                    {
                        var data = AdminService.Add(admin);
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
                }
            }

       
        [HttpGet]     
        [Route("admin/list")]
        public HttpResponseMessage GetAllAdmins()
        {  
            try
            {
                var cookie = HttpContext.Current.Request.Cookies["AdminId"];
                var loggedinAdminId =int.Parse(cookie.Value) ;
                var data = AdminService.Get(loggedinAdminId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("admin/{id}")]
        public HttpResponseMessage GetSingleAdmin(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/admin/delete/{id}")]
        public HttpResponseMessage DeleteAdmin(int id)
        {
            try
            {
                var data = AdminService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("admin/role/{id}")]
        public HttpResponseMessage UpdateRole(RoleAssignDto role, int id)
        {
            try
            {
                var cookie = HttpContext.Current.Request.Cookies["AdminId"];
                var loggedinAdminId = int.Parse(cookie.Value);
                var data = AdminService.RoleAssign(role,id, loggedinAdminId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }     

    }
}
