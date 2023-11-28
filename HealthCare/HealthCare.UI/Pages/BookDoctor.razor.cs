using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.Service.Service;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;
using Org.BouncyCastle.Crypto;
using Syncfusion.Blazor.Grids;

namespace HealthCare.UI.Pages
{
    public partial class BookDoctor
    {
        [Inject] protected NavigationManager _navigationManager { get; set; }
        [Inject] private IToastService _toastService { get; set; }
        [Inject] private ILogger<IndexModel> _logger { get; set; }
        [Inject] IUserService UserService { get; set; }
        [Inject] IDoctorService DoctorService { get; set; }
        [Inject] IDoctorAvailibilityScheduleService DoctorAvailibilityService { get; set; }
        [Inject] IAppointmentService AppointmentService { get; set; }
        
        [Parameter]
        public string DoctorId { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DayOfWeek[] DaysOfWeek {get;set;}
        public List<HealthcareDoctorAvailibilitySchedule> DoctorAvailibility { get; set; }
      

        public DoctorViewModel Doctor { get; set; }
        public UserViewModel User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                DoctorAvailibility = await DoctorAvailibilityService.GetDoctorAvailibityByDoctorId(1);
                DaysOfWeek = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToArray();
                User = await UserService.GetUserViewModelById(1);
                Doctor = (await DoctorService.GetDoctorByDoctorId(int.Parse(DoctorId)));
                
            }
            catch
            (Exception ex)
            { }
        }

        protected async Task BookAppointment()
        {
            var scheduleId = await DoctorAvailibilityService.GetScheduleIdByDoctorIdAndDate(int.Parse(DoctorId), AppointmentDate);
            if (scheduleId != 0)
            {
                if ((await AppointmentService.IsAppointmentAlreadyExsits(int.Parse(DoctorId), 1, scheduleId)))
                {
                    _toastService.ShowSuccess("Appointment request already submitted try another day or time", "Request Already Submitted");
                }
                else
                {
                    await AddAppointment(scheduleId);
                }
                Description = null;
                _toastService.ShowSuccess("Appointment request submitted successfully", "Request Submitted");
            }
            else
            {
                _toastService.ShowError("Doctor is not available on that day", "Invalid Day");
            }
        }
        public async Task AddAppointment(int scheduleId)
        {
            await AppointmentService.AddAppointment(new HealthcareAppointment()
            {
                PatientId = (await UserService.GetUserById(1)).Id,
                DoctorId = int.Parse(DoctorId),
                ScheduleId = scheduleId,
                Description = Description,
                Images = null,
                AppointmentDate = AppointmentDate
            });

        }
    }


}
