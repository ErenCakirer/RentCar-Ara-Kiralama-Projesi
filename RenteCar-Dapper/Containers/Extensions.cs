using RentCar_DapperApi.Repositories.ServiceRepository;
using RentCar_UI.ViewComponents.HomePage;
using RenteCar_Dapper.Models.DapperContext;
using RenteCar_Dapper.Repo.AboutRepo;
using RenteCar_Dapper.Repo.CategoryRepo;
using RenteCar_Dapper.Repo.ContactRepo;
using RenteCar_Dapper.Repo.StatisticsRepo;
using RenteCar_Dapper.Repo.TestimonialRepo;
using RenteCar_Dapper.Repo.ToDoListRepo;
using RenteCar_Dapper.Repo.VehicleRepo;

namespace RenteCar_Dapper.Containers
{
    public static class Extensions
    {
        public static void  ContainerDependencies( this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
           services.AddTransient<Context>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IToDoListRepo, ToDoListRepo>();
            services.AddTransient<IVehicleRepo, VehicleRepo>();
            services.AddTransient<ITestimonialRepo, TestimonialRepo>();
            services.AddTransient<IStatisticsRepo, StatisticsRepo>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IContactRepo, ContactRepo>();
            services.AddTransient<IAboutRepo, AboutRepo>();
        }
    }
}
