using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using iTextSharp.text.io;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class DoctorService : IDoctorService
    {

        private IUnitOfWork UnitOfWork;

        public DoctorService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async void AddDoctor(HealthcareDoctor user)
        {
           await UnitOfWork.Doctor.InsertAsync(user);
        }

        public async Task<List<DoctorViewModel>> GetAllDoctors()
        {
            var users = (await UnitOfWork.User.GetListAsync()).ToList();
            var doctors = (await UnitOfWork.Doctor.GetListAsync()).ToList();
            var specialization = (await UnitOfWork.Specialization.GetListAsync()).ToList();
            List<DoctorViewModel> doctorList = new List<DoctorViewModel>();
            foreach(var doctor in doctors)
            {
                doctorList.Add(
                    new DoctorViewModel()
                    {
                        DoctorId = doctor.Id,
                        UserId = users.Where(x => x.Id == doctor.UserId).Select(x => x.Id).FirstOrDefault(),
                        Username = users.Where(x => x.Id == doctor.UserId).Select(x => x.Username).FirstOrDefault(),
                        Specialization = specialization.Where(x => x.Id == doctor.SpecializationId).Select(x => x.Specialization).FirstOrDefault(),
                        WorkExperience = doctor.WorkExperience
                    });
            }
            return doctorList;

        }

		public async Task<List<DoctorViewModel>> GetDoctorBySearchText(string searchText)
   		{
			return (await GetAllDoctors()).Where(x=> (x.Username != null && x.Username.ToLower().Contains(searchText.ToLower())) || (x.Specialization != null && x.Specialization.ToLower().Contains(searchText.ToLower()))).ToList();
        }
        public async Task<DoctorViewModel> GetDoctorByDoctorId(int doctorId) 
        {
            return (await GetAllDoctors()).Where(x=> x.DoctorId == doctorId).FirstOrDefault();
        } 
	}
}
