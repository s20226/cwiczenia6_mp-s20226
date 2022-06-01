using Microsoft.EntityFrameworkCore;
using System;

namespace CW8.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(e => e.IdPatient);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.BirthDate).IsRequired();

                p.HasData(new Patient
                {
                    IdPatient = 1,
                    FirstName = "Mati",
                    LastName = "Kowalski",
                    BirthDate = DateTime.Parse("2000-01-01")
                }, new Patient
                {
                    IdPatient = 2,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    BirthDate = DateTime.Parse("2000-01-01")
                });

            });
            modelBuilder.Entity<Doctor>(p =>
            {
                p.HasKey(e => e.IdDoctor);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.Email).IsRequired().HasMaxLength(100);

                p.HasData(
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "Julian",
                        LastName = "Bradford",
                        Email = "example@ex.com"
                    }, new Doctor
                    {
                        IdDoctor = 2,
                        FirstName = "Magdalena",
                        LastName = "Karpinska",
                        Email = "example@ex.com"
                    }

                    );

            });
            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasKey(e => e.IdPrescription);
                p.Property(e => e.Date).IsRequired();
                p.Property(e => e.DueDate).IsRequired();

                p.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                p.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);

                p.HasData(new Prescription
                {
                    IdPrescription = 1,
                    Date = DateTime.Now,
                    DueDate = DateTime.Parse("2025-01-01"),
                    IdPatient = 1,
                    IdDoctor = 1

                }, new Prescription
                {
                    IdPrescription = 2,
                    Date = DateTime.Now,
                    DueDate = DateTime.Parse("2025-01-01"),
                    IdPatient = 1,
                    IdDoctor = 2

                });
            });

            modelBuilder.Entity<PrescriptionMedicament>(p =>
            {

                p.HasKey(e => new { e.IdMedicament, e.IdPrescription });
                p.Property(e => e.Details).IsRequired().HasMaxLength(100);
                p.HasOne(e => e.Prescription).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdPrescription);
                p.HasOne(e => e.Medicament).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdMedicament);


                p.HasData(new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 2, Details = "2x1 wieczorem" },
                     new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 2, Details = "2x1 wieczorem" });
            });

            modelBuilder.Entity<Medicament>(p =>
            {
                p.HasKey(e => e.IdMedicament);
                p.Property(e => e.Name).IsRequired().HasMaxLength(100);
                p.Property(e => e.Description).IsRequired().HasMaxLength(100);
                p.Property(e => e.Type).IsRequired().HasMaxLength(100);

                p.HasData(new Medicament { IdMedicament = 1, Name = "Xanax", Description = "Lek na uspokojenie", Type = "tabletki" },
                    new Medicament { IdMedicament = 2, Name = "Tramadol", Description = "Lek przeciwbolowy", Type = "tabletki" });
            });


        }

    }
}
