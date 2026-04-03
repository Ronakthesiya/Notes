namespace ReadingRoom.Models.NewFolder
{
    public class DTOReservation
    {
        public int RoomId { get; set; }

        public string PatronName { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public ReservationStatus Status { get; set; }
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }
}
