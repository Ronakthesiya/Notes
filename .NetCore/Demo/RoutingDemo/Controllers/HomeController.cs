using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    [ApiController]
    [Route("Home")]
    public class HomeController : ControllerBase
    {
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