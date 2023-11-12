using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.ViewModels
{
    public class InboxMessages
    {
        public int Id { get; set; }
        public int FromEmpId { get; set; }
        public int ToEmpId { get; set; }
        public string FromEmpName { get; set; }
        public string ToEmpName { get; set; }
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
