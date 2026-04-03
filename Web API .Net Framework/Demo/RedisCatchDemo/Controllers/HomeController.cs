using RedisCatchDemo.Models;
using ServiceStack;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedisCatchDemo.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetStudentById(int id)
        {
            // start redise server :  redis-server.exe
            var redisdb = RedisCacheHelper.GetDatabase();

            string cacheKey = $"student:{id}";

            //redisdb.KeyDelete(cacheKey);

            //return Ok();

            var cachedStudent = redisdb.StringGet(cacheKey);
            if (!cachedStudent.IsNullOrEmpty)
            {
                return Ok(new { message = $"From Cache",data = JSON.parse(cachedStudent) });
            }


            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(
                    connectionString: "Server=127.0.0.1;Port=3306;Database=OrmLiteDemoDB2;User Id=Admin;Password=gs@123;",
                    dialectProvider: MySqlDialect.Provider
                );

            Student std = null; 

            using (IDbConnection db = dbFactory.Open())
            {
                std = db.Select<Student>(student => student.Id == id)[0];

            }
            redisdb.StringSet(cacheKey, JSON.stringify(std), TimeSpan.FromMinutes(3));


            return Ok(new { message = $"From Database", data = std });
        }
    }
}
