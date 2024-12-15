using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_facultativa1.Dtos;
using proyecto_facultativa1.Services;

namespace proyecto_facultativa1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICrudServices<ClienteResponseDto, ClienteInsertDto, ClienteUpdateDto> _clienteServices;

        public ClienteController(ICrudServices<ClienteResponseDto, ClienteInsertDto, ClienteUpdateDto> clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteResponseDto>> Get()
        {
            var cliente= await _clienteServices.GetAll();
            return cliente;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ClienteResponseDto>> GetById(int id)
        {
            var cliente = await _clienteServices.GetById(id);
            if (cliente != null) 
            {
                return Ok(cliente);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponseDto>> post(ClienteInsertDto dto)
        {
            var cliente = await _clienteServices.Add(dto);
            return Ok(cliente);
        }

        [HttpPut]
        public async Task<ActionResult<ClienteResponseDto>> update(int id, ClienteUpdateDto dto)
        {
            var cliente = await _clienteServices.Update(id, dto);
            return Ok(cliente);
        }

        [HttpDelete]
        public async Task<ActionResult<ClienteResponseDto>> delete(int id)
        {
            var cliente = await _clienteServices.Delete(id);
            return Ok(cliente); 
        }
    }
}
