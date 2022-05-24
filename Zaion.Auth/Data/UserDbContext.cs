using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Zaion.Auth.Data {
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int> {

        private IConfiguration _configuration;

        public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration configuration) : base(opt) {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);


            IdentityUser<int> admin = new() {
                UserName = _configuration.GetValue<string>("UsuarioAdmin:UserName"),
                NormalizedUserName = _configuration.GetValue<string>("UsuarioAdmin:UserName").ToUpper(),
                Email = _configuration.GetValue<string>("UsuarioAdmin:Email"),
                NormalizedEmail = _configuration.GetValue<string>("UsuarioAdmin:Email").ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 1
            };

            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();

            admin.PasswordHash = hasher.HashPassword(admin,
                _configuration.GetValue<string>("admininfo:password"));

            builder.Entity<IdentityUser<int>>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "admin", NormalizedName = "ADMIN" }
            );

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 2, Name = "regular", NormalizedName = "REGULAR" }
            );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 1 }
            );
        }

    }
}