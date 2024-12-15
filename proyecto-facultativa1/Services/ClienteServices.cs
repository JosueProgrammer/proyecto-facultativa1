using proyecto_facultativa1.Data;
using proyecto_facultativa1.Dtos;
using proyecto_facultativa1.Repository;

namespace proyecto_facultativa1.Services
{
    public class ClienteServices : ICrudServices<ClienteResponseDto, ClienteInsertDto, ClienteUpdateDto>
    {
        private readonly ICrud<Clientes> _ClienteRepository;

        public ClienteServices(ICrud<Clientes> clienteRepository)
        {
            _ClienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetAll()
        {
           var getClientes = await _ClienteRepository.GetAll();

            List<ClienteResponseDto> result = new List<ClienteResponseDto>();

            foreach(var cliente in getClientes)
            {
                var clienteResponse = new ClienteResponseDto
                {
                    Id = cliente.Id,
                    Nombre= cliente.Nombre,
                    Correo= cliente.Correo,
                    Telefono= cliente.Telefono,
                    Direccion= cliente.Direccion,
                    FechaRegistro= cliente.FechaRegistro,
                };

                result.Add(clienteResponse);
            }
            return result;
        }

        public async Task<ClienteResponseDto> GetById(int id)
        {
          var cliente = await _ClienteRepository.GetById(id);

            if(cliente != null)
            {
                return new ClienteResponseDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Correo = cliente.Correo,
                    Telefono = cliente.Telefono,
                    Direccion = cliente.Direccion,
                    FechaRegistro = cliente.FechaRegistro,
                };
            }

            return null;
        }
        public async Task<ClienteResponseDto> Add(ClienteInsertDto entity)
        {
            var cliente = new Clientes()
            {
                Nombre = entity.Nombre,
                Correo = entity.Correo,
                Telefono = entity.Telefono,
                Direccion = entity.Direccion,
                FechaRegistro = entity.FechaRegistro
            };

            await _ClienteRepository.Add(cliente);
            await _ClienteRepository.Save();

            var clienteDto = new ClienteResponseDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Correo = cliente.Correo,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                FechaRegistro = cliente.FechaRegistro,
            };

            return clienteDto;
        }

        public async Task<ClienteResponseDto> Update(int id, ClienteUpdateDto entity)
        {
            var cliente = await _ClienteRepository.GetById(id);

            if(cliente != null)
            {
                cliente.Nombre= entity.Nombre;
                cliente.Correo= entity.Correo;
                cliente.Telefono= entity.Telefono;
                cliente.Direccion= entity.Direccion;
                cliente.FechaRegistro= entity.FechaRegistro;

                _ClienteRepository.Update(cliente);
                await _ClienteRepository.Save();
                var clienteDto = new ClienteResponseDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Correo = cliente.Correo,
                    Telefono = cliente.Telefono,
                    Direccion = cliente.Direccion,
                    FechaRegistro = cliente.FechaRegistro,
                };

                return clienteDto;

            }

            return null;
        }

        public async Task<ClienteResponseDto> Delete(int id)
        {
            var cliente = await _ClienteRepository.GetById(id);
            
            if(cliente != null)
            {
                _ClienteRepository.Delete(cliente);
                await _ClienteRepository.Save();

                var clienteDto = new ClienteResponseDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Correo = cliente.Correo,
                    Telefono = cliente.Telefono,
                    Direccion = cliente.Direccion,
                    FechaRegistro = cliente.FechaRegistro,
                };

                return clienteDto;
            }

            return null;
        }
    }
}
