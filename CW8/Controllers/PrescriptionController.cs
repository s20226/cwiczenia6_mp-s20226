using CW8.Models;
using CW8.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<IEnumerable<Doctor>>> GetPrescription(int idPrescription)
        {
            

            return Ok("OK");
        }

    }
}
