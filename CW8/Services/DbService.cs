using CW8.Models;
using CW8.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;

        public DbService(MainDbContext mainDbContext)
        {
            _dbContext = mainDbContext;
        }

        public async Task AddDoctor(DoctorDto doctor)
        {
            await _dbContext.AddAsync(new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email,
                //    IdDoctor = await _dbContext.Doctors.MaxAsync(e => e.IdDoctor)+1

            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckDoctorId(int idDoctor)
        {
            return await _dbContext.Doctors.AnyAsync(e => e.IdDoctor == idDoctor);
        }

        public async Task<bool> CheckPrescriptionId(int idPrescription)
        {
            return await _dbContext.Prescriptions.AnyAsync(e => e.IdPrescription == idPrescription);
        }

        public async Task<IEnumerable<object>> GetDoctor()
        {
            return await _dbContext.Doctors
                 .Select(e => new DoctorDto
                 {
                     FirstName = e.FirstName,
                     LastName = e.LastName,
                     Email = e.Email

                 }).ToListAsync();
        }

        public async Task<object> GetDoctor(int idDoctor)
        {
            return await _dbContext.Doctors.Where(e => e.IdDoctor == idDoctor)
                .Select(d => new DoctorDto { FirstName = d.FirstName, LastName = d.LastName, Email = d.Email }).FirstOrDefaultAsync();
        }

        public async Task<PrescriptionDetailsDto> GetPrecriptionDetails(int idPrescription)
        {
            return await _dbContext.Prescriptions
                .Include(e => e.Doctor)
                .Include(e => e.Patient)
                .Include(e => e.PrescriptionMedicaments)
                .Where(e => e.IdPrescription == idPrescription)
                .Select(e => new PrescriptionDetailsDto
                {
                    Date = e.Date.ToString("D"),
                    DueDate = e.DueDate.ToString("D"),
                    Doctor = new DoctorDto { FirstName = e.Doctor.FirstName, LastName = e.Doctor.LastName, Email = e.Doctor.Email },
                    Patient = new PatientDto { FirstName = e.Patient.FirstName, LastName = e.Patient.LastName, BirthDate = e.Patient.BirthDate.ToString("D") },
                    PrescriptionMedicaments =
                    e.PrescriptionMedicaments
                    .Select(e => new PrescriptionMedicamentDto
                    {

                        MedicamentName = e.Medicament.Name,
                        Dose = e.Dose,
                        TypeMedicament = e.Medicament.Type,
                        Details = e.Details


                    }


                    ).ToList()

                }).FirstOrDefaultAsync();


        }

        public async Task ModifyDoctor(int idDoctor, DoctorDto doctor)
        {
            if (!await CheckDoctorId(idDoctor))
            {
                throw new System.Exception($"Wrong id {idDoctor} for Doctor to update");
            }

            var doctorToUpdate = await _dbContext.Doctors.FindAsync(idDoctor);

            doctorToUpdate.FirstName = doctor.FirstName;
            doctorToUpdate.LastName = doctor.LastName;
            doctorToUpdate.Email = doctor.Email;

            await _dbContext.SaveChangesAsync();

        }

        public async Task RemoveDoctor(int idDoctor)
        {
            if (!await CheckDoctorId(idDoctor))
            {
                throw new System.Exception($"Wrong id {idDoctor} for Doctor to Remove");
            }

            var doctorToRemove = await _dbContext.Doctors.FindAsync(idDoctor);
            _dbContext.Remove(doctorToRemove);
            await _dbContext.SaveChangesAsync();


        }
    }
}
