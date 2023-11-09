using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.ViewModels.Enum;
using Microsoft.AspNetCore.Components;
using NuGet.Protocol;

namespace HealthCare.UI.Pages.Logins
{
    public partial class PatientSignUp
    {
        #region Injections
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IUserService UserService { get; set; }
        [Inject]
        IHelperService HelperService { get; set; }
        [Inject]
        IToastService ToastService { get; set; }
        #endregion
        #region Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactInfo { get; set; }
        public DateTime DateOfBirth  { get; set; }
        public int Gender { get; set; }
        public bool ShowSpinner { get; set; } = false;
        public List<HealthCareGender> Genders { get;set; }
        public HealthCare.UI.Pages.ErrorModel Error { get; set; }
        #endregion


        protected override async Task OnInitializedAsync()
        {
            Genders = await HelperService.GetAllGenders();
        }

        protected async Task CreateAccount()
        {
            try
            {
               await UserService.AddUser(
                    new HealthCareUser
                    {
                        Username = UserName,
                        Email = Email,
                        Password = Password,
                        GenderId = Gender,
                        ContactNumber =  ContactInfo,
                        DateOfBirth = DateOfBirth,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        UserTypeId = 2,
                        Active = true
                    });
                ToastService.ShowSuccess("UserAdded Successfully");
                UserName = "";
                Email = "";
                Password = "";
                ContactInfo = "";                
            }
            catch(Exception ex)
            {

            }
        }
    }
}
