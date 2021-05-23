using Baram.Application.Common.Interfaces;
using System;

namespace Baram.Infrastructure.Services
{
    public class DateTimeService: IDateTimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
