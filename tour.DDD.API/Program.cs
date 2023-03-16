using Microsoft.EntityFrameworkCore;
using tour.DDD.Domain.CasoDeUso.CasosDeUso;
using tour.DDD.Domain.CasoDeUso.GateWays;
using tour.DDD.Domain.CasoDeUso.GateWays.Repositorios;
using tour.DDD.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("conexion"),
                    b => b.MigrationsAssembly(typeof(DataBaseContext).Assembly.FullName)
));

builder.Services.AddScoped(typeof(IEventosAlmacenadosRepositorio<>), typeof(StoredEventRepository<>));
builder.Services.AddScoped<IClienteCasoDeUsoGateWay, ClienteCasoDeUso>();
builder.Services.AddScoped<ITransporteCasoDeUsoGateWay, TransporteCasoDeUso>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    context.Database.Migrate();
}

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
