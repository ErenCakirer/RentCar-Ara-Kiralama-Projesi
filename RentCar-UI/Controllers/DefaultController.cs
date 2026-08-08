using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
