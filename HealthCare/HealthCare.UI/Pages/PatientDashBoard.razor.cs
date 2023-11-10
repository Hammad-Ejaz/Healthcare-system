using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.Service.Service;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HealthCare.UI.Pages
{
    public partial class PatientDashBoard
    {
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject]
        private IToastService _toastService { get; set; }
        [Inject]
        private ILogger<IndexModel> _logger { get; set; }

        [Inject] IDoctorService DoctorService { get; set; }

        public List<DoctorViewModel> Doctors { get; set; }
        public string SearchText { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Doctors = (await DoctorService.GetAllDoctors()).OrderBy(x=> x.WorkExperience).ToList();
            }
            catch
            (Exception ex)
            { }
        }
		private void NavigateToDoctorSelection()
		{
			// You can customize the URL based on your requirements
			_navigationManager.NavigateTo("/doctorSelection/"+SearchText);
		}
	}
}
