using FilterDemo.Filter;
using Microsoft.AspNetCore.Mvc;

namespace FilterDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [TypeFilter(typeof(ActionFilter))]
        [ServiceFilter(typeof(ResultFilter))]
        public IActionResult Get()
        {
            Console.WriteLine("=== Action Method");
            return Ok("Action Result");
        }
    }
}