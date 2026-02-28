using Microsoft.AspNetCore.Mvc;

namespace FilterDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("=== Action Exicuted");
            return Ok("Action Result");
        }
    }
}