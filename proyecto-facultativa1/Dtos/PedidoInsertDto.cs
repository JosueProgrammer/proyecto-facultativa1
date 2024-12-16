using proyecto_facultativa1.Data;

namespace proyecto_facultativa1.Dtos
{
    public class PedidoInsertDto
    {
        public int ClienteId { get; set; }

        public DateTime? FechaPedido { get; set; }

        public ICollection<DetallesPedidoAdd> detallesPedidoAdds { get; set; }
    }
}
