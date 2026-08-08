using RenteCar_Dapper.Dtos.VehicleDtos;

namespace RenteCar_Dapper.Repo.VehicleRepo
{
    public interface IVehicleRepo
    {
        Task<List<ResultVehicleDto>> GetFilteredVehiclesAsync(FilterVehicleDto filter);
        Task<List<ResultVehicleDto>> GetAllVehicleAsync();
        Task<List<ResultVehicleAdvertListWithCategoryDto>> VehicleAdvertsListByEmployeeAsync(int id); 
        Task CreateVehicleAsync(CreateVehicleDto createVehicleDto);
        Task DeleteVehicleAsync(int id);
        Task UpdateVehicleAsync(UpdateVehicleDto updateVehicleDto);
        Task<GetByIDVehicleDto> GetVehicleByIdAsync(int id);
        Task<GetVehicleDetailDto> GetVehicleDetailByVehicleIdAsync(int id);
        Task<List<ResultVehicleDto>> GetLast5VehicleAsync();
    }
}