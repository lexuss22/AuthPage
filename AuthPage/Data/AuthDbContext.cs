using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthPage.Data
{
    public class AuthDbContext:IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var Reader = "4b38e621-5bb6-404d-85fd-08531ae179a6";
            var Admin = "4f6afb89-950f-465d-a597-aabcf9ccbc5f";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = Reader,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = Reader
                },
                new IdentityRole
                {
                    Id = Admin,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                    ConcurrencyStamp = Admin
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
