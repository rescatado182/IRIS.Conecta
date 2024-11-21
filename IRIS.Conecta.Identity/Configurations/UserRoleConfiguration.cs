using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            //builder.HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "1",
            //        UserId = "1000"
            //    },
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "3",
            //        UserId = "1001"
            //    },
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "2",
            //        UserId = "1002"
            //    },
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "4",
            //        UserId = "1003"
            //    }
            //);
        }
    }
}
