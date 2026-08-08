using Dapper;
using RentCar_UI.Dtos.ToDoListDto;
using RenteCar_Dapper.Dtos.ToDoListDtos;
using RenteCar_Dapper.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenteCar_Dapper.Repo.ToDoListRepo
{
    public class ToDoListRepo : IToDoListRepo
    {
        private readonly Context _context;

        public ToDoListRepo(Context context)
        {
            _context = context;
        }

        public async Task<List<RentCar_UI.Dtos.ToDoListDto.ResultToDoListDto>> GetAllToDoListAsync()
        {
            string query = "SELECT * FROM ToDoList ORDER BY ToDoListID DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }
    }
}