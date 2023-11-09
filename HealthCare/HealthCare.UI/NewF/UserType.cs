using System;
using System.Collections.Generic;

namespace HealthCare.UI.NewF
{
    public partial class UserType
    {
        public UserType()
        {
            HealthCareUsers = new HashSet<HealthCareUser>();
            UserTables = new HashSet<UserTable>();
        }

        public int Id { get; set; }
        public string UserType1 { get; set; }

        public virtual ICollection<HealthCareUser> HealthCareUsers { get; set; }
        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
