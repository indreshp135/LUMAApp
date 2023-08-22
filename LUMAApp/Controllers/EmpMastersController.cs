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
    [Authorize(Roles = "Admin")]
    public class EmpMastersController : ControllerBase
    {
        private readonly LmaContext _context;

        public EmpMastersController(LmaContext context)
        {
            _context = context;
        }

        // GET: api/EmpMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpMaster>>> GetEmpMasters()
        {
          if (_context.EmpMasters == null)
          {
              return NotFound();
          }
            return await _context.EmpMasters.ToListAsync();
        }

        // GET: api/EmpMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpMaster>> GetEmpMaster(string id)
        {
          if (_context.EmpMasters == null)
          {
              return NotFound();
          }
            var empMaster = await _context.EmpMasters.FindAsync(id);

            if (empMaster == null)
            {
                return NotFound();
            }

            return empMaster;
        }

        // PUT: api/EmpMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpMaster(string id, EmpMaster empMaster)
        {
            if (id != empMaster.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(empMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpMasterExists(id))
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

        // POST: api/EmpMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpMaster>> PostEmpMaster(EmpMaster empMaster)
        {
          if (_context.EmpMasters == null)
          {
              return Problem("Entity set 'LmaContext.EmpMasters'  is null.");
          }
            _context.EmpMasters.Add(empMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpMasterExists(empMaster.EmpId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpMaster", new { id = empMaster.EmpId }, empMaster);
        }

        // DELETE: api/EmpMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpMaster(string id)
        {
            if (_context.EmpMasters == null)
            {
                return NotFound();
            }
            var empMaster = await _context.EmpMasters.FindAsync(id);
            if (empMaster == null)
            {
                return NotFound();
            }

            _context.EmpMasters.Remove(empMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpMasterExists(string id)
        {
            return (_context.EmpMasters?.Any(e => e.EmpId == id)).GetValueOrDefault();
        }
    }
}
