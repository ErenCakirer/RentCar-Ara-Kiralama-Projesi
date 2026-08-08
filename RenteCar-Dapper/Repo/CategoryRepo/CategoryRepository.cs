using Dapper;
using RenteCar_Dapper.Dtos.CategoryDtos;
using RenteCar_Dapper.Models.DapperContext;
using System.Threading.Tasks;

namespace RenteCar_Dapper.Repo.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "Insert Into Category(CategoryName, CategoryStatus)values (@categoryName,@categoryStatus)";
            var param = new DynamicParameters();
            param.Add("@categoryName",categoryDto.CategoryName);
            param.Add("@categoryStatus", true);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, param);
            }
        }



        public async Task DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID = @categoryID";

            var param = new DynamicParameters();
            param.Add("@categoryID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, param);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID=@CategoryID";
            var param= new DynamicParameters();
            param.Add("@CategoryID",id);
            using(var connection=_context.CreateConnection())
            {
            return    await connection.QueryFirstAsync<GetByIDCategoryDto>(query, param);
                
                
            }
           
        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName,categoryStatus=@categoryStatus where CategoryID=@categoryID";
            var param= new DynamicParameters();
            param.Add("@categoryName",updateCategoryDto.CategoryName);
            param.Add("@categoryID", updateCategoryDto.CategoryID);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, param);
            }
        }
    }
}
