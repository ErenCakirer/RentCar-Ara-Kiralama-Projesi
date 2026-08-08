using RenteCar_Dapper.Dtos.CategoryDtos;

namespace RenteCar_Dapper.Repo.CategoryRepo
{
    public interface ICategoryRepository
    { Task<List<ResultCategoryDto>>GetAllCategoryAsync();
        Task CreateCategory(CreateCategoryDto categoryDto);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<GetByIDCategoryDto> GetCategory(int id);
    }
}
