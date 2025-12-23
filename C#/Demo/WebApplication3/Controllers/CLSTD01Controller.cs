using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using APICRUDDemo.BAL;
using APICRUDDemo.MAL.POCO;

namespace APICRUDDemo.Controller
{
    public class CLSTD01Controller : ApiController
    {
        private readonly BLSTD01 _BLSTD01;

        public CLSTD01Controller()
        {
            _BLSTD01 = new BLSTD01();
        }

        [HttpGet]

        public IHttpActionResult Get()
        {
            List<STD01> list = _BLSTD01.getAllStudents();

            if(list.Count>0) return Ok(list);

            return Content(HttpStatusCode.NotFound, "No student found!!");
        }

        [HttpGet]

        public IHttpActionResult GetById(int id)
        {
            return Ok(_BLSTD01.getStudentById(id));
        }

        [HttpPost]
        public IHttpActionResult Post(STD01 std)
        {
            return Ok(_BLSTD01.AddStudent(std));
        }

        //public IHttpActionResult std(STD01 std)
        //{
        //    return Ok(_BLSTD01.AddStudent(std));
        //}

        [HttpPut]

        public IHttpActionResult Put(STD01 std)
        {
            return Ok(_BLSTD01.UpdateStudent(std));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_BLSTD01.DeleteStudent(id));
        }
    }
}