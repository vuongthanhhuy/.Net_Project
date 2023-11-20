using FinalProject.Data;
using FinalProject.Services;
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
            var allHistory = _context.History.ToList();
            var allRooms = _context.Rooms.ToList();
            var allAccounts = _context.Accounts.ToList();

            var customersView = new CustomerViews
            {
                AllHistory = allHistory,
                AllRooms = allRooms,
                AllAccounts = allAccounts
            };
            return View("Customers", customersView);
        }
		public IActionResult CustomersByStaff()
        {
            var allHistoryStaffs = _context.HistoryStaffs.ToList();
            var allRooms = _context.Rooms.ToList();
            var allAccounts = _context.Accounts.ToList();

			var customersView = new CustomerStaffViews
			{
				AllHistoryStaffs = allHistoryStaffs,
				AllRooms = allRooms,
				AllAccounts = allAccounts
			};

			return View("CustomersByStaff", customersView);
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
