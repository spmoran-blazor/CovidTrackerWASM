using CovidTrackerWASM.Server.Services;
using CovidTrackerWASM.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [Route("states")]
        [HttpGet]
        public async Task<List<StateData>> GetAllStates()
        {
            var foo = await _covidService.GetAllStates();
            return foo;
        }
    }
}