using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "cac43a6e-f22b-4448-baaf-1add431ccbbf",
                    Name = "Vendeur",
                    NormalizedName = "VENDEUR"
                },
                new IdentityRole
                {
                    Id = "cbc43a8e-57bb-4445-baaf-1add431ffbbc",
                    Name = "Technicien",
                    NormalizedName = "TECHNICIEN"
                },
                new IdentityRole
                {
                    Id = "cbc43a8e-f34b-4445-baaf-1add431ffbbr",
                    Name = "Administrateur",
                    NormalizedName = "ADMINISTRATOR"
                }
            );
        }
    }
}
