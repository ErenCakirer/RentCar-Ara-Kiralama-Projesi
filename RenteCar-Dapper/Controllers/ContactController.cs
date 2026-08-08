using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenteCar_Dapper.Repo.ContactRepo;

namespace RenteCar_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepo _contactRepo;

        public ContactController(IContactRepo contactRepo)
        {
            _contactRepo = contactRepo;
        }
        [HttpGet("GetLast4Contact")]
        public async Task<IActionResult> GetLast4Contact()
        {
            var values= await _contactRepo.GetAllLast4ContactAsync();
            return Ok(values);
        }
    }
}
