using Microsoft.EntityFrameworkCore;
using proyecto_facultativa1.Data;
using proyecto_facultativa1.Dtos;
using proyecto_facultativa1.Repository;
using proyecto_facultativa1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de Entity Framework
builder.Services.AddDbContext<ProductManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias personalizadas
builder.Services.AddScoped<ICrud<Productos>, ProductoRepository>();
builder.Services.AddScoped<ICrudServices<ProductoResponseDto, ProductoInsertDto, ProductoUpdateDto>, ProductoServices>();

builder.Services.AddScoped<ICrud<Proveedores>, ProveedorRepository>();
builder.Services.AddScoped<ICrudServices<ProveedoresResponseDto, ProveedoresInsertDto, ProveedoresUpdateDto>, ProveedoresServices>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
});

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Manejo de excepciones
app.UseExceptionHandler("/error");
app.UseHsts();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// Migraciones automáticas
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductManagementContext>();
    dbContext.Database.Migrate();
}

app.Run();
