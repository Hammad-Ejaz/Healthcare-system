using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Repository;
using HealthCare.Service.IService;
using HealthCare.Service.Service;
using HealthCare.UI.Pages.Components;
using HealthCare.UI.Shared;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;
using Org.BouncyCastle.Ocsp;
using Syncfusion.Blazor.Grids;

namespace HealthCare.UI.Pages
{
    public partial class PatientCheckUp
    {
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject] IToastService ToastService { get; set; }
        [Inject] IEmployeeService Chats { get; set; }
        [Inject] IUserService UserService { get; set; }
        [Inject] IDoctorService DoctorService { get; set; }
        [Inject] ILogService LogService { get; set; }
        [Inject] IPrescriptionService PrescriptionService { get; set; }
        [Parameter]
        public string DoctorId { get; set; }
        public DoctorViewModel Doctor { get; set; }
        protected List<PrescriptionViewModel> Prescriptions { get; set; }
        protected HealthCareUser User { get; set; }
        public string SearchText { get; set; }
        protected SfGrid<PrescriptionViewModel> PrescriptionGrid { get; set; }
        public List<HealthCareChat> Chat { get; set; }
        protected bool IsDetailsDialogOpened { get; set; } = false;

        public List<MessageList> Lists { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                User = await UserService.GetUserById(Authenticate.User.Id);
                Prescriptions = await PrescriptionService.GetPrescriptionViewModelByDoctorIdAndUserId(int.Parse(DoctorId), User.Id);
                Chat = Chats.Get();
                Doctor = (await DoctorService.GetDoctorByDoctorId(int.Parse(DoctorId)));
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
                        AdditionalDetails = "PatientCheckUp.razor.cs",
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

        protected void OpenPrescriptionDialoge()
        {
            IsDetailsDialogOpened = true;
        }

    }
}
