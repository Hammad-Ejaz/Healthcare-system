using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthCareGender
    {
        public HealthCareGender()
        {
            UserTables = new HashSet<UserTable>();
        }

        public int Id { get; set; }
        public string GenderType { get; set; }

        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
