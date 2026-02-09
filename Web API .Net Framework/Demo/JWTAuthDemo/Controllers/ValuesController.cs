using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Runtime.Caching;
using System.Security.AccessControl;
using System.Runtime.Remoting.Contexts;

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


        // http catch only work with client
        [HttpGet]
        public HttpResponseMessage Get()
        {
            // Changes every 60 seconds
            string currentETag = "\"" + (DateTime.UtcNow.Ticks/TimeSpan.TicksPerMinute) + "\"";

            // check if data is in catch
            var requestETag = Request.Headers.IfNoneMatch.FirstOrDefault();
            if (requestETag != null && requestETag.Tag == currentETag)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }

            // if not in catch than create new data and return
            var data = new
            {
                Message = "Hello API",
                Time = DateTime.Now.ToString("HH:mm:ss")
            };
            var response = Request.CreateResponse(HttpStatusCode.OK, data);

            // catch store only for 60 secound
            response.Headers.ETag = new EntityTagHeaderValue(currentETag);
            response.Headers.CacheControl = new CacheControlHeaderValue
            {
                Public = true,
                MaxAge = TimeSpan.FromSeconds(60)
            };
            return response;
        }



        // Memory Cache
        private readonly ObjectCache _cache = MemoryCache.Default;

        [HttpGet]
        [Route("get/{id:int}")]
        public HttpResponseMessage GetKey(int id)
        {
            if (_cache.Get(id + "") != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { valFromCatch = _cache.Get(id + "") });
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
