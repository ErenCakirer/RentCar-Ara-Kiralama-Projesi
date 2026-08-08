namespace RentCar_UI.Dtos.VehicleDtos
{
    public class CreateVehicleDto
    {
        public int CategoryID { get; set; }
        public int AppUserID { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }         
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string ImageUrl { get; set; }       
        public string Description { get; set; }    
        public int ProductCategory { get; set; }
    }
}