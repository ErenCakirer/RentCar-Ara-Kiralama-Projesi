namespace RentCar_UI.Dtos.ServicesDtos
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
