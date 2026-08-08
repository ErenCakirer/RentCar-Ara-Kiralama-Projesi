using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.ViewComponents.CarDealer
{
    public class DealerSideBarCP:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
