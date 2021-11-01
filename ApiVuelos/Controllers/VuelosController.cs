using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVuelos;
using ApiVuelos.models;

namespace ApiVuelos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VuelosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vuelos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vuelos>>> GetVuelos()
        {
            return await _context.Vuelos.ToListAsync();
        }

        // GET: api/Vuelos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vuelos>> GetVuelos(int id)
        {
            var vuelos = await _context.Vuelos.FindAsync(id);

            if (vuelos == null)
            {
                return NotFound();
            }

            return vuelos;
        }

        // PUT: api/Vuelos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVuelos(int id, Vuelos vuelos)
        {
            if (id != vuelos.Id_Vuelo)
            {
                return BadRequest();
            }

            _context.Entry(vuelos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VuelosExists(id))
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

        // POST: api/Vuelos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vuelos>> PostVuelos(Vuelos vuelos)
        {
            _context.Vuelos.Add(vuelos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVuelos", new { id = vuelos.Id_Vuelo }, vuelos);
        }

        // DELETE: api/Vuelos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vuelos>> DeleteVuelos(int id)
        {
            var vuelos = await _context.Vuelos.FindAsync(id);
            if (vuelos == null)
            {
                return NotFound();
            }

            _context.Vuelos.Remove(vuelos);
            await _context.SaveChangesAsync();

            return vuelos;
        }

        private bool VuelosExists(int id)
        {
            return _context.Vuelos.Any(e => e.Id_Vuelo == id);
        }
    }
}
