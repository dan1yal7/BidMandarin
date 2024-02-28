using Microsoft.AspNetCore.Mvc;

namespace BidMandarin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
