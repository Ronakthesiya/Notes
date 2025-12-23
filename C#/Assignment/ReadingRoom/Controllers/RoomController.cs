using Microsoft.AspNetCore.Mvc;
using ReadingRoom.Models;
using ReadingRoom.Models.NewFolder;

namespace ReadingRoom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : Controller
    {

        private readonly ApplicationDBContext _dbContext;
        public RoomController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rooms = _dbContext.Rooms.ToList();

            //IQueryable queryable = _dbContext.Rooms.Where(a => a.Id > 2);

            //Console.WriteLine(queryable.Expression);

            return Ok(rooms);
        }

        [HttpPost]
        public IActionResult Post(DTORoom room)
        {
            Room room1 = new Room()
            {
                Name = room.Name,
                Capacity = room.Capacity,
            };


            _dbContext.Rooms.Add(room1);

            _dbContext.SaveChanges();

            return Ok(room1);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            Room room = _dbContext.Rooms.Find(id);

            return Ok(room);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult Put(int id,DTORoom room) { 

            Room room1 = new Room()
            {
                Id = id,
                Name = room.Name,
                Capacity=room.Capacity
            };

            _dbContext.Update(room1);

            _dbContext.SaveChanges();

            return Ok(room1);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            Room room = _dbContext.Rooms.Find(id);
            _dbContext.Rooms.Remove(room);

            _dbContext.SaveChanges();

            return Ok();
        }

    }
}
