using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Benchmark]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(50);

            var products = Enumerable.Range(1, 100)
                .Select(x => new { Id = x, Name = $"Product {x}" });

            return Ok(products);
        }
    }
}
