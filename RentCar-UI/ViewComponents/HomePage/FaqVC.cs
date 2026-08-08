using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.ViewComponents.HomePage
{
    public class FaqVC:ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
