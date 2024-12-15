namespace proyecto_facultativa1.Dtos
{
    public class ClienteUpdateDto
    {
        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}
