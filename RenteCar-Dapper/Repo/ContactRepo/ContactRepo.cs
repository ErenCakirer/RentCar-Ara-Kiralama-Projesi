using Dapper;
using RenteCar_Dapper.Dtos.CategoryDtos;
using RenteCar_Dapper.Dtos.ContactDto;
using RenteCar_Dapper.Models.DapperContext;

namespace RenteCar_Dapper.Repo.ContactRepo
{
    public class ContactRepo : IContactRepo
    {
        private readonly Context _context;

        public ContactRepo(Context context)
        {
            _context = context;
        }

        public Task CreateContactAsync(CreateContactDto createContactDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultContactDto>> GetAllContactAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Last4ContactDto>> GetAllLast4ContactAsync()
        {
            string query = "Select Top(4) * From Contact order by ContactID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Last4ContactDto>(query);
             return values.ToList();
            }
        }

        public Task<GetByIDContactDto> GetContactByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
