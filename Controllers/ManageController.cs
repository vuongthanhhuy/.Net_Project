using FinalProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace FinalProject.Controllers
{
	public class ManageController : Controller
	{
		private readonly ILogger<ManageController> _logger;
		private SystemDBContext _context;

		public ManageController(ILogger<ManageController> logger, SystemDBContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

        public IActionResult RoomsManage()
        {
            return View("RoomsManage");
        }

        public IActionResult Customers()
        {
            return View("Customers");
        }
		public IActionResult CustomersByStaff()
        {
            return View("CustomersByStaff");
        }
        public IActionResult Order()
        {
            return View("Order");
        }
        public IActionResult OrderList()
        {
            return View("OrderList");
        }
        public IActionResult Reviews()
        {
            return View("Reviews");

		}
        
    }
}
