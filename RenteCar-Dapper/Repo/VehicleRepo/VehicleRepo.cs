using Dapper;
using RenteCar_Dapper.Dtos.VehicleDtos;
using RenteCar_Dapper.Models.DapperContext;
using RenteCar_Dapper.Repo.VehicleRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenteCar_Dapper.Repo.VehicleRepo
{
    public class VehicleRepo : IVehicleRepo
    {
        private readonly Context _context;

        public VehicleRepo(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultVehicleDto>> GetAllVehicleAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultVehicleDto>(query);
                return values.ToList();
            }
        }

        public async Task CreateVehicleAsync(CreateVehicleDto createVehicleDto)
        {
            string query = @"INSERT INTO Product (Title, Price, City, District, CoverImage, productCategory, AppUserID, Description, FuelType, Transmission) 
                            VALUES (@Title, @Price, @City, @District, @CoverImage, @ProductCategory, @AppUserID, @Description, @FuelType, @Transmission)";

            string image = !string.IsNullOrEmpty(createVehicleDto.ImageUrl) ? createVehicleDto.ImageUrl : createVehicleDto.ImageUrl;
            int category = createVehicleDto.CategoryID != 0 ? createVehicleDto.CategoryID : createVehicleDto.ProductCategory;

            var param = new DynamicParameters();
            param.Add("@Title", createVehicleDto.Title);
            param.Add("@Price", createVehicleDto.Price);
            param.Add("@City", createVehicleDto.City);
            param.Add("@District", createVehicleDto.District);
            param.Add("@CoverImage", image);
            param.Add("@ProductCategory", category);
            param.Add("@AppUserID", createVehicleDto.AppUserID);
            param.Add("@Description", createVehicleDto.Description);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, param);
            }
        }

        public async Task DeleteVehicleAsync(int id)
        {
            string query = "Delete From Product Where productID = @productID";
            var param = new DynamicParameters();
            param.Add("@productID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, param);
            }
        }

        public async Task<GetByIDVehicleDto> GetVehicleByIdAsync(int id)
        {
            string query = "Select * From Product Where productID = @productID";
            var param = new DynamicParameters();
            param.Add("@productID", id);

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIDVehicleDto>(query, param);
            }
        }

        public async Task UpdateVehicleAsync(UpdateVehicleDto updateVehicleDto)
        {
            string query = "Update Product Set title=@title, price=@price, city=@city, district=@district, CoverImage=@CoverImage, productCategory=@productCategory Where productID=@productID";

            var param = new DynamicParameters();
            param.Add("@productID", updateVehicleDto.productID);
            param.Add("@title", updateVehicleDto.title);
            param.Add("@price", updateVehicleDto.price);
            param.Add("@city", updateVehicleDto.city);
            param.Add("@district", updateVehicleDto.district);
            param.Add("@CoverImage", updateVehicleDto.CoverImage);
            param.Add("@productCategory", updateVehicleDto.productCategory);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, param);
            }
        }

        public async Task<GetVehicleDetailDto> GetVehicleDetailByVehicleIdAsync(int id)
        {
            string query = @"SELECT p.ProductID, p.Title, p.Price, p.CoverImage, p.City, p.District, p.Description, p.FuelType, p.Transmission,
                                    pd.ProductDetailID, pd.Kilometer, pd.SeatCount, pd.GearCount, pd.EngineSize, pd.ModelYear, pd.VideoUrl 
                             FROM Product p 
                             LEFT JOIN ProductDetail pd ON p.ProductID = pd.ProductID 
                             WHERE p.ProductID = @productID";

            var param = new DynamicParameters();
            param.Add("@productID", id);

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetVehicleDetailDto>(query, param);
            }
        }

        public async Task<List<ResultVehicleDto>> GetLast5VehicleAsync()
        {
            string query = "SELECT TOP 5 * FROM Product ORDER BY productID DESC";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultVehicleDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultVehicleAdvertListWithCategoryDto>> VehicleAdvertsListByEmployeeAsync(int id)
        {
            string query = @"SELECT p.ProductID, p.Title, p.Price, p.City, p.District, p.CoverImage, ISNULL(c.CategoryName, 'Kategorisiz') AS CategoryName 
                            FROM Product p 
                            LEFT JOIN Category c ON p.productCategory = c.CategoryID 
                            WHERE p.AppUserID = @appUserID";

            var param = new DynamicParameters();
            param.Add("@appUserID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultVehicleAdvertListWithCategoryDto>(query, param);
                return values.ToList();
            }
        }

        public async Task<List<ResultVehicleDto>> GetFilteredVehiclesAsync(FilterVehicleDto filter)
        {
            string query = "SELECT * FROM Product WHERE 1=1";
            var param = new DynamicParameters();

            if (filter != null)
            {
                if (filter.BrandID.HasValue && filter.BrandID > 0)
                {
                    query += " AND productCategory = @BrandID";
                    param.Add("@BrandID", filter.BrandID);
                }
                if (!string.IsNullOrEmpty(filter.fuelType))
                {
                    query += " AND FuelType = @FuelType";
                    param.Add("@FuelType", filter.fuelType);
                }
                if (!string.IsNullOrEmpty(filter.Transmission))
                {
                    query += " AND Transmission = @Transmission";
                    param.Add("@Transmission", filter.Transmission);
                }
                if (filter.MinPrice.HasValue && filter.MinPrice > 0)
                {
                    query += " AND price >= @MinPrice";
                    param.Add("@MinPrice", filter.MinPrice);
                }
                if (filter.MaxPrice.HasValue && filter.MaxPrice > 0)
                {
                    query += " AND price <= @MaxPrice";
                    param.Add("@MaxPrice", filter.MaxPrice);
                }
            }

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultVehicleDto>(query, param);
            return values.ToList();
        }
    }
}