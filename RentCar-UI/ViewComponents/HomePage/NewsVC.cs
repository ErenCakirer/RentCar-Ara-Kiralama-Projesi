using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.ViewComponents.HomePage
{
    public class NewsVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
