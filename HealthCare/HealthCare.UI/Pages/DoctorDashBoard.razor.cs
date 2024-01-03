using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.UI.Shared;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;

namespace HealthCare.UI.Pages
{
    public partial class DoctorDashBoard
    {
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject] IUserService UserService { get; set; }
        [Inject] IAppointmentService AppointmentService { get; set; }
        [Inject] IDoctorService DoctorService {  get; set; }
        [Inject] ILogService LogService { get; set; }
        [Parameter]
        public string UserId { get; set; }
        public string SearchText { get; set; }
        public List<AppointmentViewModel> Appointments { get; set; }
      
        public HealthcareDoctor Doctor { get; set; }
        public List<UserViewModel> User { get; set; }
        public int col_1 { get; set; } = 0;
        public int col_2 { get; set; } = 0;
        public int col_3 { get; set; } = 0;
        public int col_4 { get; set; } = 0;


        protected override async Task OnInitializedAsync()
        {
            try
            {

                Doctor = await DoctorService.GetDoctorByUserId(Authenticate.User.Id);
                if(Doctor != null)
                {
                    Appointments = await AppointmentService.GetAppointmentViewModelListByDoctorIdAndDate(Doctor.Id, DateTime.Now);
                    User = await UserService.GetUserViewModelListOfTodaysAppointment(Appointments);
                    AssignColumnsValues(User.Count());
                }
            }
            catch
            (Exception ex)
            {
                await LogService.AddLog(
                    new HealthCareExceptionLog()
                    {
                        LogTimestamp = DateTime.Now,
                        ExceptionMessage = ex.Message,
                        UserId = Authenticate.User.Id,
                        AdditionalDetails = "=DoctorDashBoard.razor.cs",
                        CreatedAt = DateTime.Now,
                        Active = true
                    });
            }
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
            try
            {
               User = await UserService.GetUsersBySearchText(SearchText);
            }
            catch(Exception ex)
            {
                await LogService.AddLog(
                new HealthCareExceptionLog()
                {
                    LogTimestamp = DateTime.Now,
                    ExceptionMessage = ex.Message,
                    UserId = Authenticate.User.Id,
                    TableName = "HealthCareUser",
                    AdditionalDetails = "DoctorDashBoard.razor.cs",
                    CreatedAt = DateTime.Now,
                    Active = true
                });
            }

        }
    }
}
