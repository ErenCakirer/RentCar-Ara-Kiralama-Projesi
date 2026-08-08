using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
