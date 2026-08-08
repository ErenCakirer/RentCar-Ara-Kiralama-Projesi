namespace RentCar_UI.Dtos.VehicleDtos
{
    public class UpdateVehicleDto
    {
        public int productID { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string CoverImage { get; set; }
        public int productCategory { get; set; }

    }
}
