using RenteCar_Dapper.Dtos.AboutDtos;

namespace RenteCar_Dapper.Repo.AboutRepo
{
    public interface IAboutRepo
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<GetByIDAboutDto?> GetAboutByIdAsync(int id);
    }
}
