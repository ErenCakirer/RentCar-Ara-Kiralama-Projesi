using Microsoft.AspNetCore.Mvc;
using RenteCar_Dapper.Tools;

namespace RenteCar_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateToken([FromBody] CheckAppUser model)
        {
            var values = JwtTokenGenerator.GenerateToken(model);
            return Ok(values);
        }
    }
}