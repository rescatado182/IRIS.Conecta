using IRIS.Conecta.Domain.Base;
using IRIS.Conecta.Identity.Models;
using IRIS.Conecta.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Threading;

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

            builder.ApplyConfigurationsFromAssembly(typeof(IRISConectaIdentityDbContext).Assembly);

        }        

    }
}
