namespace ReadingRoom.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public string PatronName { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Status { get; set; }
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }
}