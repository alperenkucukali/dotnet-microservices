using Account.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Persistence
{
    public class AccountContext(DbContextOptions<AccountContext> options) : DbContext(options)
        {
        public DbSet<Domain.Entities.Account> Accounts { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
