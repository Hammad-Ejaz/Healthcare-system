using HealthCare.Service.IService;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.JSInterop;

namespace HealthCare.UI.Shared
{
    public partial class NavMenu
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject]
        protected IDoctorService Doctors { get; set; }
        protected bool IsClick { get; set; } = false;
        [Parameter]
        public bool Login { get; set; } = false;
       
        public bool Visible {  get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            Authenticate.OnLoginChanged += LoginChanged;
        }
        public void NavigateToProfile()
        {
            _navigationManager.NavigateTo("/userProfile");
        }

        public void Logout()
        {
            Authenticate.User = null;
            Authenticate.IsLogin = false;
            Visible = !Visible;
            _navigationManager.NavigateTo("/");
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
        }
        protected async Task Home()
        {
            if (Authenticate.User.UserTypeId == (int)HealthCare.ViewModels.Enum.UserType.PATIENT)
            {

                _navigationManager.NavigateTo("/patientDashboard");
            }
            else
            {
                var doctor =await Doctors.GetDoctorByUserId(Authenticate.User.Id);
                _navigationManager.NavigateTo("/doctorDashboard/" + doctor?.Id);
            }

        }

        protected async Task Appointments()
        {
            if (Authenticate.User.UserTypeId == (int)HealthCare.ViewModels.Enum.UserType.PATIENT)
            {

                _navigationManager.NavigateTo("/patientTotalCheckUps");
            }
            else
            {
                _navigationManager.NavigateTo("/approvedAppointment");
            }

        }
    }
}
