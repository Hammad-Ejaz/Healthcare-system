using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.ViewModels
{
    public class InboxMessages
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public string Message { get; set; }
        public string ImageFile { get; set; }
        public string DocumentFile { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string StringEnteredDate { get; set; }
        public string Color { get; set; }
        public bool IsSeen { get; set; }
        public string NameAndEnteredDate { get; set; }
        public string StringSeenDate { get; set; }
    }
}
