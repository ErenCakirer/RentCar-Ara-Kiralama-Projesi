using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar_UI.Dtos.VehicleDtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RentCar_UI.ViewComponents.Dashboard
{
    public class DashboardLast5CP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardLast5CP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7007/api/Vehicles/GetLast5Vehicles");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultVehicleDto>>(jsonData);
                return View(values);
            }

            return View(new List<ResultVehicleDto>());
        }
    }
}