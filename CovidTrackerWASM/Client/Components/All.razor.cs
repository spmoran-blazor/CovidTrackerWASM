﻿using CovidTrackerWASM.Shared.Common;
using CovidTrackerWASM.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidTrackerWASM.Client.Components
{
    public class AllModel : OwningComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IConfiguration Configuration { get; set; }

        protected AllData allData;
        protected string _baseAddress;
        protected string _convertedDate;

        protected override async Task OnInitializedAsync()
        {
            _baseAddress = Configuration["BaseAddress"];
            //allData = await Http.GetJsonAsync<AllData>(_baseAddress + Constants.ALL);
            allData = await Http.GetJsonAsync<AllData>(Constants.BASE_ADDRESS + Constants.ALL);
            _convertedDate = Helper.TransformEpochDate(allData.Updated);
            StateHasChanged();
        }
    }
}