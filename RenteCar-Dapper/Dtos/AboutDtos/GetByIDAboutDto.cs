namespace RenteCar_Dapper.Dtos.AboutDtos
{
    public class GetByIDAboutDto
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
