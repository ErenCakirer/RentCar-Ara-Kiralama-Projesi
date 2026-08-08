using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.ViewComponents.HomePage
{
    public class ServiceVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
