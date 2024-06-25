﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMIAS_API.Models;
using System.Net.WebSockets;

namespace EMIAS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysDocumentsController : ControllerBase
    {
        private readonly EmiasDbContext _context;

        public AnalysDocumentsController(EmiasDbContext context)
        {
            _context = context;
        }

        // GET: api/AnalysDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalysDocument>>> GetAnalysDocuments()
        {
            return await _context.AnalysDocuments.ToListAsync();
        }

        // GET: api/AnalysDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalysDocument>> GetAnalysDocument(int? id)
        {
            var analysDocument = await _context.AnalysDocuments.FindAsync(id);

            if (analysDocument == null)
            {
                return NotFound();
            }

            return analysDocument;
        }
        [HttpGet("/api/[controller]/byappointment/{appointmentID}")]
        public async Task<ActionResult<IEnumerable<AnalysDocument>>> GetAnalysDocumentByAppointment(int appointmentID)
        {
            var analysDocuments = await _context.AnalysDocuments.OrderBy(doc => doc.IdAppointmentDocument == appointmentID).ToListAsync();

            if(analysDocuments == null)
            {
                return NotFound();
            }

            return analysDocuments;
        }
        [HttpGet("/api/[controller]/byoms/{oms}")]
        public async Task<ActionResult<IEnumerable<AnalysDocument>>> GetAnalysDocumentByOms(long oms)
        {
            var appointments = _context.Appointments.OrderBy(a => a.Oms == oms);
            var analysDocuments = await _context.AnalysDocuments.OrderBy(doc => appointments.Any(a => a.IdAppointment == doc.IdAppointmentDocument)).ToListAsync();

            if(analysDocuments == null)
            {
                return NotFound();
            }

            return analysDocuments;
        }

        // PUT: api/AnalysDocuments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalysDocument(int? id, AnalysDocument analysDocument)
        {
            if (id != analysDocument.IdAnalys)
            {
                return BadRequest();
            }

            _context.Entry(analysDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalysDocumentExists(id))
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

        // POST: api/AnalysDocuments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnalysDocument>> PostAnalysDocument(AnalysDocument analysDocument)
        {
            _context.AnalysDocuments.Add(analysDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalysDocument", new { id = analysDocument.IdAnalys }, analysDocument);
        }

        // DELETE: api/AnalysDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysDocument(int? id)
        {
            var analysDocument = await _context.AnalysDocuments.FindAsync(id);
            if (analysDocument == null)
            {
                return NotFound();
            }

            _context.AnalysDocuments.Remove(analysDocument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalysDocumentExists(int? id)
        {
            return _context.AnalysDocuments.Any(e => e.IdAnalys == id);
        }
    }
}
