using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenteCar_Dapper.Repo.ToDoListRepo;
using System.Threading.Tasks;

namespace RenteCar_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepo _toDoListRepo;

        public ToDoListsController(IToDoListRepo toDoListRepo)
        {
            _toDoListRepo = toDoListRepo;
        }

        [HttpGet]
        public async Task<IActionResult> ToDoListList()
        {
            var values = await _toDoListRepo.GetAllToDoListAsync();
            return Ok(values);
        }
    }
}