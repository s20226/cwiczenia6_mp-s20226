using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CW8.Models;
using CW8.Services;
using CW8.Models.DTO;

namespace CW8.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDbService _dbService;
        public DoctorController(IDbService dbService)
        {
            _dbService = dbService;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctors = await _dbService.GetDoctor();

            return Ok(doctors);
        }

        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _dbService.GetDoctor(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

 
        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> PutDoctor(int idDoctor, DoctorDto doctor)
        {
            var isDocktorId = await _dbService.CheckDoctorId(idDoctor);

            if (!isDocktorId)
            {
                return NotFound();
            }

            await _dbService.ModifyDoctor(idDoctor, doctor);

            return Ok($"Doctor {idDoctor} updated");

        }


        [HttpPost]
        public async Task<IActionResult> PostDoctor(DoctorDto doctor)
        {
            await _dbService.AddDoctor(doctor);

            return Created("Doctor Created",doctor);
        }

 
        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {

            var isDocktorId = await _dbService.CheckDoctorId(idDoctor);

            if (!isDocktorId)
            {
                return NotFound();
            }

            await _dbService.RemoveDoctor(idDoctor);

            return Ok($"Doctor {idDoctor} removed.");
        }

    }
}
