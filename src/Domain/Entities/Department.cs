using Baram.Domain.Common;

namespace Baram.Domain.Entities
{
    public class Department : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
