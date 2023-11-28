using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.UI.Shared;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Inputs;
using static Google.Apis.Requests.BatchRequest;

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
        [Inject]
        IHttpContextAccessor httpContextAccessor { get; set; }
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
                    new HealthCareUser
                    {
                        Username = UserName,
                        Password = Password,
                    }
                );
            if(user != null)
            {
                if(user.Password == Password)
                {
                    Authenticate.IsLogin = true;

                    // Generate Cookie
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim("FullName", user.Username),
                        new Claim(ClaimTypes.Role, "Administrator"),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    //await httpContextAccessor.HttpContext.SignInAsync(
                    //    CookieAuthenticationDefaults.AuthenticationScheme,
                    //    new ClaimsPrincipal(claimsIdentity),
                    //    authProperties);

                    if (user.UserTypeId == (int)HealthCare.ViewModels.Enum.UserType.PATIENT)
                    {

                        NavigationManager.NavigateTo("/patientDashboard");
                    }
                    else
                    {
                        NavigationManager.NavigateTo("/doctorDashboard/" + user.Id);
                    }

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

