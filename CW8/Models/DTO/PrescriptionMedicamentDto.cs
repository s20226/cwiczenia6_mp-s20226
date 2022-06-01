using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Models.DTO
{
    public class PrescriptionMedicamentDto
    {
        public int? Dose { get; set; }
        public string Details { get; set; }


        public PrescriptionDto Prescription { get; set; }
        public MedicamentDto Medicament { get; set; }
    }
}
