using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.Service.Service;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HealthCare.UI.Pages
{
	public class IndexModel : ComponentBase
	{

		[Inject]
		protected NavigationManager _navigationManager { get; set; }
		[Inject]
		private IToastService _toastService { get; set; }
		[Inject]
		private ILogger<IndexModel> _logger { get; set; }

		public int OneTimeTaskCount { get; set; } = 0;
		public int RecTaskCount { get; set; } = 0;
		public int MetricsCount { get; set; } = 0;
		public List<ExceptionLog> employees = new List<ExceptionLog>();

        protected override async Task OnInitializedAsync()
        {
			
        }

        protected void NavigateHomePage()
		{
			_navigationManager.NavigateTo($"/Login1/");
		}
	}
}