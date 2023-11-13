using Blazored.Toast.Services;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using Microsoft.AspNetCore.Components;

namespace HealthCare.UI.Pages.Logins
{
    public partial class ResetPassword
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
        [Inject]
        IEmailService EmailService { get; set; }
        #endregion
        #region Properties
        public string NewPassword { get; set; }
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
        public string MyCode { get; set; }
        public bool ShowSpinner { get; set; } = false;
        public HealthCare.UI.Pages.ErrorModel Error { get; set; }
        #endregion

        protected async void SendEmail()
        {
            MyCode = EmailService.GenerateVerificationCode(6);
            string body = $"<html>\r\n<body>\r\n    <p>Hi There,</p>\r\n  \r\n    <p>We received a request to reset your password. Your 6 digit confirmation code is given below:</p>\r\n\r\n  <p><strong>{MyCode}</strong>></p>\r\n\r\n    <p>If you did not request a password reset, please ignore this email. Your account is secure.</p>\r\n\r\n    <p>Thank you,<br>\r\n    Health Care</p>\r\n</body>\r\n</html>\r\n";
            
            var user = await UserService.GetUserByEmail(Email);
            if (user != null)
            {
                var message = EmailService.SendEmail(Email , "Reset Password" , body);
                if(message == "Email sent successfully!")
                {
                    ToastService.ShowSuccess(message, "Check your mail");
                }
                else
                {
                    ToastService.ShowError(message, "Failed");
                }
            }
            else
            {
                ToastService.ShowError("User Not Found", "Not Found");
            }
        }
        protected bool CodeConfirmation()
        {
            return (Code == MyCode); 
        }

        protected async Task PasswordReset()
        {
            try
            {
                if(CodeConfirmation())
                {
                    var user = await UserService.GetUserByEmail(Email);
                    if (NewPassword == ConfirmPassword)
                    {
                        user.Password = ConfirmPassword;
                        UserService.UpdateUser(user);
                        NavigationManager.NavigateTo("loginAccount");
                        ToastService.ShowSuccess("Password Reset Successfully", "Congratulations");
                    }
                    else
                    {
                        ToastService.ShowError("Passwords Not Matched", "Failed");
                    }
                }
                else
                { 
                    ToastService.ShowError("Enter a valid code", "Invalid Code"); 
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
