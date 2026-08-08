using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar_UI.Dtos.TestimonialDtos;

namespace RentCar_UI.ViewComponents.HomePage
{
    public class TestimonialVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7007/api/Testimonial");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);

                return View(values);
            }
            return View(new List<ResultTestimonialDto>());
        }
    }
}