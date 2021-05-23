using Baram.Application.Departments.Commands;
using Baram.Domain.Entities;
using MockQueryable.Moq;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Baram.Application.UnitTests.Departments.Commands
{
    public class InsertDepartmentCommandTests : TestBase
    {
        #region Tests
        [Fact]
        public async Task ShouldCreateDepartment()
        {
            // Arrange
            var departments = new List<Department>();
            var mockdepartments = departments.AsQueryable().BuildMockDbSet();
            MockDbContext.Setup(x => x.Departments).Returns(mockdepartments.Object);

            var command = new InsertDepartmentCommand
            {
                Name = "Test department"
            };

            var handler = new InsertDepartmentCommand.InsertDepartmentCommandHandler(MockDbContext.Object);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            MockDbContext.Verify(x => x.Departments.Add(It.IsAny<Department>()), Times.Once());
            MockDbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
        #endregion
    }
}