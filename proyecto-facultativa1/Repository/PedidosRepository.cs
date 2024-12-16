using Microsoft.EntityFrameworkCore;
using proyecto_facultativa1.Data;
using System.Reflection.Metadata.Ecma335;

namespace proyecto_facultativa1.Repository
{
    public class PedidosRepository : ICrud<Pedidos>
    {
        private readonly ProductManagementContext _context;
        public PedidosRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedidos>> GetAll()
        {
            var resul = await _context.Pedidos
                .Include(p => p.DetallePedidos)
                .ToListAsync();
            return resul;
        }


        public async Task<Pedidos> GetById(int id)
        {
          var resul= await _context.Pedidos
                .Include(p => p.DetallePedidos)
                .FirstOrDefaultAsync(p=> p.Id==id);
            return resul;
        }

        public async Task Add(Pedidos entity)=> await _context.Pedidos.AddAsync(entity);

        public void Update(Pedidos entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pedidos entity)
        {
            throw new NotImplementedException();
        }

        public async Task Save() => await _context.SaveChangesAsync();  
    }
}
