using DataLayer.Repos;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using UMS.DTOS;

namespace UMS.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("st/list")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data =StService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

    }
}
