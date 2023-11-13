using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Popups;
using System.IO;
using Syncfusion.Blazor.Inputs;
using HealthCare.ViewModels;
using HealthCare.Repository;
using HealthCare.Service.IService;
using HealthCare.Data.Entity;

namespace HealthCare.UI.Pages.Components.MessengerComponents
{
    public partial class CurrentChatComponent : ComponentBase
    {
        #region Injections
        [Inject]
        IFileManager fileManager { get; set; }
        [Inject]
        IToastService ToastService { get; set; }
        [Inject]
        IUserService EmployeeService { get; set; }
        #endregion
        #region Properties
        [Parameter]
        public string UserId { get; set; }
        [Parameter]
        public MessageList currentChat { get; set; }
        [Parameter]
        public HealthCareChat message { get; set; }
        [Parameter]
        public EventCallback<bool> LoadMessageChatBox { get; set; }
        public bool IsImageUpload { get; set; }
        List<string> imageList = new List<string>();
        IReadOnlyList<IBrowserFile> selectedFiles;
        public SfTextBox msgtxtbox { get; set; } = new SfTextBox();
        #endregion
        #region Load Initials
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(100);
            await msgtxtbox.FocusIn();
        }
        public void FocusChatBox()
        {
            msgtxtbox.FocusIn();
        }
        #endregion
        #region File Upload and Remove Functions
        // Used to remove image
        protected async void RemoveImage(string img)
        {
            try
            {
                // Remove Image from Image List
                imageList.Remove(img);
                // Is there is no image present in the image list then set IsImageUpload equat to false
                if (imageList.Count == 0)
                {
                    IsImageUpload = false;
                }
                StateHasChanged();
            }
            catch (Exception ex)
            {
//                await Error.HandleExceptionAsync(ex, "CurrentChatComponent", "RemoveImage");
            }

        }
        // Used to Upload file
        public async void OnInputFileChange(InputFileChangeEventArgs args)
        {
            try
            {
                // Get Image files
                selectedFiles = args.GetMultipleFiles();
                foreach (var file in selectedFiles)
                {
                    // file size validation
                    if (file.Size <= 512000)
                    {
                        // Set File Path Name
                        var path = fileManager.GetServerFolderPath() + "EmployeeId_" + UserId + "_JarvisMessageImageFile_Time_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_FileName_" + file.Name;
                        // Get file extension 
                        var ext = Path.GetExtension(path).ToLower();
                        // Check if file extension is image type else show error message
                        if (ext.ToString() == ".jpg" || ext.ToString() == ".png" || ext.ToString() == ".jpeg")
                        {
                            Stream stream = file.OpenReadStream();
                            FileStream fs = File.Create(path);
                            await stream.CopyToAsync(fs);
                            stream.Close();
                            fs.Close();
                            IsImageUpload = true;
                            imageList.Add(path);
                        }
                        else
                        {
                            selectedFiles = null;
                            IsImageUpload = false;
                            imageList = new List<string>();
                            ToastService.ShowError("Only Image Files are Allowed!", "Invalid picture");
                            return;
                        }
                    }
                    else
                    {
                        selectedFiles = null;
                        IsImageUpload = false;
                        imageList = new List<string>();
                        ToastService.ShowError("Size is too large!", "Invalid picture");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
              //  await Error.HandleExceptionAsync(ex, "CurrentChatComponent", "OnInputFileChange");
            }
        }
        // Used to upload the document file
        void OnInputDocumentFileChange(InputFileChangeEventArgs args)
        {
            message.DocumentFile = fileManager.GetServerFolderPath() + args.File.Name;
        }
        #endregion
        #region Message Functions
        // Used to call Send Msg when Enter is pressed
        protected void Keydown(KeyboardEventArgs args)
        {
            if (args.Code == "Enter")
            {
                SendMsg();
            }
        }
        // Used to Send Messages
        protected async void SendMsg()
        {
            try
            {
                if ((!String.IsNullOrEmpty(message.Message) || IsImageUpload || !String.IsNullOrEmpty(message.DocumentFile)) && !String.IsNullOrEmpty(message.ToEmpId.ToString()) && !String.IsNullOrEmpty(message.FromEmpId.ToString()))
                {
                    if (IsImageUpload)
                    {
                        IsImageUpload = false;
                        foreach (var file in imageList)
                        {
                            message.ImageFile = file;
                            message.Id = 0;
                            message.EnteredDate = DateTime.Now;
                            if (!String.IsNullOrEmpty(message.Message))
                            {
                                message.Message = message.Message.ToUpper();
                            }
                            message.IsSeen = false;
                        //    message.Id = MessengerService.AddMsgs(message);
                        //    currentChat.MessagesRecord.Add(MessengerService.ConvertTimeClockMsgToMsg(message));
                            message.Message = "";
                        }
                        imageList = new List<string>();
                    }
                    else
                    {
                        message.Id = 0;
                        message.EnteredDate = DateTime.Now;
                        if (!String.IsNullOrEmpty(message.Message))
                        {
                            message.Message = message.Message.ToUpper();
                        }
                        message.IsSeen = false;
                    //   message.Id = MessengerService.AddMsgs(message);
                    //    currentChat.MessagesRecord.Add(MessengerService.ConvertTimeClockMsgToMsg(message));
                        message.Message = "";
                    
                        
                    }
                }
                    await LoadMessageChatBox.InvokeAsync(false);

            }
            catch (Exception ex)
            {
           //     await Error.HandleExceptionAsync(ex, "CurrentChatCommponent", "SendMsg");
            }
        }
        #endregion
    }
}
