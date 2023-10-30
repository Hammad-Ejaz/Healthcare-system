using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HealthCare.UI.Shared
{
    public partial class NavMenu
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        protected bool IsClick { get; set; } = false;

        protected void LoadViewTaskByEmployeePopup()
        {
            IsClick = true;
        }

        protected async Task GoBack()
        {
            await JSRuntime.InvokeVoidAsync("history.back");
        }
    }
}
