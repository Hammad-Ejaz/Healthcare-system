using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class ExceptionLog
    {
        public int LogId { get; set; }
        public DateTime? LogTimestamp { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public int? UserId { get; set; }
        public string TableName { get; set; }
        public int? RecordId { get; set; }
        public string AdditionalDetails { get; set; }
    }
}
