namespace FinalProject.Models
{
    public class RoomFacilities
    {
        public string Id { get; set; }
        public string Closet { get; set; }
        public string BathRoom { get; set; }
        public string AirConditioner { get; set; }
        public string Wifi { get; set; }
        public string SpecialFeatures { get; set; }
        public string RoomId { get; set; }
        public Rooms Rooms { get; set; }
    }
}
