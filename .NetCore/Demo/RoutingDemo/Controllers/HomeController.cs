using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    [ApiController]
    [Route("Home")]
    public class HomeController : ControllerBase
    {
        // without constraint
        // give run time error The request matched multiple endpoints

        // with constraint
        // both working -> id:int allow only int values
        //              -> name:alpha allow only char string values 

        [HttpGet]
        [Route("Get/{id:int}")]
        public IActionResult Index(int id)
        {
            return Ok("Routing demo for int");
        }


        [HttpGet]
        [Route("Get/{name:alpha}")]
        public IActionResult Index2(string name)
        {
            return Ok("Routing demo for string");
        }
    }
}