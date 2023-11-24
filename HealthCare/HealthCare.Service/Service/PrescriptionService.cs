using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class PrescriptionService : IPrescriptionService
    {

        private IUnitOfWork UnitOfWork;

        public PrescriptionService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async Task<List<HealthCarePrescription>> GetPrescriptionByDoctorIdAndUserId(int doctorId  , int userId)
        {
            return (await UnitOfWork.Prescription.SearchAsync(x=>x.DoctorId == doctorId && x.PatientId == userId)).ToList();
        }
        public async Task<List<PrescriptionViewModel>> GetPrescriptionViewModelByDoctorIdAndUserId(int doctorId, int userId)
        {
            var prescriptions =  (await UnitOfWork.Prescription.SearchAsync(x => x.DoctorId == doctorId && x.PatientId == userId)).ToList();
            var doctor = await UnitOfWork.Doctor.GetByIdAsync(doctorId);
            List<PrescriptionViewModel> prescriptionsList = new();

            foreach(var prescription in prescriptions)
            {
                prescriptionsList.Add(new PrescriptionViewModel()
                {
                    PatientNmme = (await UnitOfWork.User.GetByIdAsync(prescription.PatientId ?? 0)).Username,
                    DoctorName = (await UnitOfWork.User.GetByIdAsync(doctor.UserId ?? 0)).Username,
                    DatePrescribed = prescription.DatePrescribed,
                    Medication = prescription.Medication,
                    Dosage = prescription.Dosage,
                    Instructions = prescription.Instructions
                });
            }

            return prescriptionsList;
        }

    }
}
