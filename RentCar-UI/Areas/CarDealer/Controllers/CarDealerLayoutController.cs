using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.Areas.CarDealerArea.Controllers
{
    [Area("CarDealer")]
    public class CarDealerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
