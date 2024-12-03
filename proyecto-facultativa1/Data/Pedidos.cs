using System;
using System.Collections.Generic;

namespace proyecto_facultativa1.Data;

public partial class Pedidos
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public decimal Total { get; set; }

    public virtual Clientes Cliente { get; set; } = null!;

    public virtual ICollection<DetallePedidos> DetallePedidos { get; set; } = new List<DetallePedidos>();
}
