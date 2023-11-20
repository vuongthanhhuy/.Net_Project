using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SystemDBContext _context;

        public HomeController(ILogger<HomeController> logger, SystemDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var allRooms = _context.Rooms.ToList();
            var topRoooms = _context.Rooms.Take(3).ToList();
            var topRestaurantMenusBreak = _context.RestaurantMenus.Where(b => b.Meal.Contains("Breakfast")).Take(3).ToList();
            var topRestaurantMenusLun = _context.RestaurantMenus.Where(b => b.Meal.Contains("Lunch")).Take(3).ToList();
            var topRestaurantMenusDin = _context.RestaurantMenus.Where(b => b.Meal.Contains("Dinner")).Take(3).ToList();
            var room = new IndexViews
            {
                AllRooms = allRooms,
                TopRooms = topRoooms,
                TopRestaurantMenusBreak = topRestaurantMenusBreak,
                TopRestaurantMenusLun = topRestaurantMenusLun,
                TopRestaurantMenusDin = topRestaurantMenusDin,
                DemandRooms = allRooms
            };
            return View("Index", room);
        }

        public IActionResult rooms()
        {
            var allRooms = _context.Rooms.ToList();
            var topRoooms = _context.Rooms.Take(3).ToList();
            var room = new RoomsViews
            {
                AllRooms = allRooms,
                TopRooms = topRoooms
            };
            return View("rooms", room);
        }

        public IActionResult services()
        {
            return View("services");
        }
        public IActionResult about()
        {
            return View("about");
        }
        [HttpPost]
        public IActionResult CheckAvailability(string checkin_date, string checkout_date, int adults, int children)
        {
            var allRooms = _context.Rooms.ToList();
            var topRoooms = _context.Rooms.Take(3).ToList();

            DateTime resCheckInDate;
            DateTime resCheckOutDate;

            var topRestaurantMenusBreak = _context.RestaurantMenus.Where(b => b.Meal.Contains("Breakfast")).Take(3).ToList();
            var topRestaurantMenusLun = _context.RestaurantMenus.Where(b => b.Meal.Contains("Lunch")).Take(3).ToList();
            var topRestaurantMenusDin = _context.RestaurantMenus.Where(b => b.Meal.Contains("Dinner")).Take(3).ToList();

            if (DateTime.TryParseExact(checkin_date, "d MMMM, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out resCheckInDate) && DateTime.TryParse(checkout_date, out resCheckOutDate))
            {
                var demandRooms = _context.Rooms
                                      .Where(room => room.Adults >= adults && room.Children >= children)
                                      .Where(room => room.RoomBookings.All(booking =>
                                      (booking.CheckIn < resCheckInDate && booking.CheckOut < resCheckInDate) ||
                                      (booking.CheckIn > resCheckOutDate && booking.CheckOut > resCheckOutDate)))
                                      .ToList();
                var room = new IndexViews
                {
                    AllRooms = allRooms,
                    TopRooms = topRoooms,
                    TopRestaurantMenusBreak = topRestaurantMenusBreak,
                    TopRestaurantMenusLun = topRestaurantMenusLun,
                    TopRestaurantMenusDin = topRestaurantMenusDin,
                    DemandRooms = demandRooms
                };
                return View("Index", room);
            }
            else
            {
                var room = new IndexViews
                {
                    AllRooms = allRooms,
                    TopRooms = topRoooms,
                    TopRestaurantMenusBreak = topRestaurantMenusBreak,
                    TopRestaurantMenusLun = topRestaurantMenusLun,
                    TopRestaurantMenusDin = topRestaurantMenusDin,
                    DemandRooms = allRooms
                };
                return View("Index", room);
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}