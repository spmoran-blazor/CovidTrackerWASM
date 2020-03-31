using CovidTrackerWASM.Server.Services;
using CovidTrackerWASM.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidTrackerWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private IConfiguration _configuration;
        private string _baseUrl;
        private CovidService _covidService;

        public CovidController(IConfiguration configuration, CovidService covidService)
        {
            _configuration = configuration;
            _baseUrl = _configuration["BaseAddress"];
            _covidService = covidService;
        }

        [Route("all")]
        [HttpGet]
        public async Task<AllData> AllData()
        {
            var foo = await _covidService.GetAll();
            return foo;
        }

        [Route("countries")]
        [HttpGet]
        public async Task<List<CountryData>> GetAllCountries()
        {
            var foo = await _covidService.GetAllCountries();
            return foo;
        }

        // GET api/<CovidController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CovidController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<CovidController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<CovidController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}