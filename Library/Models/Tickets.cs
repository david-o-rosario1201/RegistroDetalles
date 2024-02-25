using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Tickets
{
	[Key]
	public int TicketId { get; set; }

	[Required(ErrorMessage = "Error, la fecha es requerida")]
	[DataType(DataType.Date)]
	public DateTime Fecha { get; set; } = DateTime.Today;

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string Cliente { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string Sistema { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string Prioridad { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string SolicitadoPor { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string Asunto { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string Descripcion { get; set; }



	[ForeignKey("Tickets")]
	public ICollection<TicketsDetalles> TicketsDetalle { get; set; } = new List<TicketsDetalles>();
}
