using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWTAuthDemo.Controllers
{
    public class APIVersionController : ApiController
    {
        [HttpGet]
        [ApiVersion("1.0")]
        [Route("api/v{version:apiVersion}/get")]
        public IHttpActionResult Getv1()
        {
            return Ok("Hello from version 1.0");
        }

        [HttpGet]
        [ApiVersion("2.0")]
        [Route("api/v{version:apiVersion}/get")]
        public IHttpActionResult Getv2()
        {
            return Ok("Hello from version 2.0");
        }
    }
}
