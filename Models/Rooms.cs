namespace FinalProject.Models
{
    public class Rooms
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string Categories { get; set; }
        public float Size { get; set; }
        public string BedType { get; set; }
        public int Status { get; set; }
        public RoomFacilities RoomFacilities { get; set; }
        public ICollection<RoomReviews> RoomReviews { get; set; }
        public ICollection<History> Histories { get; set; }

        public ICollection<Accounts> Accounts { get; set; }
        public ICollection<RoomBookings> RoomBookings { get; set; }
        public ICollection<HistoryStaffs> HistoryStaffs { get; set; }

    }
}
