using Blazored.Toast.Services;
using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using System;

namespace HealthCare.UI.Pages
{
    public partial class ApprovedApointment
    {

        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject]
        private IToastService _toastService { get; set; }
        [Inject]
        private ILogger<IndexModel> _logger { get; set; }
        [Inject] IEmployeeService s { get; set; }
        [Inject] IUserService UserService { get; set; }
        [Inject] IDoctorService DoctorService { get; set; }
        [Inject] IAppointmentService AppointmentService { get; set; }
        [Parameter]
        public string DoctorId { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public UserViewModel User { get; set; }
        protected List<PrescriptionViewModel> Prescription { get; set; }
        public string SearchText { get; set; }


        protected List<AppointmentViewModel> Appointment { get; set; }
        protected SfGrid<AppointmentViewModel> AppointmentGrid { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Appointment = await AppointmentService.GetUnApprovedAppointmentViewModelListByDoctorId(2);
                User = await UserService.GetUserViewModelById(1);
                Doctor = (await DoctorService.GetDoctorByDoctorId(int.Parse(DoctorId)));
            }
            catch
            (Exception ex)
            {
                
            }
        }
        protected async Task ExcelExport()
        {
            ExcelExportProperties excelProperties = new ExcelExportProperties
            {
                FileName = "AppointmentsGrid-" + DateTime.Now.ToString("MM-dd-yyyy") + ".xlsx",
                IncludeTemplateColumn = true
            };
            await AppointmentGrid.ExportToExcelAsync(excelProperties);
        }
        protected async Task OnSearch(Syncfusion.Blazor.Inputs.ChangedEventArgs args)
        {
            await AppointmentGrid.SearchAsync(args.Value);
        }

        protected async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id == "AppointmentsGrid_excelexport")
            {
                ExcelExportProperties excelProperties = new ExcelExportProperties
                {
                    FileName = "Appointments-" + DateTime.Now.ToString("MM-dd-yyyy") + ".xlsx"
                };
                await AppointmentGrid.ExportToExcelAsync(excelProperties);
            }
        }
        private async Task Approved(int Id)
        {
            var appointment = await AppointmentService.GetAppointmentById(Id);
            appointment.IsApproved = true;
            await AppointmentService.UpdateAppointment(appointment);
            Appointment = await AppointmentService.GetUnApprovedAppointmentViewModelListByDoctorId(2);
        }
    }
}
