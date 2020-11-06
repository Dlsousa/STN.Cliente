using STN.Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STN.Clientes.Data.EF
{
    public class StoreDataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public StoreDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: para os testes não consegue pegar as configurações do appsettings.json
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("StoreDBCon"));

            optionsBuilder.UseSqlServer("Server=tcp:mysqlserver1974.database.windows.net,1433;Initial Catalog=storedb;Persist Security Info=False;User ID=azureuser;Password=k@karoto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.ClienteMap());
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
