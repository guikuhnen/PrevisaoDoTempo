using API.PrevisaoDoTempo.Domain.Models;
using System.Collections.Generic;

namespace API.PevisaoDoTempo.Application.Services
{
    public interface ICityService
    {
        City CreateCity(City city);
        List<City> GetAllCities();
    }
}
