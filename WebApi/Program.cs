using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

//Inyeccion de dependencias
builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();
builder.Services.AddTransient<IProductosServices, ProductosServices>();
builder.Services.AddTransient<IMarcasServices, MarcasServices>();
builder.Services.AddTransient<ICategoriasServices, CategoriasServices>();
builder.Services.AddTransient<IModelosServices, ModelosServices>();
builder.Services.AddTransient<IInventarioServices, InventarioServices>();
builder.Services.AddTransient<IImagenServices, ImagenesServices>();
builder.Services.AddTransient<IDireccionesServices, DireccionesServices>();
builder.Services.AddTransient<IPedidoServices, PedidoServices>();



builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);
var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
