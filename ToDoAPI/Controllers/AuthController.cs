using Microsoft.AspNetCore.Mvc;

namespace ToDoAPI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
