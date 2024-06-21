using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMIAS_API.Models;
using NuGet.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.JSInterop;

namespace EMIAS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly EmiasDbContext _context;

        public AppointmentsController(EmiasDbContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }
        // GET: api/Appointments
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetActiveAppointments()
        {
            return await _context.Appointments.OrderBy(a => isAppointmentActive(a.AppointmentDate, a.AppoinmentTime) && (a.IdStatus == null || a.IdStatus == 0)).ToListAsync();
        }
        // GET: api/Appointments
        [HttpGet("archived")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetArchivedAppointments()
        {
            return await _context.Appointments.OrderBy(a => !isAppointmentActive(a.AppointmentDate, a.AppoinmentTime) && (a.IdStatus == null || a.IdStatus == 0)).ToListAsync();
        }
        // GET: api/Appointments
        [HttpPost("busytime/{id}")]
        public async Task<ActionResult<IEnumerable<TimeOnly>>> GetBusyTimeForDoctor(int? id, DateOnly date)
        {
            var doctors = await _context.Appointments.OrderBy(a => a.IdDoctor == id && a.AppointmentDate.Equals(date)).Select(a => a.AppoinmentTime).ToListAsync();
            if (doctors == null)
                return NotFound();
            else
                return doctors;
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int? id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int? id, Appointment appointment)
        {
            if (id != appointment.IdAppointment)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.IdAppointment }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int? id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(int? id)
        {
            return _context.Appointments.Any(e => e.IdAppointment == id);
        }
        private bool isAppointmentActive(DateOnly appDate, TimeOnly appTime)
        {
            var date = DateTime.Now;
            return (appDate.Year > date.Year) ||
            (appDate.Year == date.Year && appDate.Month > date.Month) ||
            (appDate.Year == date.Year && appDate.Month == date.Month && appDate.Day > date.Day) ||
            (appDate.Year == date.Year && appDate.Month == date.Month && appDate.Day == date.Day && appTime.Ticks > date.TimeOfDay.Ticks);
        }
    }

}
