using Microsoft.AspNetCore.SignalR;

namespace RenteCar_Dapper.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task SendCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();

            #region 3. CategoryCount
            var categoryCountResponse = await client.GetAsync("https://localhost:7007/api/Statistics/CategoryCount");
            if (categoryCountResponse.IsSuccessStatusCode)
            {
                var jsonData = await categoryCountResponse.Content.ReadAsStringAsync();
                await Clients.All.SendAsync("ReceiveCategoryCount", jsonData);
            }
            #endregion
        }
    }
}
