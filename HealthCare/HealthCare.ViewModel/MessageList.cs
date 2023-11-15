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
        public string CurrentChatBgColor { get; set; }
        public string ProfileCircleColor { get; set; }
        public string ProfileCircleLighterColor { get; set; }
        public string UserStatusBubble { get; set; }
        public string ProfileWords { get; set; }

        public List<InboxMessages> MessagesRecord = new List<InboxMessages>();
    }
}
