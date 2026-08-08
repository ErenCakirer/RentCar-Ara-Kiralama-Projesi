using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar_UI.Dtos.VehicleDtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RentCar_UI.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VehicleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int? brandId, string? fuelType, string? transmission, decimal? minPrice, decimal? maxPrice)
        {
            var client = _httpClientFactory.CreateClient();
            var queryParams = new List<string>();

            if (brandId.HasValue && brandId > 0)
                queryParams.Add($"brandId={brandId}");

            if (!string.IsNullOrEmpty(fuelType))
                queryParams.Add($"fuelType={fuelType}");

            if (!string.IsNullOrEmpty(transmission))
                queryParams.Add($"transmission={transmission}");

            if (minPrice.HasValue && minPrice > 0)
                queryParams.Add($"minPrice={minPrice}");

            if (maxPrice.HasValue && maxPrice > 0)
                queryParams.Add($"maxPrice={maxPrice}");
            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
            string url = $"https://localhost:7007/api/Vehicles/GetFilteredVehicles{queryString}";

            var responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultVehicleDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultVehicleDto>());
        }

        public async Task<IActionResult> VehicleDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7007/api/Vehicles/GetVehicleDetailByVehicleId/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetVehicleDetailDto>(jsonData);

                return View(value);
            }
            return View();
        }
    }
}