using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace IRIS.Conecta.Persistence.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IRISConectaDatabaseContext>
    {
        public IRISConectaDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IRISConectaDatabaseContext>();

            // Cadena de conexión directamente en el código
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Iris;Trusted_Connection=True;MultipleActiveResultSets=true";

            optionsBuilder.UseSqlServer(connectionString);

            return new IRISConectaDatabaseContext(optionsBuilder.Options);
        }
    }
}
