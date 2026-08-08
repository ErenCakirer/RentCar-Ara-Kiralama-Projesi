using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenteCar_Dapper.Repo.TestimonialRepo;

namespace RenteCar_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialRepo testimonialRepo;

        public TestimonialController(ITestimonialRepo testimonialRepo)
        {
            this.testimonialRepo = testimonialRepo;
        }
        [HttpGet]
        public async Task< IActionResult> TestimonialList()
        {
            var value = await testimonialRepo.GetAllTestimonialAsync();
            return Ok(value);

        }
    }
}
