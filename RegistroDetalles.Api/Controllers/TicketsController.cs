using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using RegistroDetalles.Api.DAL;
using System.Net.Sockets;

namespace RegistroDetalles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly Contexto _context;

        public TicketsController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tickets>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tickets>> GetTickets(int id)
        {
            if (_context.Tickets == null)
                return NotFound();

            var tickets = await _context.Tickets
                .Include(t => t.TicketsDetalle)
                .Where(t => t.TicketId == id)
                .FirstOrDefaultAsync();

            if(tickets == null)
                return NotFound();

            return tickets;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTickets(int id, Tickets tickets)
        {
            if (id != tickets.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(tickets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketsExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tickets>> PostTickets(Tickets tickets)
        {
            if (!TicketsExists(tickets.TicketId))
                _context.Tickets.Add(tickets);
            else
                _context.Tickets.Update(tickets);

            await _context.SaveChangesAsync();
            return Ok(tickets);
        }

		//// POST: api/Tickets/PostLastTicketDetail
		//[HttpPost("PostLastTicketDetail")]
		//public async Task<ActionResult<Tickets>> PostLastTicketDetail(Tickets tickets)
		//{
		//	var existingTicket = await _context.Tickets.FindAsync(tickets.TicketId);

		//	if (existingTicket == null)
		//	{
		//		return NotFound();
		//	}
		//	else
		//	{
		//		var lastDetail = tickets.TicketsDetalle.LastOrDefault();

		//		var newTicket = new Tickets
		//		{
		//			TicketId = existingTicket.TicketId,
		//			TicketsDetalle = new List<TicketsDetalles> { lastDetail }
		//		};

		//		_context.Tickets.Add(newTicket);
		//		await _context.SaveChangesAsync();

		//		return Ok(newTicket);
		//	}
		//}

		// DELETE: api/Tickets/5
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTickets(int id)
        {
            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(tickets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

		[HttpDelete("{ticketId}/Details/{detailId}")]
		public async Task<IActionResult> DeleteTicketDetail(int ticketId, int detailId)
		{
			var ticket = await _context.Tickets.FindAsync(ticketId);

			if (ticket == null)
			{
				return NotFound(); // Ticket no encontrado
			}

			// Encuentra el detalle del ticket que coincide con el detailId proporcionado
			var detalle = await _context.TicketsDetalles.FindAsync(detailId);

			if (detalle == null)
			{
				return NotFound(); // Detalle no encontrado
			}

			// Remueve el detalle del ticket del contexto
			_context.TicketsDetalles.Remove(detalle);

			// Guarda los cambios en la base de datos
			await _context.SaveChangesAsync();

			return NoContent(); // Indica que la eliminación fue exitosa
		}

		//[HttpDelete("api/Tickets/{ticketId}/Details/{detailId}")]
		//public async Task<IActionResult> DeleteTicketDetail(int ticketId, int ticketDetalleId)
		//{
		//	//var ticket = await _context.Tickets.Include(t => t.TicketsDetalle)
		//	//								   .FirstOrDefaultAsync(t => t.TicketId == ticketId);

		//	//if (ticket == null)
		//	//{
		//	//	return NotFound(); // Ticket no encontrado
		//	//}

		//	//var detail = ticket.TicketsDetalle.FirstOrDefault(d => d.Id == ticketDetalleId);
		//	//if (detail == null)
		//	//{
		//	//	return NotFound(); // Detalle no encontrado en el ticket
		//	//}

		//	//_context.Tickets.Remove(ticket);

		//	//await _context.SaveChangesAsync();   // Guardar los cambios en la base de datos

		//	//return NoContent(); // Indica que la eliminación fue exitosa

		//	var ticket = await _context.Tickets.FindAsync(ticketId);
		//	if (ticket == null)
		//	{
		//		return NotFound(); // Ticket no encontrado
		//	}

		//	_context.Tickets.Remove(ticket);
		//	await _context.SaveChangesAsync();

		//	return NoContent(); // Indica que la eliminación fue exitosa
		//}


		private bool TicketsExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketId == id);
        }
    }
}
