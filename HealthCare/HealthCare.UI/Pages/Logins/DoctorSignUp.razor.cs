using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.Service.Service;
using Microsoft.AspNetCore.Components;

namespace HealthCare.UI.Pages.Logins
{
    public partial class DoctorSignUp
    {
        #region Injections
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IUserService UserService { get; set; }
        [Inject]
        IHelperService HelperService { get; set; }
        [Inject]
        IDoctorService DoctorService { get; set; }
        [Inject]
        IToastService ToastService { get; set; }
        #endregion
        #region Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactInfo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public bool ShowSpinner { get; set; } = false;
        public int Specialization { get; set; }
        public long MedicalNo { get; set; }
        public int WorkExperience {  get; set; }
        public List<HealthCareGender> Genders { get; set; }
        public List<HealthCareDoctorSpecialization> Specializations { get; set; }

        public HealthCare.UI.Pages.ErrorModel Error { get; set; }
        #endregion


        protected override async Task OnInitializedAsync()
        {
            Genders = await HelperService.GetAllGenders();
            Specializations = await HelperService.GetAllDoctorSpecializations();
        }

        protected async Task CreateAccount()
        {
            try
            {
                var Id = await UserService.AddUser(
                    new UserTable
                    {
                        Username = UserName,
                        Email = Email,
                        Password = Password,
                        GenderId = Gender,
                        ContactNumber = ContactInfo,
                        DateOfBirth = DateOfBirth,
                        UserTypeId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Active = true
                    });

                DoctorService.AddDoctor(
                    new HealthcareProviderTable
                    {
                        UserId = Id,
                        SpecializationId = Specialization,
                        WorkExperience = WorkExperience,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Active = true
                    });
                ToastService.ShowSuccess("UserAdded Successfully");
                UserName = "";
                Email = "";
                Password = "";
                ContactInfo = "";
            }
            catch (Exception ex)
            {

            }
        }
    }
}
