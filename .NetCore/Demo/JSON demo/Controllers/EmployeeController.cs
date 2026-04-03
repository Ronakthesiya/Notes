using JSON_demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JSON_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public readonly EmployeeRepository _repository;

        public EmployeeController()
        {
            _repository = new EmployeeRepository();
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _repository.Get();
        }


        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            _repository.Add(employee);

            return Ok();
        }
    }
}