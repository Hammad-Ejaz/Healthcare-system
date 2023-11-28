using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

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
        public int col_1 { get; set; } = 0;
        public int col_2 { get; set; } = 0;
        public int col_3 { get; set; } = 0;
        public int col_4 { get; set; } = 0;
		

		protected override async Task OnInitializedAsync()
		{
			Doctors = await DoctorService.GetDoctorBySearchText(SearchText);
			AssignColumnsValues(Doctors.Count());

        }
		public void AssignColumnsValues(int count)
		{
            if (count < 0)
            {
                throw new ArgumentException("Input value must be non-negative.");
            }
            if (count == 1)
            {
                col_1 = 1;
            }
            else if (count == 2)
            {
                col_1 = 1;
                col_2 = 1;
            }
            else if (count == 3)
            {
                col_1 = 1;
                col_2 = 1;
                col_3 = 1;
            }
            else
            {
                col_1 = (int)Math.Ceiling(count * 0.25);
                col_2 = (int)Math.Ceiling(count * 0.50);
                col_3 = (int)Math.Ceiling(count * 0.75);
                col_4 = count;
            }
        }
	    private async Task DoctorSearch()
        {
			// You can customize the URL based on your requirements
		 	await OnInitializedAsync();
        }
    }
}

