using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWTAuthDemo.Controllers
{
    public class QueryStringController : ApiController
    {
        #region QueryStringVersioning

        /// <summary>
        /// method contains all version data
        /// </summary>
        /// <param name="version">specific version data needed</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Query")]
        public IHttpActionResult Get(string version)
        {
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

            return BadRequest("Invalid API version");
        }

        #endregion
    }
}
