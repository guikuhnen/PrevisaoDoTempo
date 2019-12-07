using API.PrevisaoDoTempo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace API.PrevisaoDoTempo.Infra.Data.Repository
{
    public interface ICityRepository
    {
        City Insert(City city);
        IQueryable<City> Where(Expression<Func<City, bool>> condition);
        List<City> GetAll();
    }
}
