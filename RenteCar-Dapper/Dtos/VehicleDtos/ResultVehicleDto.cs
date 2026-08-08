namespace RenteCar_Dapper.Dtos.VehicleDtos
{
    public class ResultVehicleDto
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CoverImage { get; set; }
        public int ProductCategory { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
    }
}
