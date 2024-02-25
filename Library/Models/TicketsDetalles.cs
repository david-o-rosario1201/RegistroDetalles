using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class TicketsDetalles
{
	[Key]
	public int Id { get; set; }

	[Required(ErrorMessage = "Errror, este campo es obligatorio")]
	public int TicketId { get; set; }

	[Required(ErrorMessage = "Errror, este campo es obligatorio")]
	public string Emisor { get; set; }

	[Required(ErrorMessage = "Errror, este campo es obligatorio")]
	public string Mensaje { get; set; }
}
