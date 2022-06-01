using System.Collections.Generic;

namespace CW8.Models.DTO
{
    public class MedicamentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }


        public IEnumerable<PrescriptionMedicamentDto> PrescriptionMedicaments { get; set; }
    }
}
