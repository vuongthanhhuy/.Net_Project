namespace FinalProject.Models
{
    public class HistoryStaffs
    {
        public string Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public float Revenue { get; set; }
        public string customerName { get; set; }
        public string RoomId { get; set; }
        public Rooms Rooms { get; set; }
        public string AccountId { get; set; }
        public Accounts Accounts { get; set; }
    }
}
