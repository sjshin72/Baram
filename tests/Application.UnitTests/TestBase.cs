using Baram.Application.Common.Interfaces;
using Moq;
using System.Threading;

namespace Baram.Application.UnitTests
{
    public class TestBase
    {
        protected readonly Mock<IApplicationDbContext> MockDbContext;

        public TestBase()
        {
            // Mocking DB context
            MockDbContext = new Mock<IApplicationDbContext>();
            MockDbContext.Setup(x => x.SaveChangesAsync(new CancellationToken())).ReturnsAsync(1);
        }
    }
}
