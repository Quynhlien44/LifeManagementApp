﻿using System.Text.Json.Serialization;

namespace LifeManagementApp.MVVM.Models.ApiModels
{
    internal class WeatherApiResponse
    {
        [JsonPropertyName("request")]
        public WeatherApiResponseRequest Request { get; set; }

        [JsonPropertyName("location")]
        public WeatherApiResponseLocation Location { get; set; }

        [JsonPropertyName("current")]
        public WeatherApiResponseCurrent Current { get; set; }
    }
}

public class WeatherApiResponseRequest
{
    public string type { get; set; }
    public string query { get; set; }
    public string language { get; set; }
    public string unit { get; set; }
}

public class WeatherApiResponseLocation
{
    public string name { get; set; }
    public string country { get; set; }
    public string region { get; set; }
    public string lat { get; set; }
    public string lon { get; set; }
    public string timezone_id { get; set; }
    public string localtime { get; set; }
    public int localtime_epoch { get; set; }
    public string utc_offset { get; set; }
}

public class WeatherApiResponseCurrent
{
    public string observation_time { get; set; }
    public int temperature { get; set; }
    public int weather_code { get; set; }
    public string[] weather_icons { get; set; }
    public string[] weather_descriptions { get; set; }
    public int wind_speed { get; set; }
    public int wind_degree { get; set; }
    public string wind_dir { get; set; }
    public int pressure { get; set; }
    public double precip { get; set; }
    public int humidity { get; set; }
    public int cloudcover { get; set; }
    public int feelslike { get; set; }
    public int uv_index { get; set; }
    public int visibility { get; set; }
    public string is_day { get; set; }
}

