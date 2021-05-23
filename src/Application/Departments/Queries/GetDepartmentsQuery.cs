using AutoMapper;
using AutoMapper.QueryableExtensions;
using Baram.Application.Common.Interfaces;
using Baram.Application.Departments.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Baram.Application.Departments.Queries
{
    public class GetDepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
    {
        public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentDto>>
        {
            private readonly IApplicationDbContext DbContext;
            private readonly IMapper Mapper;

            public GetDepartmentsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                DbContext = dbContext;
                Mapper = mapper;
            }

            public async Task<IEnumerable<DepartmentDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
            {
                // Get all departments
                var departments = await DbContext.Departments
                    .ToListAsync(cancellationToken);

                return Mapper.Map<IEnumerable<DepartmentDto>>(departments);
            }
        }
    }
}
