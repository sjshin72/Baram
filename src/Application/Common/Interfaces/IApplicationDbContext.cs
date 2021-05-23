using Baram.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Baram.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Department> Departments { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
