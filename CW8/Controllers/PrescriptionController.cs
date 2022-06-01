using CW8.Models;
using CW8.Models.DTO;
using CW8.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CW8.Controllers
{
    [Route("api/prescription")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IDbService _dbService;
        public PrescriptionController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{idPrescription}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetPrescriptionDetails(int idPrescription)
        {

            if (!await _dbService.CheckPrescriptionId(idPrescription))
            { return NotFound($"Not Found prescription with id: {idPrescription}"); }
            PrescriptionDetailsDto prescriptionDetailsDto = await _dbService.GetPrecriptionDetails(idPrescription);

            return Ok(prescriptionDetailsDto);
        }

    }
}
