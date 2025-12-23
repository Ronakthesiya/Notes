using Microsoft.AspNetCore.Mvc;
using ReadingRoom.Models.NewFolder;
using ReadingRoom.Models;


namespace ReadingRoom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : Controller
    {

        private readonly ApplicationDBContext _dbContext;
        public ReservationController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var reservations = _dbContext.Reservations.ToList();

            return Ok(reservations);
        }

        [HttpGet("byroomfromto")]
        public IActionResult Get(int? roomid,DateTime? from,DateTime? to)
        {
            var query = _dbContext.Reservations.AsQueryable();

            if (roomid.HasValue)
                query = query.Where(r => r.RoomId == roomid);

            if (from.HasValue)
                query = query.Where(r => r.Start >= from);

            if (to.HasValue)
                query = query.Where(r => r.End <= to);

            return Ok(query.ToList());
        }


        [HttpPost]
        public IActionResult Post(DTOReservation reservation)
        {
             Reservation reservation1 = new  Reservation()
            {
                PatronName = reservation.PatronName,
                Start = reservation.Start,
                End = reservation.End,
                RoomId = reservation.RoomId,
                Status = (int)reservation?.Status
            };


            _dbContext.Reservations.Add(reservation1);

            _dbContext.SaveChanges();

            return Ok(reservation1);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
             Reservation reservation = _dbContext.Reservations.Find(id);

            return Ok(reservation);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult Put(int id,  DTOReservation reservation)
        {

             Reservation reservation1 = new  Reservation()
            {
                Id = id,
                 PatronName = reservation.PatronName,
                 Start = reservation.Start,
                 End = reservation.End,
                 RoomId = reservation.RoomId,
                 Status = (int)reservation?.Status
             };

            _dbContext.Update(reservation1);

            _dbContext.SaveChanges();

            return Ok(reservation1);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
             Reservation reservation = _dbContext.Reservations.Find(id);
            _dbContext.Reservations.Remove(reservation);

            _dbContext.SaveChanges();

            return Ok();
        }

    }
}

