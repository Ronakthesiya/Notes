using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Runtime.Caching;
using System.Security.AccessControl;

namespace JWTAuthDemo.Controllers
{
    //[GlobalExceptionFilter]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // Accessible by ANY authenticated user
        [JwtAuthorize]
        [HttpGet]
        [Route("user")]
        public IHttpActionResult UserData()
        {
            
            //throw new Exception("Hello Error");
            return Ok("Hello User or Admin");
        }

        // Accessible ONLY by Admin
        [JwtAuthorize(Roles = "Admin")]
        [HttpGet]
        [Route("admin")]
        public IHttpActionResult AdminData()
        {
            return Ok("Hello Admin only");
        }



        [HttpGet]
        public HttpResponseMessage Get()
        {
            // Changes every 60 seconds
            string currentETag = "\"" + (DateTime.UtcNow.Ticks/TimeSpan.TicksPerMinute) + "\"";

            var requestETag = Request.Headers.IfNoneMatch.FirstOrDefault();
            if (requestETag != null && requestETag.Tag == currentETag)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            var data = new
            {
                Message = "Hello API",
                Time = DateTime.Now.ToString("HH:mm:ss")
            };
            var response = Request.CreateResponse(HttpStatusCode.OK, data);

            response.Headers.ETag = new EntityTagHeaderValue(currentETag);
            response.Headers.CacheControl = new CacheControlHeaderValue
            {
                Public = true,
                MaxAge = TimeSpan.FromSeconds(60)
            };
            return response;
        }


        private static readonly ObjectCache _cache = MemoryCache.Default;

        [HttpGet]
        [Route("get/{id:int}")]
        public HttpResponseMessage GetKey(int id)
        {
            if (_cache.Get(id + "") != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { val = _cache.Get(id + "") });
            }

            _cache.Set(
                id+"",
                DateTime.Now,
                DateTimeOffset.UtcNow.AddMinutes(1)
            );

            return Request.CreateResponse(HttpStatusCode.OK,new { val = _cache.Get(id + "") });

        }

    }

}
