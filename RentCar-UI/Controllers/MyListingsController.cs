using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentCar_UI.Dtos.CategoryDto;
using RentCar_UI.Dtos.VehicleDtos;
using RentCar_UI.Services;
using System.Text;

namespace RentCar_UI.Controllers
{
    public class MyListingsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MyListingsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var id = _loginService.GetUserID;
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7007/api/Vehicles/VehicleAdvertsListByEmployeeId?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultVehicleAdvertListWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultVehicleAdvertListWithCategoryDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateListing()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7007/api/Categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                List<SelectListItem> categoryValues = (from x in values
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryID.ToString()
                                                       }).ToList();

                ViewBag.CategoryList = categoryValues;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateListing(CreateVehicleDto createVehicleDto)
        {
            createVehicleDto.AppUserID = int.Parse(_loginService.GetUserID);

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createVehicleDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7007/api/Vehicles", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var categoryResponse = await client.GetAsync("https://localhost:7007/api/Categories");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);

                List<SelectListItem> categoryValues = (from item in values
                                                       select new SelectListItem
                                                       {
                                                           Text = item.CategoryName,
                                                           Value = item.CategoryID.ToString()
                                                       }).ToList();

                ViewBag.CategoryList = categoryValues;
            }

            return View(createVehicleDto);
        }
    }
}