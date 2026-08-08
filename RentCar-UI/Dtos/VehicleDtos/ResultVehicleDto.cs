namespace RentCar_UI.Dtos.VehicleDtos
{
    public class ResultVehicleDto
    {
       
      
            public int productID { get; set; }
            public string title { get; set; }
            public decimal price { get; set; }
            public string city { get; set; }
            public string district { get; set; }
        public string CoverImage { get; set; }
            public int productCategory { get; set; }
        public int productDetailID { get; set; }
        public int kilometer { get; set; }
        public int seatCount { get; set; }
        public int gearCount { get; set; }
        public string engineSize { get; set; }
        public int modelYear { get; set; }
        public string location { get; set; }
        public string videoUrl { get; set; }
        public string fuelType { get; set; }
        public string transmission { get; set; }

    }
}
