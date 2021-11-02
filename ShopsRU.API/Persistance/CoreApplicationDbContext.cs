using Microsoft.EntityFrameworkCore;
using ShopsRU.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRU.API.Persistance
{
    public class CoreApplicationDbContext : DbContext
    {
        public CoreApplicationDbContext(DbContextOptions<CoreApplicationDbContext> options)
         : base(options)
        {
        }

        public virtual DbSet<Discounts> Discounts { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }

        public override int SaveChanges()
        {
            AddTimeStamp();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimeStamp();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimeStamp()
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.Entity is Base && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((Base)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
                else
                {
                    ((Base)entityEntry.Entity).ModifiedAt = DateTime.Now;
                }
            }
        }
    }
}