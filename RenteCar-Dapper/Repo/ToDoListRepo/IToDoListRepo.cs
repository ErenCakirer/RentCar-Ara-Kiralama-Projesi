using RentCar_UI.Dtos.ToDoListDto;

namespace RenteCar_Dapper.Repo.ToDoListRepo
{
    public interface IToDoListRepo
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
    }
}
