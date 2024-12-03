using proyecto_facultativa1.Data;
using proyecto_facultativa1.Dtos;
using proyecto_facultativa1.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_facultativa1.Services
{
    public class ProveedoresServices : ICrudServices<ProveedoresResponseDto, ProveedoresInsertDto, ProveedoresUpdateDto>
    {
        private readonly ICrud<Proveedores> _crudServicesRepository;
        public ProveedoresServices(ICrud<Proveedores> crudServices) 
        {
            _crudServicesRepository = crudServices;
        }    
      
        public async Task<IEnumerable<ProveedoresResponseDto>> GetAll()
        {
           var proveedores = await _crudServicesRepository.GetAll();

            return proveedores.Select( p => new ProveedoresResponseDto 
            {
                Id= p.Id,
                Nombre= p.Nombre,
                Correo= p.Correo,
                Direccion= p.Direccion,
                Telefono= p.Telefono,
                FechaRegistro= p.FechaRegistro,
            });
        }

        public async  Task<ProveedoresResponseDto> GetById(int id)
        {
           var proveedores = await _crudServicesRepository.GetById(id);

            if (proveedores != null)
            {
                return new ProveedoresResponseDto 
                { 
                    Id = proveedores.Id,
                    Nombre = proveedores.Nombre,
                    Correo = proveedores.Correo,
                    Direccion = proveedores.Direccion,
                    Telefono = proveedores.Telefono,
                    FechaRegistro = proveedores.FechaRegistro
               };

            }

            return null;
        }
        public async Task<ProveedoresResponseDto> Add(ProveedoresInsertDto entity)
        {
            var proveedor = new Proveedores()
            {
                Nombre = entity.Nombre,
                Correo = entity.Correo,
                Direccion = entity.Direccion,
                Telefono = entity.Telefono,
                FechaRegistro = entity.FechaRegistro
            };

            await _crudServicesRepository.Add(proveedor);
            await _crudServicesRepository.Save();

            var proveedorDto = new ProveedoresResponseDto()
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Correo = proveedor.Correo,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
                FechaRegistro = proveedor.FechaRegistro
            };

            return proveedorDto;
        }

        public async  Task<ProveedoresResponseDto> Update(int id, ProveedoresUpdateDto entity)
        {
            var proveedor = await _crudServicesRepository.GetById(id);

            if (proveedor != null) 
            {
                proveedor.Nombre = entity.Nombre;
                proveedor.Correo = entity.Correo;
                proveedor.Direccion = entity.Direccion;
                proveedor.Telefono = entity.Telefono;
                proveedor.FechaRegistro = entity.FechaRegistro;

                _crudServicesRepository.Update(proveedor);
                await _crudServicesRepository.Save();

                var ProveedorDto = new ProveedoresResponseDto()
                {
                    Id = proveedor.Id,
                    Nombre = proveedor.Nombre,
                    Correo = proveedor.Correo,
                    Direccion = proveedor.Direccion,
                    Telefono = proveedor.Telefono,
                    FechaRegistro = proveedor.FechaRegistro
                };

                return ProveedorDto;
            }

            return null;
        }

        public async Task<ProveedoresResponseDto> Delete(int id)
        {
            var proveedor = await _crudServicesRepository.GetById(id);

            if (proveedor != null)
            {
                 _crudServicesRepository.Delete(proveedor);
                await _crudServicesRepository.Save();

                var ProveedorDto = new ProveedoresResponseDto()
                {
                    Id = proveedor.Id,
                    Nombre = proveedor.Nombre,
                    Correo = proveedor.Correo,
                    Direccion = proveedor.Direccion,
                    Telefono = proveedor.Telefono,
                    FechaRegistro = proveedor.FechaRegistro
                };

                return ProveedorDto;
            }

            return null;
        }
     
    }
}
