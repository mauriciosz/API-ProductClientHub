using Microsoft.EntityFrameworkCore;
using ProductClienteHub.API.Entities;

namespace ProductClienteHub.API.Infra
{
    /*
     * Essa classe faz a tradução de uma Entidade em uma Query e persiste no Banco.
     * Ela faz isso utilizando o EntityFramework, sem a necessidade de fazer "INSERT"
     */
    /*public class ProductClienteHubDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\MySQL\\ProductClienteHub.db");
        }
    }*/

    public class ProductClienteHubDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Cria o configuration manualmente, sem depender de DI
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                //.SetBasePath(Directory.GetCurrentDirectory()) // ou AppContext.BaseDirectory se estiver rodando como serviço/API publicada
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);
        }
    }


}
