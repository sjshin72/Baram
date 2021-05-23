using System;

namespace Baram.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
