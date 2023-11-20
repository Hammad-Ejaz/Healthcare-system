using Blazored.Toast.Services;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HealthCare.UI.Pages.Components
{
	public partial class DoctorCards
	{
		[Inject]
		protected NavigationManager _navigationManager { get; set; }
		[Inject]
		private IToastService _toastService { get; set; }
		[Inject]
		private ILogger<IndexModel> _logger { get; set; }
		[Inject] IDoctorService DoctorService { get; set; }

		[Parameter]
		public DoctorViewModel Doctor { get; set; }
		[Parameter]
		public bool IsBookNowButtonShown { get; set; }
		
		protected override async Task OnInitializedAsync()
		{
			
		}
	}
}
