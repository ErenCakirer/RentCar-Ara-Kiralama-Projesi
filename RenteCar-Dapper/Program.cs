using RentCar_DapperApi.Repositories.ServiceRepository;
using RenteCar_Dapper.Containers;
using RenteCar_Dapper.Dtos.VehicleDtos;
using RenteCar_Dapper.Hubs;
using RenteCar_Dapper.Models.DapperContext;
using RenteCar_Dapper.Repo.AboutRepo;
using RenteCar_Dapper.Repo.CategoryRepo;
using RenteCar_Dapper.Repo.ContactRepo;
using RenteCar_Dapper.Repo.StatisticsRepo;
using RenteCar_Dapper.Repo.TestimonialRepo;
using RenteCar_Dapper.Repo.ToDoListRepo;
using RenteCar_Dapper.Repo.VehicleRepo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ContainerDependencies();
builder.Services.AddHttpClient();

builder.Services.AddControllers();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.MapHub<SignalRHub>("/SignalRHub");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();