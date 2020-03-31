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
    public class StatesModel : OwningComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IConfiguration Configuration { get; set; }

        protected List<StateData> _stateData;
        protected List<string> _stateDropdownData = new List<string>();
        protected StateData _currentItem;
        protected string _selectedListValue;
        protected string _baseAddress;

        protected override async Task OnInitializedAsync()
        {
            _baseAddress = Configuration["BaseAddress"];
            _stateData = await Http.GetJsonAsync<List<StateData>>(_baseAddress + Constants.ALL_STATES);

            if (_stateData.Count > 0)
            {
                foreach (var i in _stateData)
                {
                    _stateDropdownData.Add(i.State);
                }
            }

            _selectedListValue = _stateDropdownData.FirstOrDefault();
            SetCurrentItem();
            StateHasChanged();
        }

        protected void SelectedValueChanged(ChangeEventArgs selectEvent)
        {
            _selectedListValue = selectEvent.Value.ToString();
            SetCurrentItem();
            StateHasChanged();
        }

        protected void SetCurrentItem()
        {
            _currentItem = _stateData.FirstOrDefault(x => x.State == _selectedListValue);
        }
    }
}