using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Data.Entity
{
    [Table("HR_DepartmentAndManagers")]
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("DepartmentName")]
        public string Name { get; set; }
        public string? DepartmentAbbreviation { get; set; }
        public string? DepartmentImage { get; set; }
        public long PrimaryManagerId { get; set; }
        public bool PrimaryManagerCanApproveTimeSheet { get; set; }
        public long? LeaderId { get; set; }
        public bool LeaderCanApproveTimeSheet { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? DateCreated { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
