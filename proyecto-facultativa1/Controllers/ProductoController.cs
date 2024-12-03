using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_facultativa1.Dtos;
using proyecto_facultativa1.Services;

namespace proyecto_facultativa1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ICrudServices<ProductoResponseDto, ProductoInsertDto, ProductoUpdateDto> _crudServices;

        public ProductoController(ICrudServices<ProductoResponseDto, ProductoInsertDto, ProductoUpdateDto> crudServices) 
        {
            _crudServices = crudServices;   
        }

        [HttpGet]
        public async Task<IEnumerable<ProductoResponseDto>> GetAll()
        {
            var producto = await _crudServices.GetAll();
            return producto;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ProductoResponseDto>> GetById(int id)
        {
            var ProductoDto = await _crudServices.GetById(id);

            if(ProductoDto != null)
            {
                return Ok(ProductoDto);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<ProductoResponseDto>> Add(ProductoInsertDto productoInsertDto)
        {
            var productos = await _crudServices.Add(productoInsertDto);
            return Ok(productos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductoInsertDto>> update(int id, ProductoUpdateDto productoUpdateDto)
        {
            var productos = await _crudServices.Update(id, productoUpdateDto);
            return Ok(productos);
        }

        [HttpDelete("{id}")]    
        public async Task<ActionResult<ProductoResponseDto>> Delete (int id)
        {
            var producto = await _crudServices.Delete(id);
            return Ok(producto);
        }
    }
}
