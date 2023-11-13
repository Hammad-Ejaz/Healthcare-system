using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Repository;
using HealthCare.Service.IService;
using HealthCare.Service.Service;
using HealthCare.UI.Pages.Components;
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
        [Inject]
        private IToastService _toastService { get; set; }
        [Inject]
        private ILogger<IndexModel> _logger { get; set; }
        [Inject] IEmployeeService s { get; set; }
        [Inject] IUserService UserService { get; set; }
        [Inject] IDoctorService DoctorService { get; set; }
        [Parameter]
        public string DoctorId { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public UserViewModel User  { get; set; }
        protected List<PrescriptionViewModel> Prescription { get; set; }
        public string SearchText { get; set; }
        protected SfGrid<PrescriptionViewModel> PrescriptionGrid { get; set; }
        public List<HealthCareChat> Chat { get; set; }
        protected bool IsDetailsDialogOpened { get; set; } = false;

        public List<MessageList> Lists { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Prescription = s.Get1();
                Chat = s.Get();
                LoadMessagesChat(true);
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




        protected async Task LoadMessagesChat(bool isMessageSeen)
        {
            try
            {
                HealthCareChat currentChat = Chat[0];
                Lists = s.GetMessageListByEmpId(DoctorId, "2", false);
                Lists.Add(new MessageList()
                {
                   Id = 10,
                   ChatEmpName = "Hammad",
                   ChatEmpId = 1,
                   LastEnteredDate = DateTime.Now,
                   IsReply = false,
                   Message = "TATTI KHA LA"
                });

                //if (randomLightColorList.Count > 0)
                //{
                //    for (int i = 0; i < messagesList.Count; i++)
                //    {
                //        if (i < randomDarkColorList.Count)
                //        {
                //            messagesList[i].ProfileCircleColor = randomDarkColorList[i];
                //            messagesList[i].ProfileCircleLighterColor = randomLightColorList[i];
                //        }
                //    }
                //}
                //if (!IsColorsSelected)
                //{
                //    EmployeeProfile = MessengerService.GetEmployeeProfile(EmpId);
                //    randomDarkColorList = MessengerService.GetRandomDarkColorList(messagesList.Count);
                //    randomLightColorList = MessengerService.GetRandomLightColorList(messagesList.Count);
                //    IsColorsSelected = true;
                //}
                //messagesList = messagesList.OrderByDescending(x => x.LastEnteredDate).ToList();
                //if (!String.IsNullOrEmpty(SearchPeople))
                //{
                //    messagesList = messagesList.Where(x => x.ChatEmpName.Contains(SearchPeople.ToUpper())).OrderByDescending(x => x.LastEnteredDate).ToList();
                //}
                //if (!String.IsNullOrEmpty(SearchInputKeys))
                //{
                //    messagesList = messagesList.Where(x => x.ChatEmpName.Contains(SearchInputKeys.ToUpper())).OrderByDescending(x => x.LastEnteredDate).ToList();
                //}

                //if (currentChat != null && !String.IsNullOrEmpty(currentChat.ChatEmpId))
                //{
                //    var chat = messagesList.ToList().Where(x => x.ChatEmpId == currentChat.ChatEmpId).FirstOrDefault();
                //    if (chat != null)
                //    {
                //        currentChat = chat;
                //        if (isMessageSeen)
                //        {
                //            SeenMsgChat(currentChat);
                //            aTimer.Dispose();
                //        }
                //    }
                //}

                await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex)
            {
             //   await Error.HandleExceptionAsync(ex, "Messenger", "LoadMessagesChat");
            }
        }

    }
}
