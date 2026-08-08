using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using RentCar_UI.Dtos.ServicesDtos;

namespace RentCar_UI.ViewComponents.HomePage
{
    public class WhoWeAreVC:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WhoWeAreVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7007/api/Service");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultServiceDto>> (jsonData);
                return View (values);
            }
            return View();
        }
    }
}
