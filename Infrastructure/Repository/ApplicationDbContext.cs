using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        /****** DbSets ******/

        public DbSet<Jogo> jogo { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verifica se o DbContext não foi configurado (ou seja, se veio do construtor vazio)
            if (!optionsBuilder.IsConfigured)
            {
                string basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "FiapCloudGamesAPI");

                while (!File.Exists(Path.Combine(basePath, "appsettings.json")) && basePath != null)
                {
                    basePath = Directory.GetParent(basePath)?.FullName;
                    if (basePath == null) break;
                }

                if (basePath == null)
                {
                    throw new FileNotFoundException("Não foi possível encontrar o arquivo appsettings.json.");
                }

                string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                       ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                       ?? "Production"; // Define um default se não encontrar


                IConfiguration configuration = new ConfigurationBuilder()
                    // Define o caminho para o projeto de startup
                    .SetBasePath(basePath)
                    // 2. Carrega o arquivo base (appsettings.json)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    // 3. Carrega o arquivo específico do ambiente (ex: appsettings.Development.json)
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("ConnectionString");

                // Aplica a configuração
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
