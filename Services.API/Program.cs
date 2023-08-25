using Microsoft.EntityFrameworkCore;
using Services.Core.Interfaces;
using Services.Core.Services;
using Services.Infraestructure.Data;
using Services.Infraestructure.Filters;
using Services.Infraestructure.Mappings;
using Services.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<PruebaStevensNexosContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("bd"))
                );

builder.Services.AddScoped<IAutoreService, AutoreService>();
builder.Services.AddScoped(typeof(IAutoreRepository), typeof(AutoreRepository));
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped(typeof(ILibroRepository), typeof(LibroRepository));
//builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));

//Cuando se presente el error de referencia cirular simplemente ignorelo, ese error
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
}
).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");
app.UseAuthorization();
app.MapControllers();
app.Run();
