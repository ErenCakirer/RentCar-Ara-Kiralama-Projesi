using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.ViewComponents.AdminLayout
{
    public class AdminLayoutSidebar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
