using Blazored.Toast.Services;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HealthCare.UI.Pages
{
    public partial class PatientTotalCheckUps
    {
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject]
        private IToastService _toastService { get; set; }
        [Inject]
        private ILogger<IndexModel> _logger { get; set; }
        [Inject] IUserService UserService { get; set; }
        [Inject] IDoctorService DoctorService { get; set; }
        [Parameter]
        public string UserId { get; set; }
        public string SearchText { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public List<UserViewModel> User { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                User = await UserService.GetUserViewModelList();
            }
            catch
            (Exception ex)
            {

            }
        }
        private async Task DoctorSearch()
        {
            // You can customize the URL based on your requirements
            User = await UserService.GetUsersBySearchText(SearchText);
        }
    }
}
