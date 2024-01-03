using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.Service.Service;
using HealthCare.UI.Shared;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;

namespace HealthCare.UI.Pages
{
    public partial class Prescription
    {
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject] ILogService LogService { get; set; }
        [Inject] IPrescriptionService PrescriptionService { get; set; }
        [Inject] IAuditsService AuditsService { get; set; }
        [Inject] IUserService UserService { get; set; }
        [Inject] IDoctorService DoctorService { get; set; }
        [Inject] IToastService ToastService { get; set; }
        [Parameter]
        public string UserId { get; set; }
        public HealthcareDoctor Doctor { get; set; }
        protected HealthCareUser User { get; set; }
        protected List<PrescriptionViewModel> Prescriptions { get; set; }
        protected HealthCarePrescription Prescription_ { get; set; } = new();
        public string SearchText { get; set; }
        protected SfGrid<PrescriptionViewModel> PrescriptionGrid { get; set; }
        protected bool IsDetailsDialogOpened { get; set; } = false;

        public List<MessageList> Lists { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                User = await UserService.GetUserById(int.Parse(UserId));
                Doctor = await DoctorService.GetDoctorByUserId(Authenticate.User.Id);
                Prescriptions = await PrescriptionService.GetPrescriptionViewModelByDoctorIdAndUserId(Doctor.Id,int.Parse(UserId));
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
                        AdditionalDetails = "Prescription.razor.cs",
                        CreatedAt = DateTime.Now,
                        Active = true
                    });
            }
        }
        protected async Task ExcelExport()
        {
            ExcelExportProperties excelProperties = new ExcelExportProperties
            {
                FileName = "PrescriptionGrid-" + DateTime.Now.ToString("MM-dd-yyyy") + ".xlsx",
                IncludeTemplateColumn = true
            };
            await PrescriptionGrid.ExportToExcelAsync(excelProperties);
        }
        protected async Task OnSearch(Syncfusion.Blazor.Inputs.ChangedEventArgs args)
        {
            await PrescriptionGrid.SearchAsync(args.Value);
        }

        protected async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id == "PrescriptionGrid_excelexport")
            {
                ExcelExportProperties excelProperties = new ExcelExportProperties
                {
                    FileName = "Prescription-" + DateTime.Now.ToString("MM-dd-yyyy") + ".xlsx"
                };
                await PrescriptionGrid.ExportToExcelAsync(excelProperties);
            }
        }

        protected bool ValidationForPrescriptions()
        {
            int isErrorFound = 0;
            if(Prescription_.Medication == null)
            {
                isErrorFound += 1;
            }
            if(Prescription_.Dosage == null)
            {
                isErrorFound += 1;
            }
            if(Prescription_.Instructions == null)
            {
                isErrorFound += 1;
            }
            return isErrorFound > 0;
        }
        protected async  Task Edit(int prescriptionId)
        {
            try
            {
                Prescription_ = await PrescriptionService.GetPrescriptionById(prescriptionId);
            }
            catch (Exception ex)
            {
                await LogService.AddLog(
                new HealthCareExceptionLog()
                {
                    LogTimestamp = DateTime.Now,
                    ExceptionMessage = ex.Message,
                    UserId = Authenticate.User.Id,
                    TableName = "Prescription, Audits",
                    AdditionalDetails = "Prescription.razor.cs",
                    CreatedAt = DateTime.Now,
                    Active = true
                });
            }
        }

        protected async Task Delete(int prescriptionId)
        {
            Prescription_ = await PrescriptionService.GetPrescriptionById(prescriptionId);
            Prescription_.Active = false;

            await PrescriptionService.UpdatePrescription(Prescription_);
            await AuditsService.AddPrescriptionAudit(Prescription_, "UPDATE", Authenticate.User.Id);
            Prescriptions = await PrescriptionService.GetPrescriptionViewModelByDoctorIdAndUserId(Doctor.Id, int.Parse(UserId));
            ToastService.ShowSuccess("Prescription Deleted Successfully!", "Success");
        }
        protected async Task Save()
        {
            try
            {
                if(!ValidationForPrescriptions()) 
                { 
                    Prescription_.PatientId = User.Id;
                    Prescription_.DoctorId = Doctor.Id;
                    Prescription_.Active = true;
                    Prescription_.DatePrescribed = DateTime.Now;
                    if(Prescription_.PatientId == 0)
                    {
                        Prescription_.Id =await  PrescriptionService.AddPrescription(Prescription_);
                         await AuditsService.AddPrescriptionAudit(Prescription_, "ADD", Authenticate.User.Id);
                    }
                    else
                    {
                        await PrescriptionService.UpdatePrescription(Prescription_);
                        await AuditsService.AddPrescriptionAudit(Prescription_, "UPDATE", Authenticate.User.Id);
                    }
                    Prescriptions = await PrescriptionService.GetPrescriptionViewModelByDoctorIdAndUserId(Doctor.Id, int.Parse(UserId));
                    ToastService.ShowSuccess("Prescription Added Successfully!", "Success");
                   
                    Prescription_.Medication = null;
                    Prescription_.Dosage = null;
                    Prescription_.Instructions = null;
                }
                else
                {
                    ToastService.ShowError("Fields Are Empty", "Error");
                }
            }
            catch(Exception ex)
            {
                await LogService.AddLog(
                    new HealthCareExceptionLog()
                    {
                        LogTimestamp = DateTime.Now,
                        ExceptionMessage = ex.Message,
                        UserId = Authenticate.User.Id,
                        TableName = "Prescription, Audits",
                        AdditionalDetails = "Prescription.razor.cs",
                        CreatedAt = DateTime.Now,
                        Active = true
                    });
            }

               
        }
        protected void OpenPrescriptionDialoge()
        {
            IsDetailsDialogOpened = true;
        }

    }
}
