using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Newtonsoft.Json; // Required for JsonConvert
using System.Data;

namespace DataGridAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IDbConnectionFactory _dbFactory;

        public UserController(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        [HttpGet]
        public object Get([ModelBinder(BinderType = typeof(DataSourceLoadOptionsBinder))] DataSourceLoadOptions loadOptions)
        {
            using var db = _dbFactory.OpenDbConnection();
            var users = db.Select<User>();
            return DataSourceLoader.Load(users, loadOptions);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User newUser)
        {
            using var db = _dbFactory.OpenDbConnection();
            // Newtonsoft.Json: Populate the object with the incoming form data

            db.Insert(newUser);
            return Ok(newUser);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] UserPatchDTO updatedUser)
        {
            try
            {
                using var db = _dbFactory.OpenDbConnection();

                var user = db.SingleById<User>(id);
                if (user == null) return NotFound("User not found");

                if (updatedUser.name != null)
                    user.name = updatedUser.name;

                if (updatedUser.email != null)
                    user.email = updatedUser.email;

                user.bod = updatedUser.bod ?? user.bod;
                
                user.salary = updatedUser.salary ?? user.salary;

                user.isActive = updatedUser.isActive ?? user.isActive;

                db.Update(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var db = _dbFactory.OpenDbConnection();

            var user = db.SingleById<User>(id);
            if (user == null) return NotFound("User not found");

            db.DeleteById<User>(id);
            return Ok();
        }
    }
}