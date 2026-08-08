using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.ViewComponents.HomePage
{
    public class FeatureVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
