using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar_UI.Dtos.ToDoListDto;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RentCar_UI.ViewComponents.Dashboard
{
    public class DashboardToDoListCP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardToDoListCP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7007/api/ToDoLists");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultToDoListDto>>(jsonData);
                return View(values);
            }

            return View(new List<ResultToDoListDto>());
        }
    }
}