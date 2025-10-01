using Core.Repository;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;



string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                       ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                       ?? "Production"; // Define um default se não encontrar

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()

    .SetBasePath(Directory.GetCurrentDirectory())
    // 2. Carrega o arquivo base (appsettings.json)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)

    // 3. Carrega o arquivo específico do ambiente (ex: appsettings.Development.json)
    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)

    // 4. Carrega variáveis de ambiente (Estas devem vir por último para ter maior precedência)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
}, ServiceLifetime.Scoped);



builder.Services.AddScoped<IJogoRepository, JogoRepository>();
var app = builder.Build();

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
