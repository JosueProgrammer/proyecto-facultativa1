using proyecto_facultativa1.Data;

namespace proyecto_facultativa1.Dtos
{
    public class ProductoUpdateDto
    {
        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int ProveedorId { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
