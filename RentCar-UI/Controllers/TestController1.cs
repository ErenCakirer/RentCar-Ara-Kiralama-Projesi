using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.Controllers
{
    public class TestController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
