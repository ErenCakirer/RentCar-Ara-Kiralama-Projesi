using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.ViewComponents.Layout
{
    public class HeaderVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
