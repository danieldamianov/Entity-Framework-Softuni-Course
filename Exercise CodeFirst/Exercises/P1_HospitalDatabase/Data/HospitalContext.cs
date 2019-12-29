using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    using Models;

    public class HospitalContext : DbContext
    {
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B3I8JPR\\SQLEXPRESS;Database=HospitalDb;Integrated Security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePatient(modelBuilder);
            ConfigureVisitation(modelBuilder);
            ConfigureDiagnose(modelBuilder);
            ConfigureMedicament(modelBuilder);
            ConfigurePatientMedicament(modelBuilder);
            ConfigureDoctor(modelBuilder);

            //        Visitation:
            // VisitationId
            // Date
            // Comments(up to 250 characters, unicode)
            // Patient

            // Diagnose:
            // DiagnoseId
            // Name(up to 50 characters, unicode)
            // Comments(up to 250 characters, unicode)
            // Patient

            // Medicament:
            // MedicamentId
            // Name(up to 50 characters, unicode)

            // PatientMedicament – mapping class between Patients and Medicaments


        }

        private void ConfigureDoctor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.DoctorId);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Specialty)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();
        }

        private void ConfigurePatientMedicament(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(pm => new { pm.PatientId , pm.MedicamentId});

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.PatientId);

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);
        }

        private void ConfigureMedicament(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>()
                .HasKey(m => m.MedicamentId);

            modelBuilder.Entity<Medicament>()
                .Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();
        }

        private void ConfigureDiagnose(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>()
                .HasKey(d => d.DiagnoseId);

            modelBuilder.Entity<Diagnose>()
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Diagnose>()
                .Property(d => d.Comments)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();
        }

        private void ConfigureVisitation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitation>()
                .HasKey(v => v.VisitationId);

            modelBuilder.Entity<Visitation>()
                .Property(v => v.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder.Entity<Visitation>()
                .HasOne(v => v.Doctor)
                .WithMany(d => d.Visitations)
                .HasForeignKey(v => v.DoctorId);
                
        }

        private static void ConfigurePatient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                 .HasKey(d => d.PatientId);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(v => v.Patient)
                .HasForeignKey(v => v.PatientId);

            modelBuilder.Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}
