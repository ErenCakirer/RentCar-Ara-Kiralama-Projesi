using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
