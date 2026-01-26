using Api.Interface;
using Api.Repository;
using Api.Service;
using API.Data;
using API.Helper;
using API.Interface;
using API.Middleware;
using API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de Servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();


builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductTypeService>();
builder.Services.AddScoped<ProductBrandService>();
builder.Services.AddScoped<IproductRepository, ProductRepository>();
builder.Services.AddScoped<IproductBrandRepository, ProductBrandRepository>();
builder.Services.AddScoped<IproductTypeRepository,ProductTypeRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

// 2. Aplicar Migraciones al arrancar
// Usamos un bloque "scope" para obtener el DbContext de forma segura
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try 
    {        
        // Aplica migraciones pendientes
        await context.Database.MigrateAsync();

        // LLAMADA AL SEED: Inserta los datos de los JSON
        await StoreContextSeed.SeedAsync(context);             
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Ocurrió un error durante la migración o el seeding");
    }
}


// 3. Middlewares (Pipeline)



if (app.Environment.IsDevelopment())
app.UseMiddleware<ExceptionMiddleware>();
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseStaticFiles();
}
app.UseStatusCodePagesWithReExecute("/errors/{404}");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();