using HealthCare.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Repository
{
    public partial class CamcoDbContext : IdentityDbContext
    {
        public CamcoDbContext()
        {

        }

        public CamcoDbContext(DbContextOptions<CamcoDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<HealthCareChat> HealthCareChats { get; set; }
        public virtual DbSet<HealthCareDoctorSpecialization> HealthCareDoctorSpecializations { get; set; }
        public virtual DbSet<HealthCareExceptionLog> HealthCareExceptionLogs { get; set; }
        public virtual DbSet<HealthCareGender> HealthCareGenders { get; set; }
        public virtual DbSet<HealthCarePrescription> HealthCarePrescriptions { get; set; }
        public virtual DbSet<HealthCareUser> HealthCareUsers { get; set; }
        public virtual DbSet<HealthCareUserType> HealthCareUserTypes { get; set; }
        public virtual DbSet<HealthcareAppointment> HealthcareAppointments { get; set; }
        public virtual DbSet<HealthcareDoctor> HealthcareDoctors { get; set; }
        public virtual DbSet<HealthcareDoctorAvailibilitySchedule> HealthcareDoctorAvailibilitySchedules { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HealthCareChat>(entity =>
            {
                entity.ToTable("HealthCare_Chat");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.SeenDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.FromEmp)
                    .WithMany(p => p.HealthCareChatFromEmps)
                    .HasForeignKey(d => d.FromEmpId)
                    .HasConstraintName("FK_FromEmp");

                entity.HasOne(d => d.ToEmp)
                    .WithMany(p => p.HealthCareChatToEmps)
                    .HasForeignKey(d => d.ToEmpId)
                    .HasConstraintName("FK_ToEmp");
            });

            modelBuilder.Entity<HealthCareDoctorSpecialization>(entity =>
            {
                entity.ToTable("HealthCare_DoctorSpecialization");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
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

            modelBuilder.Entity<HealthCareUserType>(entity =>
            {
                entity.ToTable("HealthCare_UserTypes");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserType).HasMaxLength(255);
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
            base.OnModelCreating(modelBuilder);
        }
    }
}