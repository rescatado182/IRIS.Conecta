using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Persistence.DatabaseContext
{
    public class IRISConectaDatabaseContext(DbContextOptions<IRISConectaDatabaseContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IRISConectaDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
