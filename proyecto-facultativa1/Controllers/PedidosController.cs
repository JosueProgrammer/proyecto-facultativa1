using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_facultativa1.Dtos;
using proyecto_facultativa1.Services;

namespace proyecto_facultativa1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly ICrudServices<PedidoResponseDto,PedidoInsertDto,PedidoUpdateDto> _crudServices;

        public PedidosController(ICrudServices<PedidoResponseDto, PedidoInsertDto, PedidoUpdateDto> crudServices) 
        {
            _crudServices = crudServices;
        }

        [HttpGet]   
        public async Task<IEnumerable<PedidoResponseDto>> GetAll()
        {
            return await _crudServices.GetAll();
        }

        [HttpGet("GetById{id}")]
        public async Task<ActionResult<PedidoResponseDto>> GetById(int id)
        {
            var pedidos = await _crudServices.GetById(id);
            if (pedidos == null) 
            {
                return NotFound();
            }
            return Ok(pedidos);
        }

        [HttpPost]
        public async Task<ActionResult<PedidoResponseDto>> Add(PedidoInsertDto insert)
        {
            var pedidos = await _crudServices.Add(insert);
            return pedidos;
        }  
    }
}
