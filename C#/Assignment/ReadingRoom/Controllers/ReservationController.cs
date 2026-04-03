using Microsoft.AspNetCore.Mvc;
using ReadingRoom.Models.NewFolder;
using ReadingRoom.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Cryptography.Xml;

namespace ReadingRoom.Controllers
{
    /// <summary>
    /// Reservation controller handle all the bookings and reservation of rooms
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : Controller
    {

        private readonly ApplicationDBContext _dbContext;
        public ReservationController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        /// <summary>
        /// return list of all reservations
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {
            var reservations = _dbContext.Reservations.ToList();

            return Ok(reservations);
        }

        /// <summary>
        /// return reservations based on some conditions
        /// </summary>
        /// <param name="roomid">id of room to get reservation of that room</param>
        /// <param name="from">start time</param>
        /// <param name="to">end time</param>
        /// <returns></returns>

        [HttpGet("byroomfromto")]
        public IActionResult Get(int? roomid,DateTime? from,DateTime? to)
        {
            IQueryable<Reservation> query = _dbContext.Reservations.AsQueryable();

            if (roomid.HasValue)
                query = query.Where(r => r.RoomId == roomid);

            if (from.HasValue && to.HasValue)
                query = query.Where(r => (from <= r.Start && r.Start < to) || (from < r.End && r.End <= to) || (r.Start <= from && to <= r.End));
            else if (to.HasValue)
                query = query.Where(r => r.End <= to || r.Start < to);
            else if (from.HasValue)
                query = query.Where(r => r.End >= from || r.Start >= from);

            return Ok(query.ToList());
        }


        /// <summary>
        /// create a new rservation of room
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(DTOReservation reservation)
        {
            List<Reservation> list = _dbContext.Reservations
                                            .Where(r => r.RoomId == reservation.RoomId)
                                            .Where(r => (reservation.Start <= r.Start && r.Start < reservation.End) || (reservation.Start < r.End && r.End <= reservation.End) || (r.Start <= reservation.Start && reservation.End <= r.End))
                                            .ToList();

            if(list.Count > 0)
            {
                return Ok("In this time sloat room is alredy booked");
            }

            Reservation reservation1 = new  Reservation()
            {
                PatronName = reservation.PatronName,
                Start = reservation.Start,
                End = reservation.End,
                RoomId = reservation.RoomId,
                Status = (int)reservation?.Status
             };

            _dbContext.Add(reservation1);
            _dbContext.SaveChanges();

            return Ok(reservation1);
        }


        /// <summary>
        /// get reservation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
             Reservation reservation = _dbContext.Reservations.Find(id);

            return Ok(reservation);
        }


        /// <summary>
        /// used to update the reservasion 
        /// </summary>
        /// <param name="id">id for update</param>
        /// <param name="reservation">new values</param>
        /// <returns></returns>
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


        /// <summary>
        /// delete reservation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
             Reservation reservation = _dbContext.Reservations.Find(id);
            _dbContext.Reservations.Remove(reservation);

            _dbContext.SaveChanges();

            return Ok();
        }


        [HttpGet]
        [Route("topnroom")]
        public IActionResult Get(int n,DateTime? from, DateTime? to)
        {
            IQueryable<Reservation> query = _dbContext.Reservations.AsQueryable();

            if (from.HasValue && to.HasValue)
                query = query.Where(r => (from <= r.Start && r.Start < to) || (from < r.End && r.End <= to) || (r.Start <= from && to <= r.End));
            else if (to.HasValue)
                query = query.Where(r => r.End <= to || r.Start < to);
            else if (from.HasValue)
                query = query.Where(r => r.End >= from || r.Start >= from);

            List<Reservation> list = query.ToList();

            List<Dictionary<string, int>> ans = list
                    .GroupBy(r => r.RoomId)
                    .Select(r => new Dictionary<string, int>
                        {
                            { "roomId", r.Key },
                            { "cnt", r.Count() }
                        })
                    .OrderByDescending(r => r["cnt"])
                    .Take(n)
                    .ToList();

            return Ok(ans);
        }

    }
}

