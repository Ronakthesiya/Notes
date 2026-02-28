using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWTAuthDemo.Controllers
{
    /// <summary>
    /// media type versioning
    /// </summary>
    public class MediaTypeController : ApiController
    {
        /// <summary>
        /// contains all version data
        /// use accept from header and return data according to that
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            string mediaType = Request.Headers.Accept.ToString();

            if (mediaType.Contains("vnd.mycompany.v2"))
            {
                return Ok(new { Id = 1, Name = "Laptop", Price = 1200, Currency = "USD" });
            }

            return Ok(new { Id = 1, Name = "Laptop", Price = 1200 });
        }
    }
}
