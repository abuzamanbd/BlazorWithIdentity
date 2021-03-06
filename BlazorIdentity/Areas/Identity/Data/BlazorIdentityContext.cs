using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorIdentity.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorIdentity.Data
{
    public class BlazorIdentityContext : IdentityDbContext<BlazorIdentityUser>
    {
        private string RoleIdAdmin = Guid.NewGuid().ToString();
        private string RoleIdMember = Guid.NewGuid().ToString();
        private string RoleIdUser = Guid.NewGuid().ToString();

        public BlazorIdentityContext(DbContextOptions<BlazorIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole 
                { 
                    Id = RoleIdAdmin,
                    Name = "admin", NormalizedName = "ADMIN",
                    ConcurrencyStamp = DateTime.UtcNow.ToString()
                },
                new IdentityRole
                {
                    Id = RoleIdMember,
                    Name = "member",
                    NormalizedName = "MEMBER",
                    ConcurrencyStamp = DateTime.UtcNow.ToString()
                },
                new IdentityRole
                {
                    Id = RoleIdUser,
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = DateTime.UtcNow.ToString()
                }
            );
        }
    }
}
