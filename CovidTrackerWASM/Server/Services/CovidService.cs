using CovidTrackerWASM.Shared.Common;
using CovidTrackerWASM.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CovidTrackerWASM.Server.Services
{
    public class CovidService
    {
        System.Net.Http.HttpClient _http;
        IConfiguration _configuration;

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
