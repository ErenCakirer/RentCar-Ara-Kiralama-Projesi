namespace RenteCar_Dapper.Dtos.VehicleDtos
{
    public class GetVehicleDetailDto
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CoverImage { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int ProductDetailID { get; set; }
        public int Kilometer { get; set; }
        public int SeatCount { get; set; }
        public int GearCount { get; set; }
        public string EngineSize { get; set; }
        public int ModelYear { get; set; }
        public string VideoUrl { get; set; }
    }
}
