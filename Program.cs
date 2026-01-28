using Api.Interface;
using Api.Repository;
using Api.Service;
using API.Data;
using API.ERRORS;
using API.Helper;
using API.Interface;
using API.Middleware;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de Servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

   
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 0)); 

    options.UseMySql(connectionString, serverVersion, mysqlOptions =>
    {
      
        mysqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null);
    });
});

builder.Services.AddControllers();


builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductTypeService>();
builder.Services.AddScoped<ProductBrandService>();
builder.Services.AddScoped<IproductRepository, ProductRepository>();
builder.Services.AddScoped<IproductBrandRepository, ProductBrandRepository>();
builder.Services.AddScoped<IproductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy =>
{
    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
}
));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = ActionContext =>
    {
        var errors = ActionContext.ModelState
        .Where(e => e.Value.Errors.Count > 0)
        .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToArray();
        var errorResponse = new ValidationErrorResponse
        {
            Errors = errors
        };
        return new BadRequestObjectResult(errorResponse);
    };
});

var app = builder.Build();

// 2. Aplicar Migraciones al arrancar

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
{
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthorization();




app.MapControllers();

app.Run("http://0.0.0.0:5079");