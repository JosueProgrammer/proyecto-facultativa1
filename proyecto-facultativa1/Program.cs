using Microsoft.EntityFrameworkCore;
using proyecto_facultativa1.Data;
using proyecto_facultativa1.Dtos;
using proyecto_facultativa1.Repository;
using proyecto_facultativa1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de Entity Framework
builder.Services.AddDbContext<ProductManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios y repositorios
builder.Services.AddScoped<ICrud<Productos>, ProductoRepository>();
builder.Services.AddScoped<ICrud<Clientes>, ClienteRepository>();
builder.Services.AddScoped<ICrud<Proveedores>, ProveedorRepository>();

//servicios
builder.Services.AddScoped<ICrudServices<ClienteResponseDto, ClienteInsertDto, ClienteUpdateDto>, ClienteServices>();
builder.Services.AddScoped<ICrudServices<ProductoResponseDto, ProductoInsertDto, ProductoUpdateDto>, ProductoServices>();
builder.Services.AddScoped<ICrudServices<ProveedoresResponseDto, ProveedoresInsertDto, ProveedoresUpdateDto>, ProveedoresServices>();

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
