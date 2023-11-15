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
        [Inject]
        IChatService ChatService { get; set; }
        #endregion
        #region Properties
        [Parameter]
        public int DoctorId { get; set; }
        [Parameter]
        public int UserId { get; set; }
        public MessageList currentChat { get; set; }
        public HealthCareChat message { get; set; }
        public bool IsImageUpload { get; set; }
        List<string> imageList = new List<string>();
        IReadOnlyList<IBrowserFile> selectedFiles;
        public SfTextBox msgtxtbox { get; set; } = new SfTextBox();
        #endregion
        #region Load Initials
        protected override async Task OnInitializedAsync()
        {
            message = new();
            await LoadMessagesChat(false);

            await msgtxtbox.FocusIn();
        }
        public void FocusChatBox()
        {
            msgtxtbox.FocusIn();
        }
        protected async Task LoadMessagesChat(bool isMessageSeen)
        {
            try
            {
                currentChat = await ChatService.GetMessageListByUserIdAndDoctorId(UserId, DoctorId, isMessageSeen);

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

              //  await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex)
            {
                //   await Error.HandleExceptionAsync(ex, "Messenger", "LoadMessagesChat");
            }
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
                        var path = fileManager.GetServerFolderPath() + "UserId_" + UserId + "_HealthCareMessageImageFile_Time_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_FileName_" + file.Name;
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
                if (!String.IsNullOrEmpty(message.Message))
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
                            message.Id = await ChatService.AddChat(message);
                            currentChat.MessagesRecord.Add(await ChatService.ConvertTimeClockMsgToMsg(message));
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
                        message.ToEmpId = UserId;
                        message.FromEmpId = DoctorId;
                        message.Id = await ChatService.AddChat(message);
                        currentChat.MessagesRecord.Add(await ChatService.ConvertTimeClockMsgToMsg(message));
                    }
                    await LoadMessagesChat(false);
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}
