using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
