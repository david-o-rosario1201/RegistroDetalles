using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using RegistroDetalles.Api.DAL;

namespace RegistroDetalles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsDetallesController : ControllerBase
    {
        private readonly Contexto _context;

        public TicketsDetallesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/TicketsDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketsDetalles>>> GetTicketsDetalles()
        {
            return await _context.TicketsDetalles.ToListAsync();
        }

        // GET: api/TicketsDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketsDetalles>> GetTicketsDetalles(int id)
        {
			var ticketsDetalle = await _context.TicketsDetalles.FindAsync(id);

			if (ticketsDetalle == null)
			{
				return NotFound();
			}

			return ticketsDetalle;
		}

        // PUT: api/TicketsDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketsDetalles(int id, TicketsDetalles ticketsDetalles)
        {
            if (id != ticketsDetalles.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketsDetalles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketsDetallesExists(id))
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

        // POST: api/TicketsDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketsDetalles>> PostTicketsDetalles(TicketsDetalles ticketsDetalles)
        {
			_context.TicketsDetalles.Add(ticketsDetalles);
			await _context.SaveChangesAsync();
			return Ok(ticketsDetalles);
		}

        // DELETE: api/TicketsDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketsDetalles(int id)
        {
            var ticketsDetalles = await _context.TicketsDetalles.FindAsync(id);
            if (ticketsDetalles == null)
            {
                return NotFound();
            }

            _context.TicketsDetalles.Remove(ticketsDetalles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketsDetallesExists(int id)
        {
            return _context.TicketsDetalles.Any(e => e.Id == id);
        }
    }
}
