﻿namespace proyecto_facultativa1.Dtos
{
    public class ProveedoresUpdateDto
    {

        public string Nombre { get; set; } = null!;

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public DateTime? FechaRegistro { get; set; }

    }
}
