using Microsoft.EntityFrameworkCore;
using proyecto_facultativa1.Data;

namespace proyecto_facultativa1.Repository
{
    public class ClienteRepository : ICrud<Clientes>
    {
        private readonly ProductManagementContext _context;

        public ClienteRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clientes>> GetAll() => await _context.Clientes.ToListAsync();

        public async Task<Clientes> GetById(int id) => await _context.Clientes.FirstOrDefaultAsync(p=> p.Id==id);

        public async Task Add(Clientes entity) => await _context.Clientes.AddAsync(entity);
        public void Update(Clientes entity)
        {
            _context.Clientes.Attach(entity);
            _context.Clientes.Entry(entity).State= EntityState.Modified;
        }

        public void Delete(Clientes entity) => _context.Clientes.Remove(entity);
        public async Task Save() => await _context.SaveChangesAsync();  

    }
}
