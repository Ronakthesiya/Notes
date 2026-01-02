using Microsoft.AspNetCore.Mvc;
using ReadingRoom.Models;
using ReadingRoom.Models.NewFolder;

namespace ReadingRoom.Controllers
{
    /// <summary>
    /// Room Controller used for CRUD operations of rooms
    /// Contains all room api end points
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomController : Controller
    {

        private readonly ApplicationDBContext _dbContext;
        public RoomController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        /// <summary>
        /// return the list of all rooms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<Room> rooms = _dbContext.Rooms.ToList();

            //IQueryable queryable = _dbContext.Rooms.Where(a => a.Id > 2);

            //Console.WriteLine(queryable.Expression);

            return Ok(rooms);
        }


        /// <summary>
        /// create a room 
        /// </summary>
        /// <param name="room">take from body</param>
        /// <returns></returns>
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


        /// <summary>
        /// return room by id
        /// </summary>
        /// <param name="id">take the id of room</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            Room room = _dbContext.Rooms.Find(id);

            return Ok(room);
        }

        /// <summary>
        /// Update the room
        /// </summary>
        /// <param name="id">id of room</param>
        /// <param name="room">rooms data for update</param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete the room by id
        /// </summary>
        /// <param name="id">take id of room for delete</param>
        /// <returns></returns>
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
