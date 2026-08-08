using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenteCar_Dapper.Dtos.AboutDtos;
using RenteCar_Dapper.Repo.AboutRepo;

namespace RenteCar_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutRepo _aboutRepo;

        public AboutController(IAboutRepo aboutRepo)
        {
            _aboutRepo = aboutRepo;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutRepo.GetAllAboutAsync();
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutRepo.UpdateAboutAsync(updateAboutDto);
            return Ok("Hakkımızda alanı güncellendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _aboutRepo.GetAboutByIdAsync(id);
            return Ok(value);
        }
    }
}

