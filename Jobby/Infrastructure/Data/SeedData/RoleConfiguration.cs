using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.SeedData
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
       // private readonly ILogger _logger;
    
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
           // _logger.LogInformation("Seeding Roles");
            builder.HasData(
                new IdentityRole
                {
                    Name = "Freelancer",
                    NormalizedName = "Freelancer"
                },
                new IdentityRole
                {
                    Name = "Employer",
                    NormalizedName = "Employer"
                }
            );
           // _logger.LogInformation("Roles Seeded.");
        }
    }
}
