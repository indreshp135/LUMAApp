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
    public class ItemMastersController : ControllerBase
    {
        private readonly Luma1Context _context;

        public ItemMastersController(Luma1Context context)
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
              return Problem("Entity set 'Luma1Context.ItemMasters'  is null.");
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

        private bool ItemMasterExists(string id)
        {
            return (_context.ItemMasters?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
