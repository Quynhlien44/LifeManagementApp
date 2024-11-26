using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using LifeManagementApp.MVVM.Models.ApiModels;
using LifeManagementApp.MVVM.Services.Weather;

namespace LifeManagementApp.MVVM.ViewModels.Weather
{
    internal partial class WeatherInfoPageViewModel : ObservableObject
    {
        private readonly WeatherApiService _weatherApiService;

        public WeatherInfoPageViewModel()
        {
            _weatherApiService = new WeatherApiService();
        }

        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private string weatherIcon;

        [ObservableProperty]
        private string temperature;

        [ObservableProperty]
        private string weatherDescription;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private string humidity;

        [ObservableProperty]
        private string cloudCoverLevel;

        [ObservableProperty]
        private string isDay;

        [ObservableProperty]
        private string windSpeed;

        [ObservableProperty]
        private string windDegree;

        [ObservableProperty]
        private string windDirection;

        [ObservableProperty]
        private string alertMessage;

        [RelayCommand]
        private async Task FetchWeatherInformation()
        {
            var weatherApiResponse = await _weatherApiService.GetWeatherInformation(City);
            if (weatherApiResponse != null)
            {
                double windSpeedInMetersPerSecond = weatherApiResponse.Current.wind_speed * 1000 / 3600.0;

                WeatherIcon = weatherApiResponse.Current.weather_icons[0];
                Temperature = $"{weatherApiResponse.Current.temperature}℃";
                Location = $"{weatherApiResponse.Location.name}, {weatherApiResponse.Location.region}, {weatherApiResponse.Location.country}";
                WeatherDescription = weatherApiResponse.Current.weather_descriptions[0];
                Humidity = $"{weatherApiResponse.Current.humidity}%";
                CloudCoverLevel = $"{weatherApiResponse.Current.cloudcover}%";
                IsDay = weatherApiResponse.Current.is_day == "yes" ? "Day" : "Night";
                WindSpeed = $"{windSpeedInMetersPerSecond} m/s";
                WindDegree = $"{weatherApiResponse.Current.wind_degree}°";
                WindDirection = weatherApiResponse.Current.wind_dir;

                // Save data to Preferences
                Preferences.Set("UserCity", City);
                Preferences.Set("CurrentTemperature", Temperature);
                Preferences.Set("WeatherDescription", WeatherDescription);

                // Check wind speed and set alert
                if (windSpeedInMetersPerSecond > 4)
                {
                    AlertMessage = $"⚠️ Wind speed exceeds 4 m/s! Current speed: {windSpeedInMetersPerSecond:F2} m/s.";
                    Preferences.Set("WindWarningMessage", AlertMessage);
                }
                else
                {
                    AlertMessage = string.Empty; // No alert
                    Preferences.Set("WindWarningMessage", string.Empty); // Clear warning
                }
            }
        }
    }
}
