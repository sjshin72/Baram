using Baram.Application.Common.Interfaces;
using Baram.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baram.Application.Departments.Commands
{
    public class InsertDepartmentCommand : IRequest<int>
    {
        public string Name { get; set; }

        public class InsertDepartmentCommandHandler : IRequestHandler<InsertDepartmentCommand, int>
        {
            private readonly IApplicationDbContext DbContext;

            public InsertDepartmentCommandHandler(IApplicationDbContext dbContext)
            {
                DbContext = dbContext;
            }

            public async Task<int> Handle(InsertDepartmentCommand request, CancellationToken cancellationToken)
            {
                // Add a new department
                var entity = new Department
                {
                    Name = request.Name
                };

                DbContext.Departments.Add(entity);
                await DbContext.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
