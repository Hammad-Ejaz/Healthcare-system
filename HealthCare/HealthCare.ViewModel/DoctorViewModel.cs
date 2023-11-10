using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.ViewModels
{
	public class DoctorViewModel
	{
		public int DoctorId { get; set; }
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Specialization { get; set; }
		public int? WorkExperience { get; set; }
	}
}
