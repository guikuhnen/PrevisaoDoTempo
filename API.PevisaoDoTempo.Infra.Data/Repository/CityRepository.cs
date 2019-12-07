using API.PrevisaoDoTempo.Infra.Data.Context;
using API.PrevisaoDoTempo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace API.PrevisaoDoTempo.Infra.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        public readonly PrevisaoDoTempoContext _context;

        public CityRepository(PrevisaoDoTempoContext context)
        {
            this._context = context;
        }

        public City Insert(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();

            return city;
        }

        public IQueryable<City> Where(Expression<Func<City, bool>> condition)
        {
            return _context.Cities.Where(condition);
        }

        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }
    }
}
