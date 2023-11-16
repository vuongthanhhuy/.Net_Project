using FinalProject.Models;

namespace FinalProject.Services
{
    public class IndexViews
    {
        public List<Rooms> AllRooms { get; set; }
        public List<Rooms> TopRooms { get; set; }
        public List<RestaurantMenus> TopRestaurantMenusBreak { get; set; }
        public List<RestaurantMenus> TopRestaurantMenusLun { get; set; }
        public List<RestaurantMenus> TopRestaurantMenusDin { get; set; }
        public List<Rooms> DemandRooms { get; set; }
    }
}
