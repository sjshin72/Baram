using Baram.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baram.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDepartmentDataAsync(ApplicationDbContext context)
        {
            // Add departments if empty
            if(!context.Departments.Any())
            {
                var departments = new List<Department>
                {
                    new()
                    {
                        Name = "Information Techology"
                    },
                    new()
                    {
                        Name = "Marketing"
                    },
                    new()
                    {
                        Name = "Sales"
                    }
                };

                context.Departments.AddRange(departments);
                await context.SaveChangesAsync();
            }            
        }
    }
}
