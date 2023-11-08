using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity    
{
    public partial class UserType
    {
        public UserType()
        {
            UserTables = new HashSet<UserTable>();
        }

        public int UserTypeId { get; set; }
        public string UserType1 { get; set; }

        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
