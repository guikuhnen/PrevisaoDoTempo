using API.PrevisaoDoTempo.Infra.External.DTOs;
using API.PrevisaoDoTempo.Infra.External.OpenWeatherAPI.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace API.PrevisaoDoTempo.Infra.External.OpenWeatherAPI.Services
{
    public class ExternalCityService : BaseService, IExternalCityService
    {
        public ExternalCityService(IOptions<OpenWeatherApiConfiguration> customConfiguration)
        {
            base.Configuration = customConfiguration.Value;
        }

        // Busca informação do clima dos próximos 5 dias da cidade pelo CustomCode informado
        public CityForecastDTO GetCityForecast(string customCode)
        {
            string requestUrl = base.Configuration.BaseUrl + $"forecast?id={customCode}&apiKey={base.Configuration.ApiKey}";
            string jsonResult = this.ExecuteRequest(requestUrl);

            return JsonConvert.DeserializeObject<CityForecastDTO>(jsonResult);
        }

        // Procura cidades pelo Nome informado
        public FoundCitiesDTO GetCitiesByName(string name)
        {
            string requestUrl = base.Configuration.BaseUrl + $"find?q={name}&apiKey={base.Configuration.ApiKey}";
            string jsonResult = this.ExecuteRequest(requestUrl);

            return JsonConvert.DeserializeObject<FoundCitiesDTO>(jsonResult);
        }

        // Realiza o request GET para a OpenWeatherApi e retorna o JSON
        private string ExecuteRequest(string requestUrl)
        {
            try
            {
                HttpResponseMessage response = Client.GetAsync(requestUrl).Result;
                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException e)
            {
                throw new ArgumentException("Não foi possível processar a requisição. Verifique os dados informados e tente novamente.", e);
            }
        }
    }
}
