using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;

namespace SwaggerDoc.Controllers
{
    public class HomeController : ApiController
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        [HttpGet]
        public HttpResponseMessage get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Hello from ronak" });
        } 
    }
}
