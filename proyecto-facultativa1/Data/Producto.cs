using System;
using System.Collections.Generic;

namespace proyecto_facultativa1.Data;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int ProveedorId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Proveedore Proveedor { get; set; } = null!;
}
