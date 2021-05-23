using Baram.Application.Common.Mappings;
using Baram.Domain.Entities;

namespace Baram.Application.Departments.Queries.Dtos
{
    public class DepartmentDto : IMapFrom<Department>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
