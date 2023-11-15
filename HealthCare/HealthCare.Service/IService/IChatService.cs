using HealthCare.Data.Entity;
using HealthCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public  interface IChatService
    {
        Task<MessageList> GetMessageListByUserIdAndDoctorId(int toUserId, int FromUserId, bool isUnseenMsgs);
        Task<InboxMessages> ConvertTimeClockMsgToMsg(HealthCareChat message);
        Task<int> AddChat(HealthCareChat chat);
    }
}
