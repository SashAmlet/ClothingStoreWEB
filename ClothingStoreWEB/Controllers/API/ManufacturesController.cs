using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingStoreWEB.Context;
using ClothingStoreWEB.Models;

namespace ClothingStoreWEB.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturesController : ControllerBase
    {
        private readonly MainContext _context;

        public ManufacturesController(MainContext context)
        {
            _context = context;
        }

        // GET: api/ManufacturesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacture>>> GetManufactures()
        {
          if (_context.Manufactures == null)
          {
              return NotFound();
          }
            return await _context.Manufactures.ToListAsync();
        }

        // GET: api/ManufacturesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacture>> GetManufacture(int id)
        {
          if (_context.Manufactures == null)
          {
              return NotFound();
          }
            var manufacture = await _context.Manufactures.FindAsync(id);

            if (manufacture == null)
            {
                return NotFound();
            }

            return manufacture;
        }

        // PUT: api/ManufacturesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacture(int id, Manufacture manufacture)
        {
            if (id != manufacture.Id)
            {
                return BadRequest();
            }

            _context.Entry(manufacture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufactureExists(id))
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

        // POST: api/ManufacturesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manufacture>> PostManufacture(Manufacture manufacture)
        {
          if (_context.Manufactures == null)
          {
              return Problem("Entity set 'MainContext.Manufactures'  is null.");
          }
            _context.Manufactures.Add(manufacture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacture", new { id = manufacture.Id }, manufacture);
        }

        // DELETE: api/ManufacturesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacture(int id)
        {
            if (_context.Manufactures == null)
            {
                return NotFound();
            }
            var manufacture = await _context.Manufactures.FindAsync(id);
            if (manufacture == null)
            {
                return NotFound();
            }

            _context.Manufactures.Remove(manufacture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManufactureExists(int id)
        {
            return (_context.Manufactures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
