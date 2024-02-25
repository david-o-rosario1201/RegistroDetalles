using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Prioridades
{
	[Key]
	public int PrioridaId { get; set; }

	[Required(ErrorMessage = "Error, campo obligatorio")]
	public string Descripcion { get; set; }

	[Range(1, 31, ErrorMessage = "Error, el día debe ser mayor a 0 y menor a 32")]
	public int DiasCompromiso { get; set; }
}
