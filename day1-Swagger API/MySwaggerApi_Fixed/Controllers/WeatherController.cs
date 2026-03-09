using Microsoft.AspNetCore.Mvc;

namespace MySwaggerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new { Id = 1, Forecast = "Sunny", Temperature = 32 },
            new { Id = 2, Forecast = "Cloudy", Temperature = 28 },
            new { Id = 3, Forecast = "Rainy", Temperature = 24 }
        });
    }

    [HttpGet("g1")]
    public IActionResult Get1()
    {
        return Ok(new[]
            {
            new {Id = 4, Forecast = "Rainy",Temperature = 13},
            new { Id = 5, Forecast = "Cloudy", Temperature = 28 },
            new { Id = 6, Forecast = "Hazy", Temperature = 34 }
        });
    }
}