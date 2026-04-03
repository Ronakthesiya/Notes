using DIDemo.Repository;
using DIDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private Transiant transiant;
        private Scoped scoped;
        private Singleton singleton;
        private PrintRepository PrintRepository;

        public HomeController(Transiant t, Scoped s, Singleton S, PrintRepository printRepository)
        {
            transiant = t;
            scoped = s;
            singleton = S;
            PrintRepository = printRepository;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                p = PrintRepository.print(),
                transiant = transiant.guid,
                scoped = scoped.guid,
                singleton = singleton.guid,
            });
        }
    }
}