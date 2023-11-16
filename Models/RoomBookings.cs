namespace FinalProject.Models
{
    public class RoomBookings
    {
        public string Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string RoomId { get; set; }
        public Rooms Room { get; set; }
    }
}
