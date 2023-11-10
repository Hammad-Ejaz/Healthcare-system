using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HealthCare.UI.Pages
{
    public partial class DoctorSelection
    {
		[Inject]
		protected NavigationManager _navigationManager { get; set; }
		[Inject]
		private IToastService _toastService { get; set; }
		[Inject]
		private ILogger<IndexModel> _logger { get; set; }
		[Inject] IDoctorService DoctorService { get; set; }

		[Parameter]
		public string SearchText { get; set; }
		public List<DoctorViewModel> Doctors { get; set; }
		
		protected override async Task OnInitializedAsync()
		{
			Doctors = await DoctorService.GetDoctorBySearchText(SearchText);
		}
        private async Task DoctorSearch()
        {
			// You can customize the URL based on your requirements
		 	await OnInitializedAsync();
        }
    }
}

