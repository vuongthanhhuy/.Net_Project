namespace FinalProject.Models
{
    public class Accounts
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public ICollection<RoomReviews> RoomReviews { get; set; }
        public ICollection<History> Histories { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
        public ICollection<RestaurantMenus> RestaurantMenus { get; set; }
        public ICollection<Orderings> Orderings { get; set; }
    }
}
