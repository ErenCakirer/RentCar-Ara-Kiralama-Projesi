using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Category");
        }
    }
}