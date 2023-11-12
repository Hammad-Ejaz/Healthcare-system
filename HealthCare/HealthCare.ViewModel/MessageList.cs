using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.ViewModels
{
    public class MessageList
    {
        public int Id { get; set; }
        public string ChatEmpName { get; set; }
        public int ChatEmpId { get; set; }
        public string LastMessage { get; set; }
        public DateTime? LastEnteredDate { get; set; }
        public string StringLastEnteredDate { get; set; }
        public int NotSeenMsgCount { get; set; }
        public bool ImagePresent { get; set; }
        public bool IsReply { get; set; }
        public string  Message { get; set; }
        public string DocumentName { get; set; }
        public string CurrentChatBgColor { get; set; }
        public string ProfileCircleColor { get; set; }
        public string ProfileCircleLighterColor { get; set; }
        public string EmployeeStatusBubble { get; set; }
        public string EmployeeStatus { get; set; }        
        public string ProfileWords { get; set; }
        public List<InboxMessages> MessagesRecord = new List<InboxMessages>();
    }
}
