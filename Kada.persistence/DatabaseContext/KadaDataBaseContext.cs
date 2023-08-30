using HR.LeaveManagement.Application.Contracts.Identity;
using Kada.Application.Contracts.Identity;
using Kada.Domain;
using Kada.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.persistence.DatabaseContext
{
    public class KadaDataBaseContext : DbContext
    {
        private readonly IUserService _userService;
        public KadaDataBaseContext(DbContextOptions<KadaDataBaseContext> options, IUserService userService): base(options) 
        {
            _userService = userService;
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Fournisseur> Fournisseur { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KadaDataBaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                entry.Entity.ModifiedBy = _userService.UserId;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = _userService.UserId;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
