using Microsoft.EntityFrameworkCore;
using ProductClienteHub.API.Entities;

namespace ProductClienteHub.API.Infra
{
    public class ProductClienteHubDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuração Manual para passar o Banco de dados diretamente no "AppSettings.json"
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)                
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);
        }
    }


}
