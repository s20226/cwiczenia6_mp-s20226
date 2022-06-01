using System;
using System.Collections.Generic;

namespace CW8.Models.DTO
{
    public class PrescriptionDto
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }


        public PatientDto Patient { get; set; }

        public DoctorDto Doctor { get; set; }

        public IEnumerable<PrescriptionMedicamentDto> PrescriptionMedicaments { get; set; }
    }
}
