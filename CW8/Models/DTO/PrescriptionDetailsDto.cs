using System.Collections.Generic;

namespace CW8.Models.DTO
{
    public class PrescriptionDetailsDto
    {
        public string Date { get; set; }
        public string DueDate { get; set; }
        public PatientDto Patient { get; set; }
        public DoctorDto Doctor { get; set; }
        public IEnumerable<PrescriptionMedicamentDto> PrescriptionMedicaments { get; set; }



    }
}
