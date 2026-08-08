using Microsoft.AspNetCore.Mvc;

namespace RentCar_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            #region 1. ActiveCategoryCount
            var activeCategoryResponse = await client.GetAsync("https://localhost:7007/api/Statistics/ActiveCategoryCount");
            ViewBag.ActiveCategoryCount = activeCategoryResponse.IsSuccessStatusCode
                ? await activeCategoryResponse.Content.ReadAsStringAsync()
                : "0";
#endregion

            #region 2. AveragePrice
            var avgPriceResponse = await client.GetAsync("https://localhost:7007/api/Statistics/AveragePrice");
            ViewBag.AveragePrice = avgPriceResponse.IsSuccessStatusCode
                ? await avgPriceResponse.Content.ReadAsStringAsync()
                : "0.00";
            #endregion

            #region 3. CategoryCount
            var categoryCountResponse = await client.GetAsync("https://localhost:7007/api/Statistics/CategoryCount");
            ViewBag.CategoryCount = categoryCountResponse.IsSuccessStatusCode
                ? await categoryCountResponse.Content.ReadAsStringAsync()
                : "0";
            #endregion

            #region 4. DifferentCityCount
            var differentCityResponse = await client.GetAsync("https://localhost:7007/api/Statistics/DifferentCityCount");
            ViewBag.DifferentCityCount = differentCityResponse.IsSuccessStatusCode
                ? await differentCityResponse.Content.ReadAsStringAsync()
                : "0";
            #endregion

            #region 5. GetAverageVehicleCountPerCategory
            var avgCountPerCategoryResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetAverageVehicleCountPerCategory");
            ViewBag.AvgVehicleCountPerCategory = avgCountPerCategoryResponse.IsSuccessStatusCode
                ? await avgCountPerCategoryResponse.Content.ReadAsStringAsync()
                : "0";
            #endregion

            #region 6. GetCheapestVehicleName
            var cheapestVehicleResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetCheapestVehicleName");
            ViewBag.CheapestVehicleName = cheapestVehicleResponse.IsSuccessStatusCode
                ? await cheapestVehicleResponse.Content.ReadAsStringAsync()
                : "Veri Yok";
            #endregion

            #region 7. GetCityWithMostVehicles
            var mostVehicleCityResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetCityWithMostVehicles");
            ViewBag.CityWithMostVehicles = mostVehicleCityResponse.IsSuccessStatusCode
                ? await mostVehicleCityResponse.Content.ReadAsStringAsync()
                : "Veri Yok";
            #endregion

            #region 8. GetIdOfCategoryWithMostVehicles
            var mostVehicleCategoryIdResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetIdOfCategoryWithMostVehicles");
            ViewBag.IdOfCategoryWithMostVehicles = mostVehicleCategoryIdResponse.IsSuccessStatusCode
                ? await mostVehicleCategoryIdResponse.Content.ReadAsStringAsync()
                : "0";
            #endregion

            #region 9. GetLatestVehicle
            var latestVehicleResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetLatestVehicle");
            ViewBag.LatestVehicle = latestVehicleResponse.IsSuccessStatusCode
                ? await latestVehicleResponse.Content.ReadAsStringAsync()
                : "Veri Yok";
            #endregion

            #region 10. GetMostExpensiveVehicleName
            var mostExpensiveVehicleResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetMostExpensiveVehicleName");
            ViewBag.MostExpensiveVehicleName = mostExpensiveVehicleResponse.IsSuccessStatusCode
                ? await mostExpensiveVehicleResponse.Content.ReadAsStringAsync()
                : "Veri Yok";
            #endregion

            #region 11. GetPriceGapBetweenMaxAndMin
            var priceGapResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetPriceGapBetweenMaxAndMin");
            ViewBag.PriceGapBetweenMaxAndMin = priceGapResponse.IsSuccessStatusCode
                ? await priceGapResponse.Content.ReadAsStringAsync()
                : "0.00";
            #endregion

            #region 12. GetTopVehicleBrand
            var topBrandResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetTopVehicleBrand");
            ViewBag.TopVehicleBrand = topBrandResponse.IsSuccessStatusCode
                ? await topBrandResponse.Content.ReadAsStringAsync()
                : "Veri Yok";
            #endregion

            #region 13. GetVehicleCountAboveAveragePrice
            var aboveAvgResponse = await client.GetAsync("https://localhost:7007/api/Statistics/GetVehicleCountAboveAveragePrice");
            ViewBag.VehicleCountAboveAveragePrice = aboveAvgResponse.IsSuccessStatusCode
                ? await aboveAvgResponse.Content.ReadAsStringAsync()
                : "0";
            #endregion

            #region 14. PassiveCategoryCount
            var passiveCategoryResponse = await client.GetAsync("https://localhost:7007/api/Statistics/PassiveCategoryCount");
            ViewBag.PassiveCategoryCount = passiveCategoryResponse.IsSuccessStatusCode
                ? await passiveCategoryResponse.Content.ReadAsStringAsync()
                : "0";
            #endregion

            #region 15. VehicleCount
            var vehicleCountResponse = await client.GetAsync("https://localhost:7007/api/Statistics/VehicleCount");
            ViewBag.VehicleCount = vehicleCountResponse.IsSuccessStatusCode
                ? await vehicleCountResponse.Content.ReadAsStringAsync()
                : "0";
            #endregion
            return View();
        }
    }
}
