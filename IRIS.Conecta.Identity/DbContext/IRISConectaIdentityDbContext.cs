using IRIS.Conecta.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Identity.DbContext
{
    public class IRISConectaIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IRISConectaIdentityDbContext(DbContextOptions<IRISConectaIdentityDbContext> options) 
            : base(options) 
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Identity.Roles");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "Identity.UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "Identity.UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "Identity.UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "Identity.RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "Identity.UserTokens");
            });

            builder.ApplyConfigurationsFromAssembly(typeof(IRISConectaIdentityDbContext).Assembly);
        }

    }
}
