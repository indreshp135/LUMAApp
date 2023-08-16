using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LUMAApp.Entities;

namespace LUMAApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpIssueDetailsController : ControllerBase
    {
        private readonly Luma1Context _context;

        public EmpIssueDetailsController(Luma1Context context)
        {
            _context = context;
        }

        // GET: api/EmpIssueDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpIssueDetail>>> GetEmpIssueDetails()
        {
          if (_context.EmpIssueDetails == null)
          {
              return NotFound();
          }
            return await _context.EmpIssueDetails.ToListAsync();
        }

        // GET: api/EmpIssueDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpIssueDetail>> GetEmpIssueDetail(string id)
        {
          if (_context.EmpIssueDetails == null)
          {
              return NotFound();
          }
            var empIssueDetail = await _context.EmpIssueDetails.FindAsync(id);

            if (empIssueDetail == null)
            {
                return NotFound();
            }

            return empIssueDetail;
        }

        // PUT: api/EmpIssueDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpIssueDetail(string id, EmpIssueDetail empIssueDetail)
        {
            if (id != empIssueDetail.IssueId)
            {
                return BadRequest();
            }

            _context.Entry(empIssueDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpIssueDetailExists(id))
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

        // POST: api/EmpIssueDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpIssueDetail>> PostEmpIssueDetail(EmpIssueDetail empIssueDetail)
        {
          if (_context.EmpIssueDetails == null)
          {
              return Problem("Entity set 'Luma1Context.EmpIssueDetails'  is null.");
          }
            _context.EmpIssueDetails.Add(empIssueDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpIssueDetailExists(empIssueDetail.IssueId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpIssueDetail", new { id = empIssueDetail.IssueId }, empIssueDetail);
        }

        // DELETE: api/EmpIssueDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpIssueDetail(string id)
        {
            if (_context.EmpIssueDetails == null)
            {
                return NotFound();
            }
            var empIssueDetail = await _context.EmpIssueDetails.FindAsync(id);
            if (empIssueDetail == null)
            {
                return NotFound();
            }

            _context.EmpIssueDetails.Remove(empIssueDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpIssueDetailExists(string id)
        {
            return (_context.EmpIssueDetails?.Any(e => e.IssueId == id)).GetValueOrDefault();
        }
    }
}
