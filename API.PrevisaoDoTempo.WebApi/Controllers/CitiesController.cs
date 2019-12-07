using API.PrevisaoDoTempo.Application.Services;
using API.PrevisaoDoTempo.Infra.External.OpenWeatherAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using API.PrevisaoDoTempo.Domain.Models;
using API.PrevisaoDoTempo.Infra.External.DTOs;
using API.PrevisaoDoTempo.WebAPI.DTOs;

namespace API.PrevisaoDoTempo.WebAPI.Controllers
{
    // TODO

    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IExternalCityService _externalCityService;
        private readonly IMapper _autoMapper;

        public CitiesController(ICityService cityService, IExternalCityService externalCityService, IMapper autoMapper)
        {
            this._cityService = cityService;
            this._externalCityService = externalCityService;
            this._autoMapper = autoMapper;
        }

        // GET api/cities
        [HttpGet]
        public ActionResult<IEnumerable<CityDTO>> Get()
        {
            var retrievedCities = _autoMapper.Map<IEnumerable<CityDTO>>(this._cityService.GetAllCities());
            return Ok(retrievedCities);
        }

        // POST api/cities
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<CityDTO> Post(CityDTO newCity)
        {
            var mappedCityDomain = _autoMapper.Map<City>(newCity);
            var insertedCity = this._cityService.CreateCity(mappedCityDomain);

            return CreatedAtAction("Post", _autoMapper.Map<CityDTO>(insertedCity));
        }

        [HttpGet]
        [Route("forecast/{customCode}")]
        public ActionResult<CityForecastDTO> GetForecast(string customCode)
        {
            CityForecastDTO cityForecastDTO = this._externalCityService.GetCityForecast(customCode);
            return Ok(cityForecastDTO);
        }

        [HttpGet]
        [Route("search/{cityName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<CityDTO>> SearchCities(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName) || cityName.Length < 3)
                return BadRequest(new ArgumentException("O nome da cidade deve ter no mínimo 3 caracteres."));

            FoundCitiesDTO foundCities = this._externalCityService.GetCitiesByName(cityName);
            var convertedCities = foundCities.list
                .Select(foundCity => _autoMapper.Map<CityDTO>(foundCity))
                .ToList();
            return Ok(convertedCities);
        }

    }
}
