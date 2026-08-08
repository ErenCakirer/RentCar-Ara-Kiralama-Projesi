
using Dapper;
using RenteCar_Dapper.Models.DapperContext;

namespace RenteCar_Dapper.Repo.StatisticsRepo
{
    public class StatisticsRepo : IStatisticsRepo
    {
        private readonly Context _context;

        public StatisticsRepo(Context context)
        {
            _context = context;
        }

        public async Task<int> ActiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus = 1";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<decimal> AveragePrice()
        {
            string query = "Select Avg(price)From Product";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.ExecuteScalarAsync<decimal?>(query);
                return value ?? 0;
            }
        }

        public async Task<int> CategoryCount()
        {
            string query = "Select Count(*) From Category";

            using (var connection = _context.CreateConnection())
            {
                await ((System.Data.Common.DbConnection)connection).OpenAsync();

                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<int> VehicleCount()
        {
            string query = "Select Count(*) From Product";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<int> DifferentCityCount()
        {
            string query = "Select Count(Distinct([District])) From Product";
            using var connection = _context.CreateConnection();
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<int> GetAverageVehicleCountPerCategory()
        {
            string query = @"Select 
                        Case 
                            When Count(*) = 0 Then 0 
                            Else (Select Count(*) From Product) / Count(*) 
                        End 
                     From Category";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<string> GetCheapestVehicleName()
        {
            string query = "Select Top 1 title From Product Order By price Asc";

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<string>(query);
                return value ?? "Araç Bulunmamaktadır";
            }
        }

        public async Task<string> GetCityWithMostVehicles()
        {
            string query = @"Select Top 1 city From Product 
                     Group By city 
                     Order By Count(*) Desc";

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<string>(query);
                return value ?? "Veri Bulunamadı";
            }
        }
        public async Task<int> GetIdOfCategoryWithMostVehicles()
        {
            string query = @"Select Top 1 productCategory From Product 
                     Group By productCategory 
                     Order By Count(*) Desc";

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.ExecuteScalarAsync<int?>(query);
                return value ?? 0;
            }
        }

        public async Task<string> GetLatestVehicle()
        {
            string query = "Select Top 1 title From Product Order By ProductID Desc";

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<string>(query);
                return value ?? "Henüz Araç Eklenmemiş";
            }
        }

        public async Task<string> GetMostExpensiveVehicleName()
        {
            string query = "Select Top 1 title From Product Order By price Desc";

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<string>(query);
                return value ?? "Araç Bulunmamaktadır";
            }
        }

        public async Task<decimal> GetPriceGapBetweenMaxAndMin()
        {
            string query = "Select (Max(price) - Min(price)) From Product";

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.ExecuteScalarAsync<decimal?>(query);
                return value ?? 0; 
            }
        }

        public async Task<string> GetTopVehicleBrand()
        {
            string query = @"Select Top 1 c.CategoryName From Product p 
                     Inner Join Category c On p.productCategory = c.CategoryID 
                     Group By c.CategoryName 
                     Order By Count(*) Desc";

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<string>(query);
                return value ?? "Veri Bulunmamaktadır";
            }
        }

        public async Task<int> GetVehicleCountAboveAveragePrice()
        {
         
            string query = "Select Count(*) From Product Where price > (Select Avg(price) From Product)";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<int> PassiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus = 0";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public Task<int> TestimonialCount()
        {
            string query = "Select Count(*) From  Testimonial";
            using (var connection = _context.CreateConnection())
            {
                return connection.ExecuteScalarAsync<int>(query);
            }
        }

        public Task<int> ClientCount()
        {
            string query = "Select Count(*) From  Client";
            using (var connection = _context.CreateConnection())
            {
                return connection.ExecuteScalarAsync<int>(query);
            }
        }
    }
}
