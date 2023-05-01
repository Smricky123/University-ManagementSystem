using LogicLayer.DTOS;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace UMS.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Login")]
        public HttpResponseMessage Authenticate(LoginDto loginDto)
        {
            try
            {
                if (loginDto == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Email & Password is not provided");
                }
                if (ModelState.IsValid)
                {
                    var data = AuthService.Authenticate(loginDto.Id, loginDto.Pass);               

                    if (data != null)
                    {                                       
                        var cookie = new HttpCookie("AdminId", loginDto.Id.ToString());
                        cookie.Expires = DateTime.Now.AddMinutes(4);
                        HttpContext.Current.Response.Cookies.Add(cookie);                   
                        return Request.CreateResponse(HttpStatusCode.Accepted, data);                     
                    }
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Email or password is invalid");
                }
                return Request.CreateResponse(HttpStatusCode.Forbidden, ModelState);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    

            [HttpGet]
        [Route("api/Logout/{token}")]
        public HttpResponseMessage Logout(string token)
        {
            if (token == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Token is not provided");
            }
            var data = AuthService.logout(token);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, data);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized, "Token is invalid");
        }
    }
}
