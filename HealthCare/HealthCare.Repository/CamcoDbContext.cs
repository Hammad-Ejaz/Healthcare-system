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

        public virtual DbSet<AppointmentTable> AppointmentTables { get; set; }
        public virtual DbSet<AppointmentTableAudit> AppointmentTableAudits { get; set; }
        public virtual DbSet<DiscussionTable> DiscussionTables { get; set; }
        public virtual DbSet<DiscussionTableAudit> DiscussionTableAudits { get; set; }
        public virtual DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public virtual DbSet<HealthCareDoctorSpecialization> HealthCareDoctorSpecializations { get; set; }
        public virtual DbSet<HealthCareGender> HealthCareGenders { get; set; }
        public virtual DbSet<HealthCareUser> HealthCareUsers { get; set; }
        public virtual DbSet<HealthcareDoctor> HealthcareDoctors { get; set; }
        public virtual DbSet<HealthcareProviderTable> HealthcareProviderTables { get; set; }
        public virtual DbSet<HealthcareProviderTableAudit> HealthcareProviderTableAudits { get; set; }
        public virtual DbSet<NotificationTable> NotificationTables { get; set; }
        public virtual DbSet<PaymentTable> PaymentTables { get; set; }
        public virtual DbSet<PaymentTableAudit> PaymentTableAudits { get; set; }
        public virtual DbSet<PrescriptionTable> PrescriptionTables { get; set; }
        public virtual DbSet<PrescriptionTableAudit> PrescriptionTableAudits { get; set; }
        public virtual DbSet<ProviderHistoryTable> ProviderHistoryTables { get; set; }
        public virtual DbSet<ProviderHistoryTableAudit> ProviderHistoryTableAudits { get; set; }
        public virtual DbSet<ReviewTable> ReviewTables { get; set; }
        public virtual DbSet<ReviewTableAudit> ReviewTableAudits { get; set; }
        public virtual DbSet<StatusTable> StatusTables { get; set; }
        public virtual DbSet<UserProfileTable> UserProfileTables { get; set; }
        public virtual DbSet<UserProfileTableAudit> UserProfileTableAudits { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }
        public virtual DbSet<UserTableNew> UserTableNews { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AppointmentTable>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__Appointm__8ECDFCA2BA03BB7D");

                entity.ToTable("AppointmentTable");

                entity.Property(e => e.AppointmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("AppointmentID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.PatientUser)
                    .WithMany(p => p.AppointmentTables)
                    .HasForeignKey(d => d.PatientUserId)
                    .HasConstraintName("FK__Appointme__Patie__534D60F1");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.AppointmentTables)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__Appointme__Provi__5441852A");
            });

            modelBuilder.Entity<AppointmentTableAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("PK__Appointm__A17F23B8C45D1C32");

                entity.ToTable("AppointmentTable_Audit");

                entity.Property(e => e.AuditId)
                    .ValueGeneratedNever()
                    .HasColumnName("AuditID");

                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");

                entity.Property(e => e.AuditAction).HasMaxLength(50);

                entity.Property(e => e.AuditTimestamp).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_CreatedAt");

                entity.Property(e => e.OldDate)
                    .HasColumnType("date")
                    .HasColumnName("Old_Date");

                entity.Property(e => e.OldOtherRelevantDetails).HasColumnName("Old_OtherRelevantDetails");

                entity.Property(e => e.OldPatientUserId).HasColumnName("Old_PatientUserID");

                entity.Property(e => e.OldPrescriptionRefillRequested).HasColumnName("Old_PrescriptionRefillRequested");

                entity.Property(e => e.OldProviderId).HasColumnName("Old_ProviderID");

                entity.Property(e => e.OldReason).HasColumnName("Old_Reason");

                entity.Property(e => e.OldTime).HasColumnName("Old_Time");

                entity.Property(e => e.OldUpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_UpdatedAt");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OldPatientUser)
                    .WithMany(p => p.AppointmentTableAuditOldPatientUsers)
                    .HasForeignKey(d => d.OldPatientUserId)
                    .HasConstraintName("FK__Appointme__Old_P__06CD04F7");

                entity.HasOne(d => d.OldProvider)
                    .WithMany(p => p.AppointmentTableAudits)
                    .HasForeignKey(d => d.OldProviderId)
                    .HasConstraintName("FK__Appointme__Old_P__05D8E0BE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppointmentTableAuditUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Appointme__UserI__04E4BC85");
            });

            modelBuilder.Entity<DiscussionTable>(entity =>
            {
                entity.HasKey(e => e.DiscussionId)
                    .HasName("PK__Discussi__7E8E3920BA2734A2");

                entity.ToTable("DiscussionTable");

                entity.Property(e => e.DiscussionId)
                    .ValueGeneratedNever()
                    .HasColumnName("DiscussionID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.PatientUser)
                    .WithMany(p => p.DiscussionTables)
                    .HasForeignKey(d => d.PatientUserId)
                    .HasConstraintName("FK__Discussio__Patie__5DCAEF64");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.DiscussionTables)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__Discussio__Provi__5EBF139D");
            });

            modelBuilder.Entity<DiscussionTableAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("PK__Discussi__A17F23B81DA092D2");

                entity.ToTable("DiscussionTable_Audit");

                entity.Property(e => e.AuditId)
                    .ValueGeneratedNever()
                    .HasColumnName("AuditID");

                entity.Property(e => e.AuditAction).HasMaxLength(50);

                entity.Property(e => e.AuditTimestamp).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DiscussionId).HasColumnName("DiscussionID");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_CreatedAt");

                entity.Property(e => e.OldMessage).HasColumnName("Old_Message");

                entity.Property(e => e.OldPatientUserId).HasColumnName("Old_PatientUserID");

                entity.Property(e => e.OldProviderId).HasColumnName("Old_ProviderID");

                entity.Property(e => e.OldTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_Timestamp");

                entity.Property(e => e.OldUpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_UpdatedAt");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OldPatientUser)
                    .WithMany(p => p.DiscussionTableAuditOldPatientUsers)
                    .HasForeignKey(d => d.OldPatientUserId)
                    .HasConstraintName("FK__Discussio__Old_P__10566F31");

                entity.HasOne(d => d.OldProvider)
                    .WithMany(p => p.DiscussionTableAudits)
                    .HasForeignKey(d => d.OldProviderId)
                    .HasConstraintName("FK__Discussio__Old_P__0F624AF8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DiscussionTableAuditUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Discussio__UserI__0E6E26BF");
            });

            modelBuilder.Entity<ExceptionLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__Exceptio__5E5499A86B47E1A9");

                entity.ToTable("ExceptionLog");

                entity.Property(e => e.LogId)
                    .ValueGeneratedNever()
                    .HasColumnName("LogID");

                entity.Property(e => e.ExceptionType).HasMaxLength(255);

                entity.Property(e => e.LogTimestamp).HasColumnType("datetime");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.TableName).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<HealthCareDoctorSpecialization>(entity =>
            {
                entity.ToTable("HealthCare_DoctorSpecialization");
            });

            modelBuilder.Entity<HealthCareGender>(entity =>
            {
                entity.ToTable("HealthCare_Genders");

                entity.Property(e => e.GenderType).HasMaxLength(255);
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

            modelBuilder.Entity<HealthcareProviderTable>(entity =>
            {
                entity.ToTable("HealthcareProviderTable");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.HealthcareProviderTables)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK_Specialization");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HealthcareProviderTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Healthcar__UserI__3F466844");
            });

            modelBuilder.Entity<HealthcareProviderTableAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("PK__Healthca__A17F23B82C530B9C");

                entity.ToTable("HealthcareProviderTable_Audit");

                entity.Property(e => e.AuditId)
                    .ValueGeneratedNever()
                    .HasColumnName("AuditID");

                entity.Property(e => e.AuditAction).HasMaxLength(50);

                entity.Property(e => e.AuditTimestamp).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_CreatedAt");

                entity.Property(e => e.OldLocation)
                    .HasMaxLength(255)
                    .HasColumnName("Old_Location");

                entity.Property(e => e.OldSpecialties).HasColumnName("Old_Specialties");

                entity.Property(e => e.OldUpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_UpdatedAt");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HealthcareProviderTableAudits)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Healthcar__UserI__02084FDA");
            });

            modelBuilder.Entity<NotificationTable>(entity =>
            {
                entity.HasKey(e => e.NotificationId)
                    .HasName("PK__Notifica__20CF2E3293633B66");

                entity.ToTable("NotificationTable");

                entity.Property(e => e.NotificationId)
                    .ValueGeneratedNever()
                    .HasColumnName("NotificationID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NotificationTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__UserI__5AEE82B9");
            });

            modelBuilder.Entity<PaymentTable>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__PaymentT__9B556A586A6AF199");

                entity.ToTable("PaymentTable");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.PatientUser)
                    .WithMany(p => p.PaymentTables)
                    .HasForeignKey(d => d.PatientUserId)
                    .HasConstraintName("FK__PaymentTa__Patie__571DF1D5");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.PaymentTables)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__PaymentTa__Provi__5812160E");
            });

            modelBuilder.Entity<PaymentTableAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("PK__PaymentT__A17F23B880CF0E0C");

                entity.ToTable("PaymentTable_Audit");

                entity.Property(e => e.AuditId)
                    .ValueGeneratedNever()
                    .HasColumnName("AuditID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AuditAction).HasMaxLength(50);

                entity.Property(e => e.AuditTimestamp).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Old_Amount");

                entity.Property(e => e.OldCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_CreatedAt");

                entity.Property(e => e.OldPatientUserId).HasColumnName("Old_PatientUserID");

                entity.Property(e => e.OldPaymentMethod)
                    .HasMaxLength(50)
                    .HasColumnName("Old_PaymentMethod");

                entity.Property(e => e.OldProviderId).HasColumnName("Old_ProviderID");

                entity.Property(e => e.OldTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_Timestamp");

                entity.Property(e => e.OldUpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_UpdatedAt");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OldPatientUser)
                    .WithMany(p => p.PaymentTableAuditOldPatientUsers)
                    .HasForeignKey(d => d.OldPatientUserId)
                    .HasConstraintName("FK__PaymentTa__Old_P__0B91BA14");

                entity.HasOne(d => d.OldProvider)
                    .WithMany(p => p.PaymentTableAudits)
                    .HasForeignKey(d => d.OldProviderId)
                    .HasConstraintName("FK__PaymentTa__Old_P__0A9D95DB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentTableAuditUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__PaymentTa__UserI__09A971A2");
            });

            modelBuilder.Entity<PrescriptionTable>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId)
                    .HasName("PK__Prescrip__40130812C47AC112");

                entity.ToTable("PrescriptionTable");

                entity.Property(e => e.PrescriptionId)
                    .ValueGeneratedNever()
                    .HasColumnName("PrescriptionID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DatePrescribed).HasColumnType("date");

                entity.Property(e => e.Dosage).HasMaxLength(255);

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.PatientUser)
                    .WithMany(p => p.PrescriptionTables)
                    .HasForeignKey(d => d.PatientUserId)
                    .HasConstraintName("FK__Prescript__Patie__4F7CD00D");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.PrescriptionTables)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__Prescript__Provi__5070F446");
            });

            modelBuilder.Entity<PrescriptionTableAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("PK__Prescrip__A17F23B84B22B94F");

                entity.ToTable("PrescriptionTable_Audit");

                entity.Property(e => e.AuditId)
                    .ValueGeneratedNever()
                    .HasColumnName("AuditID");

                entity.Property(e => e.AuditAction).HasMaxLength(50);

                entity.Property(e => e.AuditTimestamp).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DatePrescribed).HasColumnType("date");

                entity.Property(e => e.Dosage).HasMaxLength(255);

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_CreatedAt");

                entity.Property(e => e.OldDatePrescribed)
                    .HasColumnType("date")
                    .HasColumnName("Old_DatePrescribed");

                entity.Property(e => e.OldDosage)
                    .HasMaxLength(255)
                    .HasColumnName("Old_Dosage");

                entity.Property(e => e.OldInstructions).HasColumnName("Old_Instructions");

                entity.Property(e => e.OldMedication).HasColumnName("Old_Medication");

                entity.Property(e => e.OldPatientUserId).HasColumnName("Old_PatientUserID");

                entity.Property(e => e.OldProviderId).HasColumnName("Old_ProviderID");

                entity.Property(e => e.OldUpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_UpdatedAt");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OldPatientUser)
                    .WithMany(p => p.PrescriptionTableAuditOldPatientUsers)
                    .HasForeignKey(d => d.OldPatientUserId)
                    .HasConstraintName("FK__Prescript__Old_P__7C4F7684");

                entity.HasOne(d => d.OldProvider)
                    .WithMany(p => p.PrescriptionTableAudits)
                    .HasForeignKey(d => d.OldProviderId)
                    .HasConstraintName("FK__Prescript__Old_P__7B5B524B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PrescriptionTableAuditUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Prescript__UserI__7A672E12");
            });

            modelBuilder.Entity<ProviderHistoryTable>(entity =>
            {
                entity.HasKey(e => e.ProviderHistoryId)
                    .HasName("PK__Provider__83A82835A32A27BF");

                entity.ToTable("ProviderHistoryTable");

                entity.Property(e => e.ProviderHistoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProviderHistoryID");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.PatientUser)
                    .WithMany(p => p.ProviderHistoryTables)
                    .HasForeignKey(d => d.PatientUserId)
                    .HasConstraintName("FK__ProviderH__Patie__45F365D3");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ProviderHistoryTables)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__ProviderH__Provi__44FF419A");
            });

            modelBuilder.Entity<ProviderHistoryTableAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("PK__Provider__A17F23B8BA26B03F");

                entity.ToTable("ProviderHistoryTable_Audit");

                entity.Property(e => e.AuditId)
                    .ValueGeneratedNever()
                    .HasColumnName("AuditID");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.AuditAction).HasMaxLength(50);

                entity.Property(e => e.AuditTimestamp).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.OldAction)
                    .HasMaxLength(50)
                    .HasColumnName("Old_Action");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_CreatedAt");

                entity.Property(e => e.OldDetails).HasColumnName("Old_Details");

                entity.Property(e => e.OldPatientUserId).HasColumnName("Old_PatientUserID");

                entity.Property(e => e.OldProviderHistoryId).HasColumnName("Old_ProviderHistoryID");

                entity.Property(e => e.OldProviderId).HasColumnName("Old_ProviderID");

                entity.Property(e => e.OldTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_Timestamp");

                entity.Property(e => e.OldUpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_UpdatedAt");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.ProviderHistoryId).HasColumnName("ProviderHistoryID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OldPatientUser)
                    .WithMany(p => p.ProviderHistoryTableAuditOldPatientUsers)
                    .HasForeignKey(d => d.OldPatientUserId)
                    .HasConstraintName("FK__ProviderH__Old_P__71D1E811");

                entity.HasOne(d => d.OldProvider)
                    .WithMany(p => p.ProviderHistoryTableAudits)
                    .HasForeignKey(d => d.OldProviderId)
                    .HasConstraintName("FK__ProviderH__Old_P__70DDC3D8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProviderHistoryTableAuditUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ProviderH__UserI__6FE99F9F");
            });

            modelBuilder.Entity<ReviewTable>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__ReviewTa__74BC79AEF2F25537");

                entity.ToTable("ReviewTable");

                entity.Property(e => e.ReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("ReviewID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.PatientUser)
                    .WithMany(p => p.ReviewTables)
                    .HasForeignKey(d => d.PatientUserId)
                    .HasConstraintName("FK__ReviewTab__Patie__4AB81AF0");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ReviewTables)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__ReviewTab__Provi__4BAC3F29");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ReviewTables)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__ReviewTab__Statu__4CA06362");
            });

            modelBuilder.Entity<ReviewTableAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("PK__ReviewTa__A17F23B83F68E23F");

                entity.ToTable("ReviewTable_Audit");

                entity.Property(e => e.AuditId)
                    .ValueGeneratedNever()
                    .HasColumnName("AuditID");

                entity.Property(e => e.AuditAction).HasMaxLength(50);

                entity.Property(e => e.AuditTimestamp).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldComment).HasColumnName("Old_Comment");

                entity.Property(e => e.OldCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_CreatedAt");

                entity.Property(e => e.OldPatientUserId).HasColumnName("Old_PatientUserID");

                entity.Property(e => e.OldProviderId).HasColumnName("Old_ProviderID");

                entity.Property(e => e.OldRating).HasColumnName("Old_Rating");

                entity.Property(e => e.OldStatusId).HasColumnName("Old_StatusID");

                entity.Property(e => e.OldTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_Timestamp");

                entity.Property(e => e.OldUpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_UpdatedAt");

                entity.Property(e => e.PatientUserId).HasColumnName("PatientUserID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OldPatientUser)
                    .WithMany(p => p.ReviewTableAuditOldPatientUsers)
                    .HasForeignKey(d => d.OldPatientUserId)
                    .HasConstraintName("FK__ReviewTab__Old_P__76969D2E");

                entity.HasOne(d => d.OldProvider)
                    .WithMany(p => p.ReviewTableAudits)
                    .HasForeignKey(d => d.OldProviderId)
                    .HasConstraintName("FK__ReviewTab__Old_P__75A278F5");

                entity.HasOne(d => d.OldStatus)
                    .WithMany(p => p.ReviewTableAudits)
                    .HasForeignKey(d => d.OldStatusId)
                    .HasConstraintName("FK__ReviewTab__Old_S__778AC167");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewTableAuditUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ReviewTab__UserI__74AE54BC");
            });

            modelBuilder.Entity<StatusTable>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__StatusTa__C8EE2043BAACCCFA");

                entity.ToTable("StatusTable");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("StatusID");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserProfileTable>(entity =>
            {
                entity.HasKey(e => e.UserProfileId)
                    .HasName("PK__UserProf__9E267F42CB9AE363");

                entity.ToTable("UserProfileTable");

                entity.Property(e => e.UserProfileId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserProfileID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfileTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserProfi__UserI__4222D4EF");
            });

            modelBuilder.Entity<UserProfileTableAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("PK__UserProf__A17F23B89594BE19");

                entity.ToTable("UserProfileTable_Audit");

                entity.Property(e => e.AuditId)
                    .ValueGeneratedNever()
                    .HasColumnName("AuditID");

                entity.Property(e => e.AuditAction).HasMaxLength(50);

                entity.Property(e => e.AuditTimestamp).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.OldActive).HasColumnName("Old_Active");

                entity.Property(e => e.OldCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_CreatedAt");

                entity.Property(e => e.OldFullName)
                    .HasMaxLength(255)
                    .HasColumnName("Old_FullName");

                entity.Property(e => e.OldMedicalHistory).HasColumnName("Old_MedicalHistory");

                entity.Property(e => e.OldOtherProfileDetails).HasColumnName("Old_OtherProfileDetails");

                entity.Property(e => e.OldUpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_UpdatedAt");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserProfileId).HasColumnName("UserProfileID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfileTableAudits)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserProfi__UserI__7F2BE32F");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.ToTable("UserTable");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContactNumber).HasMaxLength(20);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_UserTable_Gender");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_UserTable_UserTypes");
            });

            modelBuilder.Entity<UserTableNew>(entity =>
            {
                entity.ToTable("UserTable_New");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

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
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UserType1)
                    .HasMaxLength(255)
                    .HasColumnName("UserType");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}