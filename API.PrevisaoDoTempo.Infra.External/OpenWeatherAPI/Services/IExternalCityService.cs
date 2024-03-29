﻿using API.PrevisaoDoTempo.Infra.External.DTOs;

namespace API.PrevisaoDoTempo.Infra.External.OpenWeatherAPI.Services
{
    public interface IExternalCityService
    {
        CityForecastDTO GetCityForecast(string customCode);
        FoundCitiesDTO GetCitiesByName(string name);
    }
}