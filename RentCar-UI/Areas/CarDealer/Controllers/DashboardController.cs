using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.Areas.CarDealer.Controllers
{
    public class DashboardController : Controller
    {
        [Area("CarDealer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
