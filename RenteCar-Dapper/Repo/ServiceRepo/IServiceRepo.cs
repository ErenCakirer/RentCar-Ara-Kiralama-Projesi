
using RenteCar_Dapper.Dtos.ServiceDtos;

namespace RentCar_DapperApi.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        Task CreateServiceAsync(CreateServiceDto createServiceDto);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task DeleteServiceAsync(int id);
        Task<ResultServiceDto> GetByIdServiceAsync(int id);
    }
}