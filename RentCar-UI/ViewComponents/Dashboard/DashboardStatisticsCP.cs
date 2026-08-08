using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace RentCar_UI.ViewComponents.Dashboard
{
    public class DashboardStatisticsCP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardStatisticsCP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region 15. VehicleCount
            var vehicleCountResponse = await client.GetAsync("https://localhost:7007/api/Statistics/VehicleCount");
            ViewBag.VehicleCount = vehicleCountResponse.IsSuccessStatusCode
                ? await vehicleCountResponse.Content.ReadAsStringAsync()
                : "0";
            #endregion

            #region 10. GetMostExpensiveVehicleName
            var mostExpensiveVehicleResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetMostExpensiveVehicleName");
            ViewBag.MostExpensiveVehicleName = mostExpensiveVehicleResponse.IsSuccessStatusCode
                ? await mostExpensiveVehicleResponse.Content.ReadAsStringAsync()
                : "Veri Yok";
            #endregion

            #region 7. GetCityWithMostVehicles
            var mostVehicleCityResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetCityWithMostVehicles");
            ViewBag.CityWithMostVehicles = mostVehicleCityResponse.IsSuccessStatusCode
                ? await mostVehicleCityResponse.Content.ReadAsStringAsync()
                : "Veri Yok";
            #endregion

            #region 9. GetLatestVehicle
            var latestVehicleResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetLatestVehicle");
            ViewBag.LatestVehicle = latestVehicleResponse.IsSuccessStatusCode
                ? await latestVehicleResponse.Content.ReadAsStringAsync()
                : "Veri Yok";
            #endregion

            return View();
        }
    }
}