using Microsoft.Web.Http;
using System.Web.Http;

namespace JWTAuthDemo.Controllers
{
    /// <summary>
    /// API Versioning Controller
    /// </summary>
    public class APIVersionController : ApiController
    {

        #region UrlVersioning

        /// <summary>
        /// version 1.0 method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiVersion("1.0")]
        [Route("api/v{version:apiVersion}/get")]
        public IHttpActionResult Getv1()
        {
            return Ok("Hello from version 1.0");
        }

        /// <summary>
        /// version 2.0 method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiVersion("2.0")]
        [Route("api/v{version:apiVersion}/get")]
        public IHttpActionResult Getv2()
        {
            return Ok("Hello from version 2.0");
        }

        #endregion

    }
}
