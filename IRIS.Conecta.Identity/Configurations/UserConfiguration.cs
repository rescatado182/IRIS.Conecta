using IRIS.Conecta.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Identity.Users");

            var hasher = new PasswordHasher<ApplicationUser>();

            //builder.HasData(
            //    new ApplicationUser
            //    {
            //        Id = "1000",
            //        Email = "adminIrisConecta@correo.itm.edu.co",
            //        NormalizedEmail = "adminIrisConecta@correo.itm.edu.co",
            //        FirstName = "System",
            //        LastName = "Admin",
            //        UserName = "admin",
            //        NormalizedUserName = "ADMIN",
            //        PasswordHash = hasher.HashPassword(null, "P@assword1"),
            //        EmailConfirmed = true
            //    },
            //    new ApplicationUser
            //    {
            //        Id = "1001",
            //        Email = "userStudent@correo.itm.edu.co",
            //        NormalizedEmail = "USERSTUDENT@correo.itm.edu.co",
            //        FirstName = "USER",
            //        LastName = "Student",
            //        UserName = "userStudent",
            //        NormalizedUserName = "USERSTUDENT",
            //        PasswordHash = hasher.HashPassword(null, "P@assword1"),
            //        EmailConfirmed = true
            //    },
            //    new ApplicationUser
            //    {
            //        Id = "1002",
            //        Email = "assistantIrisConecta@correo.itm.edu.co",
            //        NormalizedEmail = "assistantIrisConecta@correo.itm.edu.co",
            //        FirstName = "System",
            //        LastName = "Assistant",
            //        UserName = "userAssistant",
            //        NormalizedUserName = "ASSISTANT",
            //        PasswordHash = hasher.HashPassword(null, "P@assword1"),
            //        EmailConfirmed = true
            //    },
            //    new ApplicationUser
            //    {
            //        Id = "1003",
            //        Email = "headofdepartment@correo.itm.edu.co",
            //        NormalizedEmail = "headofdepartment@correo.itm.edu.co",
            //        FirstName = "HEAD OF",
            //        LastName = "DEPARTMENT",
            //        UserName = "headofdepartment",
            //        NormalizedUserName = "HEADOFDEPARTMENT",
            //        PasswordHash = hasher.HashPassword(null, "P@assword1"),
            //        EmailConfirmed = true
            //    }
            //);
        }
    }
}
