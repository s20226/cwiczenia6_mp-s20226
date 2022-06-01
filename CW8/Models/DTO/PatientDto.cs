using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Models.DTO
{
    public class PatientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public IEnumerable<PrescriptionDto> Prescriptions { get; set; }
    }
}
