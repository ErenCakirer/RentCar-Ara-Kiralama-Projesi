using Dapper;
using RenteCar_Dapper.Dtos.AboutDtos;
using RenteCar_Dapper.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenteCar_Dapper.Repo.AboutRepo
{
    public class AboutRepo : IAboutRepo
    {
        private readonly Context _context;

        public AboutRepo(Context context)
        {
            _context = context;
        }

        public async Task<GetByIDAboutDto?> GetAboutByIdAsync(int id)
        {
            string query = "SELECT * FROM About WHERE AboutID = @id";
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<GetByIDAboutDto>(query, new { id });
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            string query = "SELECT * FROM About";
            using var connection = _context.CreateConnection();

            var values = await connection.QueryAsync<ResultAboutDto>(query);
            return values.ToList();
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            string query = "UPDATE About SET Title=@Title, SubTitle=@SubTitle, Description=@Description, ImageUrl=@ImageUrl WHERE AboutID=@AboutID";

            var param = new DynamicParameters();
            param.Add("@AboutID", updateAboutDto.AboutID);
            param.Add("@Title", updateAboutDto.Title);
            param.Add("@SubTitle", updateAboutDto.SubTitle);
            param.Add("@Description", updateAboutDto.Description);
            param.Add("@ImageUrl", updateAboutDto.ImageUrl);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, param);
        }
    }
}