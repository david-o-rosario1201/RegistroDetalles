﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Clientes
{
	[Key]
	public int ClienteId { get; set; }

	[Required(ErrorMessage = "Error, debe ingresar un nombre")]
	public string? Nombre { get; set; }

	[Phone(ErrorMessage = "Error, el formato del número de teléfono no es válido")]
	[Required(ErrorMessage = "Error, debe ingresar un número de teléfono")]
	public string? Telefono { get; set; }

	[Phone(ErrorMessage = "Error, el formato del número de celular no es válido")]
	[Required(ErrorMessage = "Error, debe ingresar un número de celular")]
	public string? Celular { get; set; }

	[Required(ErrorMessage = "Error, debe ingresar un RNC")]
	[StringLength(11, MinimumLength = 11, ErrorMessage = "El RNC debe tener exactamente 11 caracteres")]
	public string RNC { get; set; }

	[EmailAddress(ErrorMessage = "Error, el formato del email no es válido")]
	[Required(ErrorMessage = "Error, debe un ingresar un email")]
	public string? Email { get; set; }

	[Required(ErrorMessage = "Error, debe una dirección")]
	public string? Direccion { get; set; }
}
