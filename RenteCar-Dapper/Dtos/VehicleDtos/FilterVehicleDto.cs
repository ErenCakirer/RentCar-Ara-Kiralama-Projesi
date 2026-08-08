namespace RenteCar_Dapper.Dtos.VehicleDtos
{
    public class FilterVehicleDto
    {
        public int? BrandID { get; set; }
        public string? fuelType { get; set; }
        public string? Transmission { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
