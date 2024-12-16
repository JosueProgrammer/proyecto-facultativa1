using proyecto_facultativa1.Data;
using proyecto_facultativa1.Dtos;
using proyecto_facultativa1.Repository;

namespace proyecto_facultativa1.Services
{
    public class PedidoServices : ICrudServices<PedidoResponseDto, PedidoInsertDto, PedidoUpdateDto>
    {
        private readonly ICrud<Pedidos> _crud;

        public PedidoServices(ICrud<Pedidos> crud)
        {
            _crud = crud;
        }

        public async Task<IEnumerable<PedidoResponseDto>> GetAll()
        {
           var pedidos= await _crud.GetAll();

            var response = pedidos.Select(x => new PedidoResponseDto
            {
                Id = x.Id,
                ClienteId = x.ClienteId,
                FechaPedido = x.FechaPedido ?? DateTime.Now,
                TotalCalculado = x.DetallePedidos?.Sum(d => d.Cantidad * d.PrecioUnitario) ?? 0,
                Detalles = x.DetallePedidos.Select(p => new DetallePedidoDTO
                {
                    ProductoId= p.ProductoId,
                    Cantidad= p.Cantidad,
                    PrecioUnitario= p.PrecioUnitario,
                    SubtotalCalculado= p.Cantidad * p.PrecioUnitario,
                }).ToList()
            }); 
            return response;
        }

        public async Task<PedidoResponseDto> GetById(int id)
        {
            var pedidos = await _crud.GetById(id);

            if(pedidos != null)
            {
                var response = new PedidoResponseDto
                {
                    Id = pedidos.Id,
                    ClienteId = pedidos.ClienteId,
                    FechaPedido = pedidos.FechaPedido ?? DateTime.Now,
                    TotalCalculado = pedidos.DetallePedidos?.Sum(d => d.Cantidad * d.PrecioUnitario) ?? 0,
                    Detalles = pedidos.DetallePedidos.Select(p => new DetallePedidoDTO
                    {
                        ProductoId = p.ProductoId,
                        Cantidad = p.Cantidad,
                        PrecioUnitario = p.PrecioUnitario,
                        SubtotalCalculado = p.Cantidad * p.PrecioUnitario,
                    }).ToList()
                };
                return response;
            }

            return null;
        }

        public async Task<PedidoResponseDto> Add(PedidoInsertDto entity)
        {
            var pedidos = new Pedidos
            {
                ClienteId=entity.ClienteId,
                FechaPedido= entity.FechaPedido,
            };

            foreach(var detalle in entity.detallesPedidoAdds)
            {
                pedidos.DetallePedidos.Add(new DetallePedidos
                {
                    ProductoId = detalle.ProductoId,
                    Cantidad = detalle.Cantidad,
                    PrecioUnitario = detalle.PrecioUnitario,
                });
                
            }

            await _crud.Add(pedidos);
            await _crud.Save();

            var response = new PedidoResponseDto
            {
                Id = pedidos.Id,
                ClienteId = pedidos.ClienteId,
                FechaPedido = pedidos.FechaPedido ?? DateTime.Now,
                TotalCalculado = pedidos.DetallePedidos?.Sum(d => d.Cantidad * d.PrecioUnitario) ?? 0,
                Detalles = pedidos.DetallePedidos.Select(p => new DetallePedidoDTO
                {
                    ProductoId = p.ProductoId,
                    Cantidad = p.Cantidad,
                    PrecioUnitario = p.PrecioUnitario,
                    SubtotalCalculado = p.Cantidad * p.PrecioUnitario,
                }).ToList()
            };
            return response;
        }

        public Task<PedidoResponseDto> Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task<PedidoResponseDto> Update(int id, PedidoUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
