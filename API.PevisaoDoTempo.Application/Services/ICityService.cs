using API.PrevisaoDoTempo.Domain.Models;
using System.Collections.Generic;

namespace API.PrevisaoDoTempo.Application.Services
{
    public interface ICityService
    {
        City CreateCity(City city);
        List<City> GetAllCities();
    }
}
