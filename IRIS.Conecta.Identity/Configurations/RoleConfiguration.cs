using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Assistant",
                    NormalizedName = "ASSISTANT",
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "Student",
                    NormalizedName = "STUDENT",
                },
                new IdentityRole
                {
                    Id = "4",
                    Name = "Head of Department",
                    NormalizedName = "HEAD_OF_DEPARTMENT",
                }                
            );
        }
    }
}
