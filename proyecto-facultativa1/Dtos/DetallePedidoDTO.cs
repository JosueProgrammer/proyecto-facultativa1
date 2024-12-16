namespace proyecto_facultativa1.Dtos
{
    public class DetallePedidoDTO
    {
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal SubtotalCalculado {  get; set; }
    }
}
