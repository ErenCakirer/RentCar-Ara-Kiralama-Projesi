using Dapper;
using RenteCar_Dapper.Dtos.CategoryDtos;
using RenteCar_Dapper.Dtos.TestimonialDtos;
using RenteCar_Dapper.Models.DapperContext;

namespace RenteCar_Dapper.Repo.TestimonialRepo
{
    public class TestimonialRepo : ITestimonialRepo
    {
        private readonly Context _context;

        public TestimonialRepo(Context context)
        {
           _context = context;
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }
    }
}
