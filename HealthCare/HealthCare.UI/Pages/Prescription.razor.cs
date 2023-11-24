using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;

namespace HealthCare.UI.Pages
{
    public partial class Prescription
    {
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject]
        private IToastService _toastService { get; set; }
        [Inject]
        private ILogger<IndexModel> _logger { get; set; }
        [Inject] IEmployeeService s { get; set; }
        [Inject] IPrescriptionService PrescriptionService { get; set; } 
        [Inject] IUserService UserService { get; set; }
        [Inject] IDoctorService DoctorService { get; set; }
        [Parameter]
        public string DoctorId { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public UserViewModel User { get; set; }
        protected List<PrescriptionViewModel> Prescriptions { get; set; }
        public string SearchText { get; set; }
        protected SfGrid<PrescriptionViewModel> PrescriptionGrid { get; set; }
        protected bool IsDetailsDialogOpened { get; set; } = false;

        public List<MessageList> Lists { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Prescriptions = await PrescriptionService.GetPrescriptionViewModelByDoctorIdAndUserId(4,1);
                User = await UserService.GetUserViewModelById(1);
                Doctor = (await DoctorService.GetDoctorByDoctorId(int.Parse(DoctorId)));
            }
            catch
            (Exception ex)
            { }
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
