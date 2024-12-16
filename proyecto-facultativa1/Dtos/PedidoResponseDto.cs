using proyecto_facultativa1.Data;

namespace proyecto_facultativa1.Dtos
{
    public class PedidoResponseDto
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime? FechaPedido { get; set; }

        public decimal TotalCalculado {  get; set; }

        public List<DetallePedidoDTO> Detalles { get; set; }
    }
}
