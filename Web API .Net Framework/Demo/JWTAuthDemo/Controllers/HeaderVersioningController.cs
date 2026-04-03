using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWTAuthDemo.Controllers
{
    /// <summary>
    /// header versioning
    /// </summary>
    public class HeaderVersioningController : ApiController
    {
        #region HeaderVersioning

        /// <summary>
        /// use the header to get required version of data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Header")]
        public IHttpActionResult Get()
        {
            string version = Request.Headers.Contains("X-API-Version")
                ? Request.Headers.GetValues("X-API-Version").First()
                : "1";

            if (version == "1")
            {
                return Ok(new { Id = 1, Name = "Laptop", Price = 1200 });
            }
            else if (version == "2")
            {
                return Ok(new
                {
                    Id = 1,
                    Name = "Laptop",
                    Pricing = new { Amount = 1200, Currency = "USD" }
                });
            }

            return BadRequest("Unsupported API version");
        }

        #endregion
    }
}
