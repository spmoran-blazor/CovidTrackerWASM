using CovidTrackerWASM.Shared.Common;
using CovidTrackerWASM.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidTrackerWASM.Server.Services
{
    public class CovidService
    {
        private System.Net.Http.HttpClient _http;
        private IConfiguration _configuration;

        public CovidService(System.Net.Http.HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        public async Task<AllData> GetAll()
        {
            string foo = _configuration["BaseAddress"] + Constants.ALL;
            return await _http.GetJsonAsync<AllData>(_configuration["BaseAddress"] + Constants.ALL);
        }

        public async Task<List<CountryData>> GetAllCountries()
        {
            string foo = _configuration["BaseAddress"] + Constants.ALL_COUNTRIES;
            return await _http.GetJsonAsync<List<CountryData>>(_configuration["BaseAddress"] + Constants.ALL_COUNTRIES);
        }
    }
}