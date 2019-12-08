using API.PrevisaoDoTempo.Infra.External.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.PrevisaoDoTempo.WebAPI.DTOs
{
    public class ForecastFormatedDTO
    {
        public List<ForecastListFormatedDTO> list { get; set; }

        public ForecastFormatedDTO()
        {
            this.list = new List<ForecastListFormatedDTO>();
        }

        public ForecastFormatedDTO(CityForecastDTO cityForecastDTO)
        {
            this.list = new List<ForecastListFormatedDTO>();

            var listCitiesByDate = cityForecastDTO.list.GroupBy(x => x.dt_txt.Split(' ').FirstOrDefault());

            foreach (var item in listCitiesByDate)
            {
                string dt_txt = item.FirstOrDefault().dt_txt.Split(' ').FirstOrDefault();
                double temp_min = item.Min(x => x.main.temp_min);
                double temp_max = item.Max(x => x.main.temp_max);
                double wind_speed = item.Max(x => x.wind.speed);
                double temp = 0;
                string weather_icon = "";

                if (Convert.ToDateTime(item.FirstOrDefault().dt_txt.Split(' ').FirstOrDefault()).Equals(DateTime.Today.Date))
                {
                    temp = item.FirstOrDefault().main.temp;
                    weather_icon = item.FirstOrDefault().weather.FirstOrDefault().icon;
                }
                else
                {
                    temp = temp_max;
                    weather_icon = item.OrderByDescending(x => x.main.temp_max).FirstOrDefault().weather.FirstOrDefault().icon;
                }

                this.list.Add(new ForecastListFormatedDTO()
                {
                    dt_txt = dt_txt,
                    temp = temp,
                    temp_min = temp_min,
                    temp_max = temp_max,
                    wind_speed = wind_speed,
                    weather_icon = weather_icon
                });
            }
        }
    }

    public class ForecastListFormatedDTO
    {
        public string dt_txt { get; set; }

        public double temp { get; set; }

        public double temp_min { get; set; }

        public double temp_max { get; set; }

        public double wind_speed { get; set; }

        public string weather_icon { get; set; }
    }
}
