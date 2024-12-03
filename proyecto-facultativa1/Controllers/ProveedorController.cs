using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_facultativa1.Dtos;
using proyecto_facultativa1.Services;

namespace proyecto_facultativa1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ICrudServices<ProveedoresResponseDto, ProveedoresInsertDto, ProveedoresUpdateDto> _crudServices;

        public ProveedorController(ICrudServices<ProveedoresResponseDto, ProveedoresInsertDto, ProveedoresUpdateDto> crudServices) 
        {
            _crudServices = crudServices;
        }

        [HttpGet]
        public async Task<IEnumerable<ProveedoresResponseDto>> GetAll()
        {
            var proveedor = await _crudServices.GetAll();
            return proveedor;
        }

        [HttpGet("GetById{id}")]
        public async Task<ActionResult<ProveedoresResponseDto>> GetById(int id)
        {
            var Proveedor = await _crudServices.GetById(id);
            if (Proveedor != null)
            {
                return Proveedor;
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<ProveedoresResponseDto>> Add(ProveedoresInsertDto dto)
        {
            var proveedor = await _crudServices.Add(dto);
            return Ok(proveedor);
        }

        [HttpPut]
        public async Task<ActionResult<ProveedoresResponseDto>> Update(int id, ProveedoresUpdateDto dto) 
        {
            var proveedor = await _crudServices.Update(id, dto);
            return Ok(proveedor);
        }

        [HttpDelete]    
        public async Task<ActionResult<ProveedoresResponseDto>> Delete(int id)
        {
            var proveedor = await _crudServices.Delete(id);   
            return Ok(proveedor);
        }
    }
}
