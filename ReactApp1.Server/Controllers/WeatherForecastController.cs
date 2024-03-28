using ContractLib;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var a = HttpClientFactory.Create();
            a.DefaultRequestHeaders.Add("Accept", "application/json");
            var b = a.GetAsync("https://localhost:7049/weatherforecast").Result;

            //http://localhost:5002

            //var b = a.GetAsync("http://localhost:5002/weatherforecast").Result;

/*            "Kestrel": {
                "EndPoints": {
                    "Http": {
                        "Url": "http://localhost:5002"
                    }
                }
            }*/

            var c = b.Content.ReadAsStringAsync().Result;

            var res = JsonSerializer.Deserialize<WeatherForecast[]>(c);

            return res;
        }
    }
}
