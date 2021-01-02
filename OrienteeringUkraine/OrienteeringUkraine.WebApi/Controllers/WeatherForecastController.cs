using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrienteeringUkraine.Data;
using OrienteeringUkraine.Domain.Entities;
using OrienteeringUkraine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringUkraine.WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly OrienteeringUkraineContext context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, OrienteeringUkraineContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet]
        [Route("user/{login}")]
        public UserModel Get(string login)
        {
            var user = context.Users.FirstOrDefault(u => u.Login == login);
            return new UserModel
            {
                FullName = user?.FullName,
                Login = user?.Login,
                BirthDate = user?.BirthDate,
                Club = user?.Club,
                Region = user?.Region,
                Role = user?.Role,
                Sex = user?.Sex?.ToString(),
            };
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
        [HttpGet]
        [Route("region/{id}")]
        public RegionModel GetRegion(int id)
        {
            var region = context.Regions.FirstOrDefault(r => r.Id == id);
            return new RegionModel
            {
                Id = region?.Id,
                Name = region?.Name,
                Users = region?.Users.Select(user => new UserModel
                {
                    FullName = user?.FullName,
                    Login = user?.Login,
                    BirthDate = user?.BirthDate,
                    Club = user?.Club,
                    Region = user?.Region,
                    Role = user?.Role,
                    Sex = user?.Sex?.ToString(),
                }),
            };
        }
    }

    public class RegionModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserModel> Users { get; set; }
    }
    public class UserModel
    {
        public string Login { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }

        public string Sex { get; set; }

        public string Role { get; set; }

        public string Region { get; set; }

        public string Club { get; set; }

    }
}
