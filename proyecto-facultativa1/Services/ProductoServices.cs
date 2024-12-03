using proyecto_facultativa1.Data;
using proyecto_facultativa1.Dtos;
using proyecto_facultativa1.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_facultativa1.Services
{
    public class ProductoServices : ICrudServices<ProductoResponseDto, ProductoInsertDto, ProductoUpdateDto>
    {
        private readonly ICrud<Productos> _ProductoRepository;

        public ProductoServices(ICrud<Productos> productoRepository)
        {
            _ProductoRepository = productoRepository;
        }

        public async Task<IEnumerable<ProductoResponseDto>> GetAll()
        {
            var productos = await _ProductoRepository.GetAll();

            return productos.Select(p => new ProductoResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Stock = p.Stock,
                ProveedorId = p.ProveedorId,
                ProveedorNombre = p.Proveedor.Nombre,
                FechaCreacion = p.FechaCreacion
            });
        }


        public async Task<ProductoResponseDto> GetById(int id)
        {
           var producto=await _ProductoRepository.GetById(id);  

            if(producto != null)
            {
                return new ProductoResponseDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    ProveedorId = producto.ProveedorId,
                    ProveedorNombre = producto.Proveedor.Nombre,
                    FechaCreacion = producto.FechaCreacion
                };
            }

            return null;
        }

        public async Task<ProductoResponseDto> Add(ProductoInsertDto productos)
        {
            var producto = new Productos() {
                Nombre = productos.Nombre,
                Descripcion = productos.Descripcion,
                Precio = productos.Precio,
                Stock = productos.Stock,
                ProveedorId = productos.ProveedorId,
                FechaCreacion = productos.FechaCreacion
            };

            await _ProductoRepository.Add(producto);
            await _ProductoRepository.Save();

             var productoDto= new ProductoResponseDto()
             {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    ProveedorId = producto.ProveedorId,
                    FechaCreacion = producto.FechaCreacion,
             };

            return productoDto;
        }

        public async Task<ProductoResponseDto> Update(int id, ProductoUpdateDto productos)
        {
           var Producto = await _ProductoRepository.GetById(id);

            if (Producto != null)
            {
                Producto.Nombre = productos.Nombre;
                Producto.Descripcion = productos.Descripcion;
                Producto.Precio = productos.Precio;
                Producto.Stock = productos.Stock;
                Producto.ProveedorId = productos.ProveedorId;

                _ProductoRepository.Update(Producto);
                await _ProductoRepository.Save();

                var productoDto = new ProductoResponseDto()
                {
                    Id = Producto.Id,
                    Nombre = Producto.Nombre,
                    Descripcion = Producto.Descripcion,
                    Precio = Producto.Precio,
                    Stock = Producto.Stock,
                    ProveedorId = Producto.ProveedorId,
                    FechaCreacion = Producto.FechaCreacion
                };

                return productoDto;
            }

            return null;
        }

        public async  Task<ProductoResponseDto> Delete(int id)
        {
            var productoDto = await _ProductoRepository.GetById(id);

            if(productoDto != null)
            { 
                _ProductoRepository.Delete(productoDto);
                await _ProductoRepository.Save();

                var producto = new ProductoResponseDto()
                {
                    Id = productoDto.Id,
                    Nombre = productoDto.Nombre,
                    Descripcion = productoDto.Descripcion,
                    Precio = productoDto.Precio,
                    Stock = productoDto.Stock,
                    ProveedorId = productoDto.ProveedorId,
                    FechaCreacion = productoDto.FechaCreacion
                };

                return producto;
            }
            return null;
        }

     
    }
}
