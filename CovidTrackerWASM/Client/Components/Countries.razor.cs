using CovidTrackerWASM.Shared.Common;
using CovidTrackerWASM.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidTrackerWASM.Client.Components
{
    public class CountriesModel : OwningComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IConfiguration Configuration { get; set; }

        protected List<CountryData> _countryData;
        protected List<string> _countryDropdownData = new List<string>();
        protected CountryData _currentItem;
        protected string _selectedListValue;
        protected string _baseAddress;
        protected string _convertedDate;
        protected string _currentFlag;

        protected override async Task OnInitializedAsync()
        {
            _baseAddress = Configuration["BaseAddress"];
            _countryData = await Http.GetJsonAsync<List<CountryData>>(_baseAddress + Constants.ALL_COUNTRIES);

            if (_countryData.Count > 0)
            {
                foreach (var i in _countryData)
                {
                    _countryDropdownData.Add(i.Country);
                }
            }

            _selectedListValue = _countryDropdownData.FirstOrDefault();
            SetCurrentItem();
            SetCountryFlag();

            StateHasChanged();
        }

        protected void SelectedValueChanged(ChangeEventArgs selectEvent)
        {
            _selectedListValue = selectEvent.Value.ToString();
            SetCurrentItem();
            SetCountryFlag();
            StateHasChanged();
        }

        protected void SetCurrentItem()
        {
            _currentItem = _countryData.FirstOrDefault(x => x.Country == _selectedListValue);
            _convertedDate = _convertedDate = Helper.TransformEpochDate(_currentItem.Updated);
        }

        protected void SetCountryFlag()
        {
            _currentFlag = _currentItem.CountryInfo.Flag;
        }
    }
}