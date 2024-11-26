using LifeManagementApp.MVVM.Models.ApiModels;
using System.Net.Http.Json;
using System.Text.Json;

namespace LifeManagementApp.MVVM.Services.Weather
{
    internal class WeatherApiService
    {
        private readonly HttpClient _httpClient;

        public WeatherApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.BASE_URL);
        }

        public async Task<WeatherApiResponse?> GetWeatherInformation(string city)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            try
            {
                var response = await _httpClient.GetFromJsonAsync<WeatherApiResponse>($"current?access_key={Constants.API_KEY}&query={city}");
                return response;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                throw;
            }
        }
    }
}
