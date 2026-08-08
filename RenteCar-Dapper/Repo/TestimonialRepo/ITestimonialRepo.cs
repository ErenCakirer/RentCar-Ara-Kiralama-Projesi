using RenteCar_Dapper.Dtos.CategoryDtos;
using RenteCar_Dapper.Dtos.TestimonialDtos;

namespace RenteCar_Dapper.Repo.TestimonialRepo
{
    public interface ITestimonialRepo
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
       
    }
}
