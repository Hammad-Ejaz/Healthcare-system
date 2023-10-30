using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Toast.Services;
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
        IToastService ToastService { get; set; }
        #endregion
        #region Properties
        public string Password { get; set; }
        public string UserName { get; set; }
        public string ScreenLabel { get; set; } = "HuRe / Ja";
        public bool ShowSpinner { get; set; } = false;
        public HealthCare.UI.Pages.ErrorModel Error { get; set; }
        #endregion
        #region Load Initials

        // Initialize functions
        protected override async Task OnInitializedAsync()
        {
            try
            {
                //// Load Employees Drop Downs
                //employees = EmployeeService.GetJarvisEmployeesNamesAndIdsByActiveStatus(false).OrderBy(x=> x.LastName + ", " +x.FirstName).ToList();
                //// Check if Manager is log in
                //if (!String.IsNullOrEmpty(SessionState.ManagerEmpId))
                //{
                //    Employee = EmployeeService.GetEmployeeNameByEmpId(SessionState.ManagerEmpId);
                //}
            }
            catch (Exception ex)
            {
//               await Error.HandleExceptionAsync(ex, "UserAuthentication", "OnInitializedAsync");
            }
        }
        #endregion
        #region Input Controls
        // Focus on employee drop down
        public void OnFocus()
        {
           // this.comboObj.ShowPopup();
        }
        // If enter key is pressed then navigate to manager section
        protected void Keydown(KeyboardEventArgs args)
        {
            if (args.Code == "Enter" && !String.IsNullOrEmpty(Password))
            {
                MoveToManagerSectionAsync();
            }
        }
        #endregion
        #region Navigate to Pages
        protected async Task MoveToManagerSectionAsync()
        {
            //try
            //{
            //    // Validations
            //    if (string.IsNullOrEmpty(Employee))
            //    {
            //        ToastService.ShowError("Please Select an Employee First!", "Mandatory Selection");
            //    }
            //    else if (string.IsNullOrWhiteSpace(Password) || (Password.ToLower() != "crib" && Password.ToLower() != "camco18810"))
            //    {
            //        ToastService.ShowError("Please Enter Password!", "Incorrect Password");
            //        SessionState.AlreadyLoggedIn = false;
            //    }
            //    else
            //    {
            //        // Get Manager Department Employees List by Manger Emp Id
            //        SessionState.DeptEmpList = EmployeeService.GetManagerDeptEmpList(employees.Where(x => x.FullName == Employee).Select(x => x.EmpId).First());
            //        SessionState.AlreadyLoggedIn = true;
            //        var EmpId = employees.Where(x => x.FullName == Employee).Select(x => x.EmpId).First();
            //        SessionState.Username = Employee;
            //        SessionState.UserId = EmployeeService.GetIdFromCustomEmpId(EmpId);
                    
            //        if (SessionState.UserAuthenticationChoice == "VacationsApproval" && EmpId=="100202")
            //        {
            //            NavigationManager.NavigateTo("/approveVacations");

            //            SessionState.UserAuthenticationChoice = "";
            //        }
            //        else if (SessionState.UserAuthenticationChoice == "ClockTimeApproval")
            //        {
            //            NavigationManager.NavigateTo("/approveCheckInOutTimes/" + EmpId);
            //            SessionState.UserAuthenticationChoice = "";
            //        }
            //        else if (SessionState.UserAuthenticationChoice == "BusinessTimeApproval")
            //        {
            //            NavigationManager.NavigateTo("/approveBusinessTripTimes");
            //            SessionState.UserAuthenticationChoice = "";
            //        }
            //        else
            //        {
            //            NavigationManager.NavigateTo("/managerSection/" + EmpId);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    await Error.HandleExceptionAsync(ex, "UserAuthentication", "MoveToManagerSectionAsync");
            //}

        }

        async Task cancelAsync()
        {
            //try
            //{
            //    if (SessionState.UserAuthenticationChoice == "VacationsApproval" || SessionState.UserAuthenticationChoice == "ClockTimeApproval" || SessionState.UserAuthenticationChoice == "BusinessTimeApproval")
            //    {
            //        var url = "/checkInAndOut1/" + SessionState.ManagerEmpId;
            //        NavigationManager.NavigateTo(url);
            //        SessionState.ManagerEmpId = "";
            //        SessionState.UserAuthenticationChoice = "";
            //    }
            //    else
            //    {
            //        NavigationManager.NavigateTo("/");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    await Error.HandleExceptionAsync(ex, "UserAuthentication", "cancel");
            //}

        }
        #endregion
    }
}

