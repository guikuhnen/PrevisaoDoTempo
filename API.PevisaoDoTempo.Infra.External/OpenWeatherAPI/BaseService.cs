using API.PrevisaoDoTempo.Infra.External.OpenWeatherAPI.Configuration;
using System.Net.Http;

namespace API.PrevisaoDoTempo.Infra.External.OpenWeatherAPI
{
    public abstract class BaseService
    {
        protected static readonly HttpClient Client = new HttpClient();
        protected virtual OpenWeatherApiConfiguration Configuration { get; set; }
    }
}
