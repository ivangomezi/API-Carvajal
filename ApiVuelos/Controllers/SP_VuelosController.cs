using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVuelos;
using ApiVuelos.models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.IdentityModel.Protocols;

namespace ApiVuelos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SP_VuelosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SP_VuelosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SP_Vuelos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SP_Vuelos>>> GetSP_Vuelos()
        {
            return await _context.SP_Vuelos.ToListAsync();
        }

        // GET: api/SP_Vuelos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SP_Vuelos>> GetSP_Vuelos(int id)
        {
            var sP_Vuelos = await _context.SP_Vuelos.FindAsync(id);

            if (sP_Vuelos == null)
            {
                return NotFound();
            }

            return sP_Vuelos;
        }

        // PUT: api/SP_Vuelos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSP_Vuelos(int id, SP_Vuelos sP_Vuelos)
        {
            if (id != sP_Vuelos.Id_Vuelo)
            {
                return BadRequest();
            }

            _context.Entry(sP_Vuelos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SP_VuelosExists(id))
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

        // POST: api/SP_Vuelos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SP_Vuelos>> PostSP_Vuelos(SP_Vuelos sP_Vuelos)
        {
            _context.SP_Vuelos.Add(sP_Vuelos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSP_Vuelos", new { id = sP_Vuelos.Id_Vuelo }, sP_Vuelos);
        }

        // DELETE: api/SP_Vuelos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SP_Vuelos>> DeleteSP_Vuelos(int id)
        {
            var sP_Vuelos = await _context.SP_Vuelos.FindAsync(id);
            if (sP_Vuelos == null)
            {
                return NotFound();
            }

            _context.SP_Vuelos.Remove(sP_Vuelos);
            await _context.SaveChangesAsync();

            return sP_Vuelos;
        }

        private bool SP_VuelosExists(int id)
        {
            return _context.SP_Vuelos.Any(e => e.Id_Vuelo == id);
        }
    }
}
