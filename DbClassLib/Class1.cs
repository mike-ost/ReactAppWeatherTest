using ContractLib;

namespace DbClassLib
{
    public class WeatherForecastClass
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return Enumerable.Range(1, 700).Select(index =>
            {

                var tempC = Random.Shared.Next(-20, 55);
                var tempF = 32 + (int)(tempC / 0.5556);

                return new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = tempC,
                    TemperatureF = tempF,
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            });
        }

    }
}
