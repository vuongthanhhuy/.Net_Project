namespace FinalProject.Models
{
    public class RoomReviews
    {
        public string Id { get; set; }
        public string Comment { get; set; }
        public int Evaluation { get; set; }
        public string RoomId { get; set; }
        public string AccountId { get; set; }
        public Rooms Rooms { get; set; }
        public Accounts Accounts { get; set; }
    }
}
