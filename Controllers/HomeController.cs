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
                DemandRooms = null
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

            var topRestaurantMenusBreak = _context.RestaurantMenus.Where(b => b.Meal.Contains("Breakfast")).Take(3).ToList();
            var topRestaurantMenusLun = _context.RestaurantMenus.Where(b => b.Meal.Contains("Lunch")).Take(3).ToList();
            var topRestaurantMenusDin = _context.RestaurantMenus.Where(b => b.Meal.Contains("Dinner")).Take(3).ToList();

            DateTime checkInDate = DateTime.ParseExact(checkin_date, "d MMMM, yyyy", null);
            string cCheckInDate = checkInDate.ToString("dd/MM/yyyy");
            DateTime checkOutDate = DateTime.ParseExact(checkout_date, "d MMMM, yyyy", null);
            string cCheckOutDate = checkOutDate.ToString("dd/MM/yyyy");

            /*var demandRooms = _context.Rooms
                                      .Where(room => !room.RoomBookings.Any(booking =>
                                      () ||
                                      () ||
                                      ()))
                                      .ToList();*/

            var room = new IndexViews
            {
                AllRooms = allRooms,
                TopRooms = topRoooms,
                TopRestaurantMenusBreak = topRestaurantMenusBreak,
                TopRestaurantMenusLun = topRestaurantMenusLun,
                TopRestaurantMenusDin = topRestaurantMenusDin,
                DemandRooms = null
            };

            return View("Index", room);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}