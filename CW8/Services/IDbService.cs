using CW8.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CW8.Services
{
    public interface IDbService
    {
        public Task<IEnumerable<object>> GetDoctor();
        public Task<object> GetDoctor(int idDoctor);
        public Task AddDoctor(DoctorDto doctor);
        public Task ModifyDoctor(int idDoctor, DoctorDto doctor);
        public Task RemoveDoctor(int idDoctor);
        public Task<bool> CheckDoctorId(int idDoctor);
        public Task<PrescriptionDetailsDto> GetPrecriptionDetails(int idPrescription);
        public Task<bool> CheckPrescriptionId(int idPrescription);
    }
}
