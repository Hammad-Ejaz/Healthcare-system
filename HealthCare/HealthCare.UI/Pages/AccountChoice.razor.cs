using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace HealthCare.UI.Pages
{
    public partial class AccountChoice
    {
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject]
        private IToastService _toastService { get; set; }
       
    }
}
