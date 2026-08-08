using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar_UI.Dtos.ContactDto; 
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RentCar_UI.ViewComponents.Dashboard
{
    public class DashboardLast4ContactCP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardLast4ContactCP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7007/api/Contact/GetLast4Contact");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<Last4ContactResultDto>>(jsonData);
                return View(values);
            }
            return View(new List<Last4ContactResultDto>());
        }
    }
}