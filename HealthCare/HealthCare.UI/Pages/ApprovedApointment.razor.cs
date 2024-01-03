using Blazored.Toast.Services;
using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Service.IService;
using HealthCare.UI.Shared;
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
        [Inject] IDoctorService DoctorService { get; set; }
        [Inject] IAppointmentService AppointmentService { get; set; }
        [Inject] IAuditsService AuditsService { get; set; }
        public int DoctorId { get; set; }
        public DoctorViewModel Doctor { get; set; }

        protected List<AppointmentViewModel> Appointment { get; set; }
        protected SfGrid<AppointmentViewModel> AppointmentGrid { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                DoctorId = (await DoctorService.GetDoctorByUserId(Authenticate.User.Id)).Id;
                Doctor = (await DoctorService.GetDoctorByDoctorId(DoctorId));
                Appointment = await AppointmentService.GetAppointmentViewModelListByDoctorId(DoctorId);
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
        protected async Task CheckUp(int Id)
        {
            var appointment = Appointment.Where(x => x.Id == Id).FirstOrDefault();
            _navigationManager.NavigateTo("/doctorCheckUp/" + appointment.PatientId);

        }
        private async Task Approved(int Id)
        {
            var appointment = await AppointmentService.GetAppointmentById(Id);
            appointment.IsApproved = true;

            await AuditsService.AddAppointmentAudit(appointment, "UPDATE" , Authenticate.User.Id);
            await AppointmentService.UpdateAppointment(appointment);
            Appointment = await AppointmentService.GetAppointmentViewModelListByDoctorId(DoctorId);
        }
    }
}
