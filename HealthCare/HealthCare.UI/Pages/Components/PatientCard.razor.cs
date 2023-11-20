using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Xrm.Sdk.Metadata;

namespace HealthCare.UI.Pages.Components
{
    public partial class PatientCard
    {
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject]
        private IToastService _toastService { get; set; }
        [Inject]
        private ILogger<IndexModel> _logger { get; set; }
        [Inject] IDoctorService DoctorService { get; set; }

        [Parameter]
        public UserViewModel User { get; set; }
        [Parameter]
        public bool IsCheckUpButtonShown { get; set; }
        protected override async Task OnInitializedAsync()
        {
        
        }
    }
}
