using Kada.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Identity.DbContext
{
    public class KadaIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public KadaIdentityDbContext(DbContextOptions<KadaIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(KadaIdentityDbContext).Assembly);
        }

    }
    
}
