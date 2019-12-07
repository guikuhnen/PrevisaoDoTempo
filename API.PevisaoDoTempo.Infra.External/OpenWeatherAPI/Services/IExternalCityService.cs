using API.PevisaoDoTempo.Infra.External.DTOs;

namespace API.PevisaoDoTempo.Infra.External.OpenWeatherAPI.Services
{
    public interface IExternalCityService
    {
        CityForecastDTO GetCityForecast(string customCode);
        FoundCitiesDTO GetCitiesByName(string name);
    }
}