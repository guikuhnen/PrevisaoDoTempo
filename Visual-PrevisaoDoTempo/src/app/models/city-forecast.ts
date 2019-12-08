export interface CityForecast {
    list: Forecast[];
}

export interface Forecast {
    dt_txt: string;
    temp: number;
    temp_min: number;
    temp_max: number;
    wind_speed: number;
    weather_icon: string;
}