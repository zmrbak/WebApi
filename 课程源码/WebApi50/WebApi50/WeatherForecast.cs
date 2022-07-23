using Microsoft.AspNetCore.DataProtection;

namespace WebApi50
{
    public class WeatherForecast
    {
        private IDataProtector protector;

        public WeatherForecast(IDataProtector protector)
        {
            this.protector = protector;
        }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public string? SummaryProtect => protector.Protect(Summary!);
        public string? SummaryUnProtect=> protector.Unprotect(SummaryProtect!);
    }
}