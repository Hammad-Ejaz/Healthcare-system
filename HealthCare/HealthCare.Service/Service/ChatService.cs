using CamcoTimeClock.Repository.UnitOfWork;
using Google.Apis.Gmail.v1.Data;
using HealthCare.Data.Entity;
using HealthCare.Repository;
using HealthCare.Repository.IRepository;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class ChatService : IChatService
    {
        private IUnitOfWork UnitOfWork;

        public ChatService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        public async Task<int> AddChat(HealthCareChat chat)
        {
            return await UnitOfWork.Chat.InsertAsync(chat);
        }
        public async Task<InboxMessages> ConvertTimeClockMsgToMsg(HealthCareChat message)
        {
            InboxMessages msg = new InboxMessages();
            msg.Id = message.Id;
            msg.ToEmpId = message.ToEmpId??0;
            msg.FromEmpId = message.FromEmpId ?? 0;
            msg.EnteredDate = message.EnteredDate;
            msg.IsSeen = (bool)message.IsSeen;
            msg.StringEnteredDate = message.EnteredDate.Value.ToString("h:m tt M/d");
            msg.Message = message.Message;
            msg.DocumentFile = message.DocumentFile;
            msg.ImageFile = message.ImageFile;
            var fromEmp = await UnitOfWork.User.GetByIdAsync(msg.FromEmpId);
            msg.NameAndEnteredDate = fromEmp.Username + ", " + msg.StringEnteredDate;
            msg.FromEmpName = fromEmp.Username;
            msg.ToEmpName = (await UnitOfWork.User.GetByIdAsync(msg.ToEmpId)).Username;
            msg.IsSeen = (bool)message.IsSeen;
            if (msg.IsSeen == true)
            {
                msg.StringSeenDate = message.SeenDate != null ? "READ : " + message.SeenDate.Value.ToString("h:m tt M/d") : "";

            }
            else
            {
                msg.StringSeenDate = "unread";
            }
            msg.Color = "#add8e6 !important";
            return msg;
        }

        public async Task<MessageList> GetMessageListByUserIdAndDoctorId(int toUserId,int FromUserId , bool isUnseenMsgs)
        {

            var chat = new MessageList();
            var toUser =await UnitOfWork.User.GetByIdAsync(toUserId);
            var fromUser = await UnitOfWork.User.GetByIdAsync(FromUserId);
            chat.ChatEmpName = toUser.Username;
            var messageRecord = UnitOfWork.Chat.Find(x => (!isUnseenMsgs || x.IsSeen == null || (bool)x.IsSeen == false) && x.ToEmpId == toUserId && x.FromEmpId == FromUserId && (x.IsDeleteByToEmp == null || !(bool)x.IsDeleteByToEmp) || (!isUnseenMsgs && x.FromEmpId == toUserId && x.ToEmpId == FromUserId && (x.IsDeleteByFromEmp == null || !(bool)x.IsDeleteByFromEmp))).OrderBy(x => x.EnteredDate).ToList();
            for (int j = 0; j < messageRecord.Count; j++)
            {
                InboxMessages msg = new InboxMessages();
                msg.Id = messageRecord[j].Id;
                msg.ToEmpId = messageRecord[j].ToEmpId ?? 0;
                msg.FromEmpId = messageRecord[j].FromEmpId ?? 0;
                msg.EnteredDate = messageRecord[j].EnteredDate;
                msg.StringEnteredDate = messageRecord[j].EnteredDate.Value.ToString("h:m tt M/d");
                msg.Message = messageRecord[j].Message;
                msg.ImageFile = messageRecord[j].ImageFile;
                msg.DocumentFile = messageRecord[j].DocumentFile;
                msg.FromEmpName = fromUser.Username;
                msg.ToEmpName = toUser.Username;
                msg.IsSeen = messageRecord[j].IsSeen == null || (bool)messageRecord[j].IsSeen == false ? false : true;
                msg.NameAndEnteredDate = fromUser.Username + ", " + msg.StringEnteredDate;
                if (messageRecord[j].IsSeen == true)
                {
                    msg.StringSeenDate = messageRecord[j].SeenDate != null ? "READ : " + messageRecord[j].SeenDate.Value.ToString("h:m tt M/d") : "";
                }
                else
                {
                    msg.StringSeenDate = "UNREAD";
                }
                if (msg.ToEmpId == toUserId)
                {
                    msg.Color = "#f2f6f9 !important";
                }
                else
                {
                    msg.Color = "#dbf1ff !important";
                }
                chat.MessagesRecord.Add(msg);

            }
            return chat;
        }
    }
}
