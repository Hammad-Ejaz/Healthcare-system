using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HealthCare.UI.Shared
{
    public partial class NavMenu
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        protected bool IsClick { get; set; } = false;
        [Parameter]
        public bool Login { get; set; } = false;
       
        public bool Visible {  get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            Authenticate.OnLoginChanged += LoginChanged;
        }

        protected void LoadViewTaskByEmployeePopup()
        {
            IsClick = true;
        }

        protected async void LoginChanged()
        {
            await InvokeAsync(() => {
                StateHasChanged();
            });
        }

        protected async Task Visiblity()
        {
            Visible = !Visible;
//            await JSRuntime.InvokeVoidAsync("history.back");
        }
    }
}
