using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.UI.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Inputs;

namespace HealthCare.UI.Pages.Logins
{
    public partial class UserAuthentication : ComponentBase
    {
        #region Injections
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IUserService UserService { get; set; }  
        [Inject]
        IToastService ToastService { get; set; }
        #endregion
        #region Properties
        public string Password { get; set; }
        public string UserName { get; set; }
        public string ScreenLabel { get; set; } = "HuRe / Ja";
        public bool ShowSpinner { get; set; } = false;
        public HealthCare.UI.Pages.ErrorModel Error { get; set; }
        #endregion

        #region Input Controls
        // If enter key is pressed then navigate to manager section
        protected void Keydown(KeyboardEventArgs args)
        {
            if (args.Code == "Enter" && !String.IsNullOrEmpty(Password))
            {
                Login();
            }
        }
        #endregion

        #region Navigate to Pages
       
        protected async Task Login()
        {
            var user = await UserService.IsUserExits(
                    new UserTable
                    {
                        Username = UserName,
                        Password = Password,
                    }
                );
            if(user != null)
            {
                if(user.Password == Password)
                {
                    if(user.UserTypeId == (int)HealthCare.ViewModels.Enum.UserType.PATIENT)
                    {
                        
                        NavigationManager.NavigateTo("/patientDashboard");
                    }
                    else
                    {
                        NavigationManager.NavigateTo("/patientDashboard");
                    }
                    Authenticate.IsLogin = true;
                    ToastService.ShowSuccess("You are Login Successfully!", "Congratulation");                    
                }
                else
                    ToastService.ShowSuccess("You are Password is wrong!", "Warning");
            }
            else
            {
                ToastService.ShowSuccess("User did not exists!", "Sorry");
            }
        }
        #endregion
    }
}

