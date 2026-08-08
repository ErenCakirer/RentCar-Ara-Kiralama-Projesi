using Dapper;
using RenteCar_Dapper.Dtos.ServiceDtos;
using RenteCar_Dapper.Models.DapperContext;

namespace RentCar_DapperApi.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultServiceDto?> GetByIdServiceAsync(int id)
        {
            string query = "Select * From Service Where ServiceID = @serviceID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<ResultServiceDto>(query, new { serviceID = id });
            }
        }

        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            string query = "Insert Into Service (Title, Description, Status) Values (@title, @description, @status)";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, createServiceDto);
            }
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            string query = "Update Service Set Title = @title, Description = @description, Status = @status Where ServiceID = @serviceID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, updateServiceDto);
            }
        }

        public async Task DeleteServiceAsync(int id)
        {
            string query = "Delete From Service Where ServiceID = @serviceID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, new { serviceID = id });
            }
        }
    }
}