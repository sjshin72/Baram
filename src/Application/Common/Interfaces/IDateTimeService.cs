using System;

namespace Baram.Application.Common.Interfaces
{
    public interface IDateTimeService
    {
        DateTime UtcNow { get; }
    }
}
