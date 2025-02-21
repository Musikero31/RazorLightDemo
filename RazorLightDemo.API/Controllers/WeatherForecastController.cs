using Microsoft.AspNetCore.Mvc;
using RazorLightDemo.HtmlPDF;
using RazorLightDemo.Lib;
using RazorLightDemo.Lib.Models;

namespace RazorLightDemo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ITemplateParser _parser;
        private readonly IGeneratePDF _pdf;

        public WeatherForecastController(ITemplateParser parser, IGeneratePDF pdf)
        {
            _parser = parser;
            _pdf = pdf;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            EmailAlertsModel model = new EmailAlertsModel
            {
                PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/8/87/Smiley_Face.JPG",
                Body = "This is a good body"
            };

            string result = await _parser.ParseTemplateAsync(model);

            _pdf.GeneratePDFFile(result);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                HTMLString = result
            })
            .ToArray();
        }
    }
}
