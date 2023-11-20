using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class Login : Controller
    {
        public IActionResult login()
        {
            return View("login", "_Login");
        }
        public IActionResult signUp()
        {
            return View("signUp", "_Login");
        }
        public IActionResult forgotPass()
        {
            return View("forgotPass", "_Login");
        }
    }
}
