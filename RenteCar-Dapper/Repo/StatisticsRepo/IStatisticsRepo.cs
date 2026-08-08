namespace RenteCar_Dapper.Repo.StatisticsRepo
{
    public interface IStatisticsRepo
    {
      Task<int> CategoryCount();
      Task<int> ActiveCategoryCount();
      Task<int> PassiveCategoryCount();
      Task<string> GetTopVehicleBrand();
      Task<decimal> AveragePrice();
      Task<int> VehicleCount(); 
      Task<int> TestimonialCount();
      Task<string> GetLatestVehicle();
      Task<string> GetCheapestVehicleName();
      Task<string> GetMostExpensiveVehicleName();
      Task<int> GetIdOfCategoryWithMostVehicles();
      Task<string> GetCityWithMostVehicles();
      Task<int> GetVehicleCountAboveAveragePrice();
      Task<int> DifferentCityCount();
      Task<decimal> GetPriceGapBetweenMaxAndMin();
      Task<int> GetAverageVehicleCountPerCategory();
    }
}
