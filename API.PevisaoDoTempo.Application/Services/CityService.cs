using API.PrevisaoDoTempo.Domain.Models;
using API.PrevisaoDoTempo.Infra.Data.Repository;
using API.PrevisaoDoTempo.Infra.External.OpenWeatherAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.PrevisaoDoTempo.Application.Services
{
    public class CityService : ICityService
    {
        public readonly ICityRepository _repository;
        public readonly IExternalCityService _externalCityService;
        
        public CityService(ICityRepository repository, IExternalCityService externalCityService)
        {
            this._repository = repository;
            this._externalCityService = externalCityService;
        }

        // Cria a cidade ser for válida
        public City CreateCity(City city)
        {
            #region Validações

            if (!this.CityExistsOnExternalApi(city))
                throw new ArgumentException("Não foi possível encontrar informações sobre o clima da cidade informada.");

            if (!this.CityIsUnique(city))
                throw new ArgumentException("A cidade informada já foi cadastrada.");

            #endregion

            return this._repository.Insert(city);
        }

        // Busca todas as cidades no BD
        public List<City> GetAllCities()
        {
            return this._repository.GetAll();
        }

        // Verifica se a cidade informada está disponível no serviço externo
        private bool CityExistsOnExternalApi(City city)
        {
            var citiesByName = _externalCityService.GetCitiesByName(city.Name);

            return citiesByName.count > 0 && citiesByName.list.Any(c => c.id.ToString() == city.CustomCode);
        }

        // Verifica se a cidade é única baseado no CustomCode
        private bool CityIsUnique(City city)
        {
            return _repository.Where(c => c.CustomCode.Equals(city.CustomCode)).Count() == 0;
        }
    }
}
