using RenteCar_Dapper.Dtos.ContactDto;


namespace RenteCar_Dapper.Repo.ContactRepo
{
    public interface IContactRepo
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<List<Last4ContactDto>> GetAllLast4ContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task DeleteContactAsync(int id);
        Task<GetByIDContactDto> GetContactByIdAsync(int id);
    }
}
