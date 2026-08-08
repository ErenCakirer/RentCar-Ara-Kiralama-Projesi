using Microsoft.AspNetCore.Mvc;
using RenteCar_Dapper.Dtos.ServiceDtos;
using RentCar_DapperApi.Repositories.ServiceRepository;

namespace RenteCar_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _serviceRepository.GetAllServiceAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var value = await _serviceRepository.GetByIdServiceAsync(id);
            if (value == null)
            {
                return NotFound("İlgili hizmet bulunamadı.");
            }
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceRepository.CreateServiceAsync(createServiceDto);
            return Ok("Hizmet başarıyla eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceRepository.DeleteServiceAsync(id);
            return Ok("Hizmet başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceRepository.UpdateServiceAsync(updateServiceDto);
            return Ok("Hizmet başarıyla güncellendi.");
        }
    }
}