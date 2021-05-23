using Baram.Application.Common.Interfaces;
using Baram.Domain.Common;
using Baram.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Baram.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTimeService DateTimeService;

        public ApplicationDbContext(DbContextOptions options,
            IDateTimeService dateTimeService) : base(options)
        {
            DateTimeService = dateTimeService;
        }

        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Add / update audit data 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTimeService.UtcNow;
                         break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdated = DateTimeService.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Use Flunt API configurations
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
