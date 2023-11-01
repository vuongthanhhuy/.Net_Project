using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RoomsDBContext _context;

        public HomeController(ILogger<HomeController> logger, RoomsDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult rooms()
        {
            var room = _context.Rooms;
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}