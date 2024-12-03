using Microsoft.EntityFrameworkCore;
using proyecto_facultativa1.Data;

namespace proyecto_facultativa1.Repository
{
    public class ProveedorRepository : ICrud<Proveedores>
    {
        private readonly ProductManagementContext _context;

        public ProveedorRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proveedores>> GetAll() => await _context.Proveedores.ToListAsync();
        public async Task<Proveedores> GetById(int id) => await _context.Proveedores.FirstOrDefaultAsync(p => p.Id == id);
        public async Task Add(Proveedores entity) => await _context.Proveedores.AddAsync(entity);
        public void Update(Proveedores entity)
        {
            _context.Proveedores.Attach(entity);
            _context.Proveedores.Entry(entity).State= EntityState.Modified;
        }
        public void Delete(Proveedores entity)=> _context.Proveedores.Remove(entity);

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
