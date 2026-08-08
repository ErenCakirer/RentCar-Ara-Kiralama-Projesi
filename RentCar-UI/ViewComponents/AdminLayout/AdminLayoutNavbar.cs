using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.ViewComponents.AdminLayout
{
    public class AdminLayoutNavbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
