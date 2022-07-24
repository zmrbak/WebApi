using Microsoft.AspNetCore.Mvc;

namespace WebApi003.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private static List<WeatherForecast> weatherForecasts;

        static WeatherForecastController()
        {
            if (weatherForecasts == null)
            {
                weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
            }
        }

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            
        }

        /// <summary>
        /// ��ȡ��������Ԥ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> GetAllWeatherForecast()
        {
            return weatherForecasts;
        }

        /// <summary>
        /// ��ȡĳһ������Ԥ��
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpGet("{index}")]
        public WeatherForecast GetWeatherForecast(int index)
        {
            return weatherForecasts.ElementAt(index);
        }

        /// <summary>
        /// ���һ������Ԥ��
        /// </summary>
        /// <param name="weatherForecast"></param>
        /// <returns></returns>
        [HttpPost]
        public WeatherForecast PostWeatherForecast(WeatherForecast weatherForecast)
        {
            weatherForecasts.Add(weatherForecast);
            return weatherForecast;
        }

        /// <summary>
        /// �޸�ĳһ������
        /// </summary>
        /// <param name="index"></param>
        /// <param name="weatherForecast"></param>
        /// <returns></returns>
        [HttpPut("{index}")]
        public WeatherForecast PutWeatherForecast(int index, WeatherForecast weatherForecast)
        {
             weatherForecasts[index]= weatherForecast;
            return weatherForecast;
        }

        [HttpPatch]
        public WeatherForecast PatchWeatherForecast(int index)
        {
            return weatherForecasts.ElementAt(index);
        }

        //[HttpOptions]
        //public void OptionsWeatherForecast()
        //{
        //    return;
        //}

        [HttpHead]
        public void HeadWeatherForecast()
        {
            return;
        }


        /// <summary>
        /// ɾ��ĳ������
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpDelete("{index}")]
        public WeatherForecast DeleteWeatherForecast(int index)
        {
            var result= weatherForecasts.ElementAt(index);
            weatherForecasts.RemoveAt(index);
            return result;
        }

    }
}