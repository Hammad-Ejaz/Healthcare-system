using HealthCare.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Repository
{
    public partial class HealthCareDbContext : IdentityDbContext
    {
        public HealthCareDbContext()
        {

        }

        public HealthCareDbContext(DbContextOptions<HealthCareDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<HealthCareChat> HealthCareChats { get; set; }
        public virtual DbSet<HealthCareChatAudit> HealthCareChatAudits { get; set; }
        public virtual DbSet<HealthCareDoctorSpecialization> HealthCareDoctorSpecializations { get; set; }
        public virtual DbSet<HealthCareDoctorSpecializationAudit> HealthCareDoctorSpecializationAudits { get; set; }
        public virtual DbSet<HealthCareExceptionLog> HealthCareExceptionLogs { get; set; }
        public virtual DbSet<HealthCareGender> HealthCareGenders { get; set; }
        public virtual DbSet<HealthCareGendersAudit> HealthCareGendersAudits { get; set; }
        public virtual DbSet<HealthCarePrescription> HealthCarePrescriptions { get; set; }
        public virtual DbSet<HealthCarePrescriptionAudit> HealthCarePrescriptionAudits { get; set; }
        public virtual DbSet<HealthCareUser> HealthCareUsers { get; set; }
        public virtual DbSet<HealthCareUserAudit> HealthCareUserAudits { get; set; }
        public virtual DbSet<HealthCareUserType> HealthCareUserTypes { get; set; }
        public virtual DbSet<HealthCareUserTypesAudit> HealthCareUserTypesAudits { get; set; }
        public virtual DbSet<HealthcareAppointment> HealthcareAppointments { get; set; }
        public virtual DbSet<HealthcareAppointmentsAudit> HealthcareAppointmentsAudits { get; set; }
        public virtual DbSet<HealthcareDoctor> HealthcareDoctors { get; set; }
        public virtual DbSet<HealthcareDoctorAudit> HealthcareDoctorAudits { get; set; }
        public virtual DbSet<HealthcareDoctorAvailibilitySchedule> HealthcareDoctorAvailibilitySchedules { get; set; }
        public virtual DbSet<HealthcareDoctorAvailibilityScheduleAudit> HealthcareDoctorAvailibilityScheduleAudits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HealthCareChat>(entity =>
            {
                entity.ToTable("HealthCare_Chat");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.SeenDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.HealthCareChatFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .HasConstraintName("FK_FromEmp");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.HealthCareChatToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .HasConstraintName("FK_ToEmp");
            });

            modelBuilder.Entity<HealthCareChatAudit>(entity =>
            {
                entity.ToTable("HealthCare_Chat_Audit");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewActive).HasColumnName("New_Active");

                entity.Property(e => e.NewDocumentFile).HasColumnName("New_DocumentFile");

                entity.Property(e => e.NewEnteredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("New_EnteredDate");

                entity.Property(e => e.NewFromUserId).HasColumnName("New_FromUserId");

                entity.Property(e => e.NewImageFile).HasColumnName("New_ImageFile");

                entity.Property(e => e.NewIsSeen).HasColumnName("New_IsSeen");

                entity.Property(e => e.NewMessage).HasColumnName("New_Message");

                entity.Property(e => e.NewSeenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("New_SeenDate");

                entity.Property(e => e.NewToUserId).HasColumnName("New_ToUserId");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldDocumentFile).HasColumnName("Old_DocumentFile");

                entity.Property(e => e.OldEnteredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_EnteredDate");

                entity.Property(e => e.OldFromUserId).HasColumnName("Old_FromUserId");

                entity.Property(e => e.OldImageFile).HasColumnName("Old_ImageFile");

                entity.Property(e => e.OldIsSeen).HasColumnName("Old_IsSeen");

                entity.Property(e => e.OldMessage).HasColumnName("Old_Message");

                entity.Property(e => e.OldSeenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_SeenDate");

                entity.Property(e => e.OldToUserId).HasColumnName("Old_ToUserId");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.HealthCareChatAudits)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HealthCar__RowId__18B6AB08");
            });
            modelBuilder.Entity<HealthCareDoctorSpecialization>(entity =>
            {
                entity.ToTable("HealthCare_DoctorSpecialization");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<HealthCareDoctorSpecializationAudit>(entity =>
            {
                entity.ToTable("HealthCare_DoctorSpecialization_Audit");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewActive).HasColumnName("New_Active");

                entity.Property(e => e.NewDetail).HasColumnName("New_Detail");

                entity.Property(e => e.NewSpecialization)
                    .HasMaxLength(100)
                    .HasColumnName("New_Specialization");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldDetail).HasColumnName("Old_Detail");

                entity.Property(e => e.OldSpecialization)
                    .HasMaxLength(100)
                    .HasColumnName("Old_Specialization");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.HealthCareDoctorSpecializationAudits)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HealthCar__RowId__24285DB4");
            });

            modelBuilder.Entity<HealthCareExceptionLog>(entity =>
            {
                entity.ToTable("HealthCare_ExceptionLog");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExceptionType).HasMaxLength(255);

                entity.Property(e => e.LogTimestamp).HasColumnType("datetime");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.TableName).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<HealthCareGender>(entity =>
            {
                entity.ToTable("HealthCare_Genders");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.GenderType).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<HealthCareGendersAudit>(entity =>
            {
                entity.ToTable("HealthCare_Genders_Audit");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewActive).HasColumnName("New_Active");

                entity.Property(e => e.NewGenderType)
                    .HasMaxLength(50)
                    .HasColumnName("New_GenderType");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldGenderType)
                    .HasMaxLength(50)
                    .HasColumnName("Old_GenderType");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.HealthCareGendersAudits)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HealthCar__RowId__2BC97F7C");
            });

            modelBuilder.Entity<HealthCarePrescription>(entity =>
            {
                entity.ToTable("HealthCare_Prescription");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DatePrescribed).HasColumnType("date");

                entity.Property(e => e.Dosage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Instructions).IsUnicode(false);

                entity.Property(e => e.Medication)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.HealthCarePrescriptions)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__HealthCar__Docto__57DD0BE4");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.HealthCarePrescriptions)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__HealthCar__Patie__56E8E7AB");
            });

            modelBuilder.Entity<HealthCarePrescriptionAudit>(entity =>
            {
                entity.ToTable("HealthCare_Prescription_Audit");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewActive).HasColumnName("New_Active");

                entity.Property(e => e.NewDatePrescribed)
                    .HasColumnType("datetime")
                    .HasColumnName("New_DatePrescribed");

                entity.Property(e => e.NewDoctorId).HasColumnName("New_DoctorId");

                entity.Property(e => e.NewDosage)
                    .HasMaxLength(50)
                    .HasColumnName("New_Dosage");

                entity.Property(e => e.NewInstructions).HasColumnName("New_Instructions");

                entity.Property(e => e.NewMedication).HasColumnName("New_Medication");

                entity.Property(e => e.NewPatientId).HasColumnName("New_PatientId");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldDatePrescribed)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_DatePrescribed");

                entity.Property(e => e.OldDoctorId).HasColumnName("Old_DoctorId");

                entity.Property(e => e.OldDosage)
                    .HasMaxLength(50)
                    .HasColumnName("Old_Dosage");

                entity.Property(e => e.OldInstructions).HasColumnName("Old_Instructions");

                entity.Property(e => e.OldMedication).HasColumnName("Old_Medication");

                entity.Property(e => e.OldPatientId).HasColumnName("Old_PatientId");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.HealthCarePrescriptionAudits)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HealthCar__RowId__2F9A1060");
            });

            modelBuilder.Entity<HealthCareUser>(entity =>
            {
                entity.ToTable("HealthCare_User");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.HealthCareUsers)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Gender");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.HealthCareUsers)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_UserType");
            });

            modelBuilder.Entity<HealthCareUserAudit>(entity =>
            {
                entity.ToTable("HealthCare_User_Audit");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewActive).HasColumnName("New_Active");

                entity.Property(e => e.NewContactNumber)
                    .HasMaxLength(20)
                    .HasColumnName("New_ContactNumber");

                entity.Property(e => e.NewDateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("New_DateOfBirth");

                entity.Property(e => e.NewEmail)
                    .HasMaxLength(100)
                    .HasColumnName("New_Email");

                entity.Property(e => e.NewGenderId).HasColumnName("New_GenderId");

                entity.Property(e => e.NewPassword).HasColumnName("New_Password");

                entity.Property(e => e.NewUserTypeId).HasColumnName("New_userTypeId");

                entity.Property(e => e.NewUsername)
                    .HasMaxLength(50)
                    .HasColumnName("New_Username");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldContactNumber)
                    .HasMaxLength(20)
                    .HasColumnName("Old_ContactNumber");

                entity.Property(e => e.OldDateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Old_DateOfBirth");

                entity.Property(e => e.OldEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Old_Email");

                entity.Property(e => e.OldGenderId).HasColumnName("Old_GenderId");

                entity.Property(e => e.OldPassword).HasColumnName("Old_Password");

                entity.Property(e => e.OldUserTypeId).HasColumnName("Old_userTypeId");

                entity.Property(e => e.OldUsername)
                    .HasMaxLength(50)
                    .HasColumnName("Old_Username");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.HealthCareUserAudits)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HealthCar__RowId__336AA144");
            });

            modelBuilder.Entity<HealthCareUserType>(entity =>
            {
                entity.ToTable("HealthCare_UserTypes");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserType).HasMaxLength(255);
            });

            modelBuilder.Entity<HealthCareUserTypesAudit>(entity =>
            {
                entity.ToTable("HealthCare_UserTypes_Audit");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewActive).HasColumnName("New_Active");

                entity.Property(e => e.NewUserType)
                    .HasMaxLength(50)
                    .HasColumnName("New_UserType");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldUserType)
                    .HasMaxLength(50)
                    .HasColumnName("Old_UserType");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.HealthCareUserTypesAudits)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HealthCar__RowId__373B3228");
            });

            modelBuilder.Entity<HealthcareAppointment>(entity =>
            {
                entity.ToTable("Healthcare_Appointments");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.HealthcareAppointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_DoctorsId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.HealthcareAppointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientId");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.HealthcareAppointments)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK_ScheduleId");
            });

            modelBuilder.Entity<HealthcareAppointmentsAudit>(entity =>
            {
                entity.ToTable("Healthcare_Appointments_Audit");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewActive).HasColumnName("New_Active");

                entity.Property(e => e.NewAppointmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("New_AppointmentDate");

                entity.Property(e => e.NewDescription).HasColumnName("New_Description");

                entity.Property(e => e.NewDoctorId).HasColumnName("New_DoctorId");

                entity.Property(e => e.NewImages).HasColumnName("New_Images");

                entity.Property(e => e.NewIsApproved).HasColumnName("New_IsApproved");

                entity.Property(e => e.NewPatientId).HasColumnName("New_PatientId");

                entity.Property(e => e.NewScheduleId).HasColumnName("New_ScheduleId");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldAppointmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_AppointmentDate");

                entity.Property(e => e.OldDescription).HasColumnName("Old_Description");

                entity.Property(e => e.OldDoctorId).HasColumnName("Old_DoctorId");

                entity.Property(e => e.OldImages).HasColumnName("Old_Images");

                entity.Property(e => e.OldIsApproved).HasColumnName("Old_IsApproved");

                entity.Property(e => e.OldPatientId).HasColumnName("Old_PatientId");

                entity.Property(e => e.OldScheduleId).HasColumnName("Old_ScheduleId");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.HealthcareAppointmentsAudits)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Healthcar__RowId__14E61A24");
            });

            modelBuilder.Entity<HealthcareDoctor>(entity =>
            {
                entity.ToTable("Healthcare_Doctor");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.HealthcareDoctors)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK_Healthcare_Doctor_SpecializationId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HealthcareDoctors)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Healthcare_Doctor_UserId");
            });

            modelBuilder.Entity<HealthcareDoctorAudit>(entity =>
            {
                entity.ToTable("Healthcare_Doctor_Audit");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewActive).HasColumnName("New_Active");

                entity.Property(e => e.NewMedicalLicenseInfo).HasColumnName("New_MedicalLicenseInfo");

                entity.Property(e => e.NewSpecializationId).HasColumnName("New_SpecializationId");

                entity.Property(e => e.NewUserId).HasColumnName("New_UserId");

                entity.Property(e => e.NewWorkExperience).HasColumnName("New_WorkExperience");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldMedicalLicenseInfo).HasColumnName("Old_MedicalLicenseInfo");

                entity.Property(e => e.OldSpecializationId).HasColumnName("Old_SpecializationId");

                entity.Property(e => e.OldUserId).HasColumnName("Old_UserId");

                entity.Property(e => e.OldWorkExperience).HasColumnName("Old_WorkExperience");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.HealthcareDoctorAudits)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Healthcar__RowId__1C873BEC");
            });

            modelBuilder.Entity<HealthcareDoctorAvailibilitySchedule>(entity =>
            {
                entity.ToTable("Healthcare_DoctorAvailibilitySchedule");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DayOfWeek)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.HealthcareDoctorAvailibilitySchedules)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_DoctorId");
            });

            modelBuilder.Entity<HealthcareDoctorAvailibilityScheduleAudit>(entity =>
            {
                entity.ToTable("Healthcare_DoctorAvailibilitySchedule_Audit");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewActive).HasColumnName("New_Active");

                entity.Property(e => e.NewDayOfWeek)
                    .HasMaxLength(50)
                    .HasColumnName("New_DayOfWeek");

                entity.Property(e => e.NewDoctorId).HasColumnName("New_DoctorId");

                entity.Property(e => e.NewTime)
                    .HasMaxLength(50)
                    .HasColumnName("New_Time");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldDayOfWeek)
                    .HasMaxLength(50)
                    .HasColumnName("Old_DayOfWeek");

                entity.Property(e => e.OldDoctorId).HasColumnName("Old_DoctorId");

                entity.Property(e => e.OldTime)
                    .HasMaxLength(50)
                    .HasColumnName("Old_Time");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.HealthcareDoctorAvailibilityScheduleAudits)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Healthcar__RowId__2057CCD0");
            }); base.OnModelCreating(modelBuilder);
        }
    }
}