using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace WebApi50.Controllers
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
        private readonly IDataProtectionProvider dataProtectionProvider;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IDataProtectionProvider dataProtectionProvider
            )
        {
            _logger = logger;
            this.dataProtectionProvider = dataProtectionProvider;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
           var protector= dataProtectionProvider.CreateProtector("123acb");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast(protector)
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}