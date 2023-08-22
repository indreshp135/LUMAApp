using LUMAApp.Entities;
using LUMAApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LUMAApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class ItemMastersController : ControllerBase
    {
        private readonly LmaContext _context;

        public ItemMastersController(LmaContext context)
        {
            _context = context;
        }

        // GET: api/ItemMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemMaster>>> GetItemMasters()
        {
            if (_context.ItemMasters == null)
            {
                return NotFound();
            }
            return await _context.ItemMasters.ToListAsync();
        }

        // GET: api/ItemMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemMaster>> GetItemMaster(string id)
        {
            if (_context.ItemMasters == null)
            {
                return NotFound();
            }
            var itemMaster = await _context.ItemMasters.FindAsync(id);

            if (itemMaster == null)
            {
                return NotFound();
            }

            return itemMaster;
        }

        // PUT: api/ItemMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemMaster(string id, ItemMaster itemMaster)
        {
            if (id != itemMaster.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(itemMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemMasterExists(id))
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

        // POST: api/ItemMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemMaster>> PostItemMaster(ItemMaster itemMaster)
        {
            if (_context.ItemMasters == null)
            {
                return Problem("Entity set 'LmaContext.ItemMasters'  is null.");
            }

            _context.ItemMasters.Add(itemMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemMasterExists(itemMaster.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItemMaster", new { id = itemMaster.ItemId }, itemMaster);
        }

        // DELETE: api/ItemMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemMaster(string id)
        {
            if (_context.ItemMasters == null)
            {
                return NotFound();
            }
            var itemMaster = await _context.ItemMasters.FindAsync(id);
            if (itemMaster == null)
            {
                return NotFound();
            }

            _context.ItemMasters.Remove(itemMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("forLoanType")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ItemMaster>>> GetItemMastersForLoan([FromQuery] ItemsForLoanTypeRequest itemsForLoanTypeRequest)
        {
            if (_context.ItemMasters == null)
            {
                return NotFound();
            }
            return await _context.ItemMasters.Where(i => i.ItemCategory == itemsForLoanTypeRequest.LoanType).ToListAsync();
        }

        private bool ItemMasterExists(string id)
        {
            return (_context.ItemMasters?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
