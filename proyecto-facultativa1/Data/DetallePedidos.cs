using System;
using System.Collections.Generic;

namespace proyecto_facultativa1.Data;

public partial class DetallePedidos
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Pedidos Pedido { get; set; } = null!;

    public virtual Productos Producto { get; set; } = null!;
}
