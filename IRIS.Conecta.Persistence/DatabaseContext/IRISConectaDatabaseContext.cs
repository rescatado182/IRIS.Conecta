using IRIS.Conecta.Domain.Base;
using IRIS.Conecta.Domain.Entities;
using IRIS.Conecta.Domain.Entities.Masters;
using IRIS.Conecta.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Persistence.DatabaseContext
{
    public class IRISConectaDatabaseContext : DbContext
    {
        public IRISConectaDatabaseContext(DbContextOptions<IRISConectaDatabaseContext> options) : base(options)
        {            
        }
        
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Program> Programs { get; set; }

        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<TemplateResponses> TemplateResponses { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketsView> TicketsViews { get; set; }
        public DbSet<Notifications> Notifications { get; set; }

        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<AcademicData> AcademicDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IRISConectaDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.DateModified = DateTime.Now;                

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        
    }
}
