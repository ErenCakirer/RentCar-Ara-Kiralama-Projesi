namespace RentCar_UI.Dtos.VehicleDtos
{
    public class GetVehicleDetailDto
    {
        public int productID { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string coverImage { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string description { get; set; }

        public string FuelType { get; set; }
        public string Transmission { get; set; }

        public int productDetailID { get; set; }
        public int kilometer { get; set; }
        public int seatCount { get; set; }
        public int gearCount { get; set; }
        public string engineSize { get; set; }
        public int modelYear { get; set; }
        public string videoUrl { get; set; }
    }
}