using Microsoft.AspNetCore.Components;
using CovidTrackerWASM.Shared.Common;
using System.Threading.Tasks;
using static CovidTrackerWASM.Shared.Common.Enums;
using Microsoft.AspNetCore.Components.Web;

namespace CovidTrackerWASM.Client.Pages
{
    public class IndexModel : OwningComponentBase
    {
        protected Enums.ComponentType _currentComponent;
        protected string _class;
        protected Blazorise.Button _button0;
        protected Blazorise.Button _button1;
        protected Blazorise.Button _button2;
        protected int _isActive;

        protected override void OnInitialized()
        {
            _currentComponent = Enums.ComponentType.All;
            _isActive = (int)_currentComponent;
        }

        protected void SetComponent(int type)
        {
            _currentComponent = (Enums.ComponentType)type;

            if (_currentComponent == ComponentType.All)
            {
                _isActive = (int)ComponentType.All;
            }
            else if (_currentComponent == ComponentType.Countries)
            {
                _isActive = (int)ComponentType.Countries;
            }
            else if (_currentComponent == ComponentType.States)
            {
                _isActive = (int)ComponentType.States;
            }
            StateHasChanged();
        }
    }
}
