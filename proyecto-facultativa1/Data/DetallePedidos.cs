using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_facultativa1.Data;

public partial class DetallePedidos
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    private decimal _subtotal;
    public decimal Subtotal => Cantidad * PrecioUnitario;

    public virtual Pedidos Pedido { get; set; } = null!;

    public virtual Productos Producto { get; set; } = null!;
}
