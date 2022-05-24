using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApi44.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("/get1")]
        public string Get1()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(User.Identity!.Name);
            stringBuilder.AppendLine(User.Identity!.AuthenticationType);
            stringBuilder.AppendLine(User.Identity!.IsAuthenticated.ToString());
            stringBuilder.AppendLine(User.Identity!.ToString());

            var items = Request.HttpContext.AuthenticateAsync().Result;
            foreach (var item in items.Properties!.Items)
            {
                stringBuilder.AppendLine(item.Key + "," + item.Value);
            }

            return stringBuilder.ToString();

        }

    }
}