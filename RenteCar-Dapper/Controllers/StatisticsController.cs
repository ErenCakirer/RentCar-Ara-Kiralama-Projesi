using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenteCar_Dapper.Repo.StatisticsRepo;
using System.Threading.Tasks;

namespace RenteCar_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepo _statisticsRepo;

        public StatisticsController(IStatisticsRepo statisticsRepo)
        {
            _statisticsRepo = statisticsRepo;
        }
        [HttpGet("ActiveCategoryCount")]
        public async Task<IActionResult> ActiveCategoryCount()
        {
            return Ok( await _statisticsRepo.ActiveCategoryCount());
        }
        [HttpGet("AveragePrice")]
        public async Task<IActionResult> AveragePrice()
        {
            return Ok(await _statisticsRepo.AveragePrice());
        }
        [HttpGet("CategoryCount")]
        public async Task<IActionResult> CategoryCount()
        {
            return Ok(await _statisticsRepo.CategoryCount());   
        }
        [HttpGet("VehicleCount")]
        public async Task<IActionResult> VehicleCount()
        {
            return Ok(await _statisticsRepo.VehicleCount());
        }
        [HttpGet("DifferentCityCount")]
        public async Task<IActionResult> DifferentCityCount()
        {
            return Ok(await _statisticsRepo.DifferentCityCount());
        }
        [HttpGet("GetAverageVehicleCountPerCategory")]
        public async Task <IActionResult> GetAverageVehicleCountPerCategory()
        {
            return Ok(await _statisticsRepo.GetAverageVehicleCountPerCategory());
        }
        [HttpGet("GetCheapestVehicleName")]
        public async Task<IActionResult> GetCheapestVehicleName()
        {
            return Ok(await _statisticsRepo.GetCheapestVehicleName());
        }
        [HttpGet("GetCityWithMostVehicles")]
        public async Task<IActionResult> GetCityWithMostVehicles()
        {
            return Ok(await _statisticsRepo.GetCityWithMostVehicles());

        }
        [HttpGet("GetIdOfCategoryWithMostVehicles")]
        public async Task<IActionResult> GetIdOfCategoryWithMostVehicles()
        {
            return Ok(await _statisticsRepo.GetIdOfCategoryWithMostVehicles());
        }
        [HttpGet("GetLatestVehicle")]
        public async Task<IActionResult> GetLatestVehicle()
        {
            return Ok(await _statisticsRepo.GetLatestVehicle());
        }
        [HttpGet("GetMostExpensiveVehicleName")]
        public async Task<IActionResult> GetMostExpensiveVehicleName()
        {
            return Ok(await _statisticsRepo.GetMostExpensiveVehicleName());
        }
        [HttpGet("GetPriceGapBetweenMaxAndMin")]
        public async Task<IActionResult> GetPriceGapBetweenMaxAndMin()
        {
            return Ok(await _statisticsRepo.GetPriceGapBetweenMaxAndMin());
        }
        [HttpGet("GetTopVehicleBrand")]
        public async Task<IActionResult> GetTopVehicleBrand()
        {
            return Ok(await _statisticsRepo.GetTopVehicleBrand());
        }
        [HttpGet("GetVehicleCountAboveAveragePrice")]
        public async Task <IActionResult> GetVehicleCountAboveAveragePrice()
        {
            return Ok(await _statisticsRepo.GetVehicleCountAboveAveragePrice());
        }
        [HttpGet("PassiveCategoryCount")]
        public async Task<IActionResult> PassiveCategoryCount()
        {
            return Ok(await _statisticsRepo.PassiveCategoryCount());
        }
        [HttpGet("TestimonialCount")]
        public async Task<IActionResult> TestimonialCount()
        {
            return Ok(await _statisticsRepo.TestimonialCount());
        }
    
              [HttpGet("ClientCount")]
        public async Task<IActionResult> ClientCount()
        {
            return Ok(await _statisticsRepo.TestimonialCount());
        }
    }
}
