using Microsoft.EntityFrameworkCore;
using proyecto_facultativa1.Data;

namespace proyecto_facultativa1.Repository
{
    public class ProductoRepository : ICrud<Productos>
    {
        private ProductManagementContext _context { get; set; }
        public ProductoRepository(ProductManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Productos>> GetAll()
          => await _context.Productos.Include(p => p.Proveedor).ToListAsync();


        public async Task<Productos?> GetById(int id)
         => await _context.Productos
         .Include(p => p.Proveedor) 
         .FirstOrDefaultAsync(p => p.Id == id);

        public async Task Add(Productos Products) => await _context.Productos.AddAsync(Products);

        public void Update(Productos Producto)
        {
            _context.Productos.Attach(Producto);
            _context.Productos.Entry(Producto).State = EntityState.Modified;
        }


        public void Delete(Productos product) => _context.Productos.Remove(product);

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
