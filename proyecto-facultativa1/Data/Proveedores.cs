using System;
using System.Collections.Generic;

namespace proyecto_facultativa1.Data;

public partial class Proveedores
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
