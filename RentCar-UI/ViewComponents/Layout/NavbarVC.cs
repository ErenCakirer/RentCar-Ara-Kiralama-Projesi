using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.ViewComponents.Layout
{
    public class NavbarVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
