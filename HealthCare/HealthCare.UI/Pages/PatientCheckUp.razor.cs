using Blazored.Toast.Services;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HealthCare.UI.Pages
{
    public partial class PatientCheckUp
    {
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject]
        private IToastService _toastService { get; set; }
        [Inject]
        private ILogger<IndexModel> _logger { get; set; }

        [Inject] IDoctorService DoctorService { get; set; }
        [Parameter]
        public string DoctorId { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public string SearchText { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Doctor = (await DoctorService.GetDoctorByDoctorId(int.Parse(DoctorId)));
            }
            catch
            (Exception ex)
            { }
        }
    }
}
