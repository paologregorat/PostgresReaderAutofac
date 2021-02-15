using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPIPostgresReader.Abstract;

namespace WebAPIPostgresReader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IReader _reader;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IReader reader, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _reader = reader;
        }

        [HttpGet]
        public async Task<bool> Get()
        {
            var sql = $@"SELECT  ""Name""  FROM ""Table1"" ";
            var res = await _reader.GetCollectionAsync<string>(sql);
            var resList = res.ToList();
            return true;
        }
    }
}
