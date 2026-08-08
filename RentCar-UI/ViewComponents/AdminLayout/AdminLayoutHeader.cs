using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.ViewComponents.AdminLayout
{
    public class AdminLayoutHeader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
