using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LUMAApp.Entities;
using Microsoft.AspNetCore.Authorization;

namespace LUMAApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class LoanCardMastersController : ControllerBase
    {
        private readonly Luma1Context _context;

        public LoanCardMastersController(Luma1Context context)
        {
            _context = context;
        }

        // GET: api/LoanCardMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanCardMaster>>> GetLoanCardMasters()
        {
          if (_context.LoanCardMasters == null)
          {
              return NotFound();
          }
            return await _context.LoanCardMasters.ToListAsync();
        }

        // GET: api/LoanCardMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanCardMaster>> GetLoanCardMaster(string id)
        {
          if (_context.LoanCardMasters == null)
          {
              return NotFound();
          }
            var loanCardMaster = await _context.LoanCardMasters.FindAsync(id);

            if (loanCardMaster == null)
            {
                return NotFound();
            }

            return loanCardMaster;
        }

        // PUT: api/LoanCardMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanCardMaster(string id, LoanCardMaster loanCardMaster)
        {
            if (id != loanCardMaster.LoanId)
            {
                return BadRequest();
            }

            _context.Entry(loanCardMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanCardMasterExists(id))
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

        // POST: api/LoanCardMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanCardMaster>> PostLoanCardMaster(LoanCardMaster loanCardMaster)
        {
          if (_context.LoanCardMasters == null)
          {
              return Problem("Entity set 'Luma1Context.LoanCardMasters'  is null.");
          }
            _context.LoanCardMasters.Add(loanCardMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoanCardMasterExists(loanCardMaster.LoanId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoanCardMaster", new { id = loanCardMaster.LoanId }, loanCardMaster);
        }

        // DELETE: api/LoanCardMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanCardMaster(string id)
        {
            if (_context.LoanCardMasters == null)
            {
                return NotFound();
            }
            var loanCardMaster = await _context.LoanCardMasters.FindAsync(id);
            if (loanCardMaster == null)
            {
                return NotFound();
            }

            _context.LoanCardMasters.Remove(loanCardMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanCardMasterExists(string id)
        {
            return (_context.LoanCardMasters?.Any(e => e.LoanId == id)).GetValueOrDefault();
        }
    }
}
