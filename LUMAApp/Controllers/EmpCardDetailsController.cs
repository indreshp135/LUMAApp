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
    public class EmpCardDetailsController : ControllerBase
    {
        private readonly Luma1Context _context;

        public EmpCardDetailsController(Luma1Context context)
        {
            _context = context;
        }

        // GET: api/EmpCardDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpCardDetail>>> GetEmpCardDetails()
        {
          if (_context.EmpCardDetails == null)
          {
              return NotFound();
          }
            return await _context.EmpCardDetails.ToListAsync();
        }

        // GET: api/EmpCardDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpCardDetail>> GetEmpCardDetail(string id)
        {
          if (_context.EmpCardDetails == null)
          {
              return NotFound();
          }
            var empCardDetail = await _context.EmpCardDetails.FindAsync(id);

            if (empCardDetail == null)
            {
                return NotFound();
            }

            return empCardDetail;
        }

        // PUT: api/EmpCardDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpCardDetail(string id, EmpCardDetail empCardDetail)
        {
            if (id != empCardDetail.LoanId)
            {
                return BadRequest();
            }

            _context.Entry(empCardDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpCardDetailExists(id))
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

        // POST: api/EmpCardDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpCardDetail>> PostEmpCardDetail(EmpCardDetail empCardDetail)
        {
          if (_context.EmpCardDetails == null)
          {
              return Problem("Entity set 'Luma1Context.EmpCardDetails'  is null.");
          }
            _context.EmpCardDetails.Add(empCardDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpCardDetailExists(empCardDetail.LoanId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpCardDetail", new { id = empCardDetail.LoanId }, empCardDetail);
        }

        // DELETE: api/EmpCardDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpCardDetail(string id)
        {
            if (_context.EmpCardDetails == null)
            {
                return NotFound();
            }
            var empCardDetail = await _context.EmpCardDetails.FindAsync(id);
            if (empCardDetail == null)
            {
                return NotFound();
            }

            _context.EmpCardDetails.Remove(empCardDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpCardDetailExists(string id)
        {
            return (_context.EmpCardDetails?.Any(e => e.LoanId == id)).GetValueOrDefault();
        }
    }
}
