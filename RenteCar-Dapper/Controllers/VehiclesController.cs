using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenteCar_Dapper.Dtos.VehicleDtos;
using RenteCar_Dapper.Repo.VehicleRepo;

namespace RenteCar_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepo _vehicleRepo;

        public VehiclesController(IVehicleRepo vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> VehicleList()
        {
            var values = await _vehicleRepo.GetAllVehicleAsync();
            return Ok(values);
        }

        [HttpGet("GetVehicleDetailByVehicleId/{id}")]
        public async Task<IActionResult> GetVehicleDetailByVehicleId(int id)
        {
            var value = await _vehicleRepo.GetVehicleDetailByVehicleIdAsync(id);
            if (value == null)
            {
                return NotFound("Bu araca ait detay bilgisi bulunamadı.");
            }
            return Ok(value);
        }

        [HttpGet("GetLast5Vehicles")]
        public async Task<IActionResult> GetLast5Vehicles()
        {
            var values = await _vehicleRepo.GetLast5VehicleAsync();
            return Ok(values);
        }

        [HttpGet("VehicleAdvertsListByEmployeeId")]
        public async Task<IActionResult> VehicleAdvertsListByEmployee(int id)
        {
            var values = await _vehicleRepo.VehicleAdvertsListByEmployeeAsync(id); 
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleDto createVehicleDto)
        {
            await _vehicleRepo.CreateVehicleAsync(createVehicleDto);
            return Ok("Araç ilanı başarıyla oluşturuldu.");
        }
        [HttpGet("GetFilteredVehicles")]
        public async Task<IActionResult> GetFilteredVehicles([FromQuery] FilterVehicleDto filter)
        {
            var values=await _vehicleRepo.GetFilteredVehiclesAsync(filter);
            return Ok(values);
        }
    }
}