using AutoMapper;
using Baram.Application.Departments.Queries;
using Baram.Application.Departments.Queries.Dtos;
using Baram.Domain.Entities;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Baram.Application.UnitTests.Departments.Queries
{
    public class GetDepartmentsQueryTests : TestBase
    {
        private readonly Mock<IMapper> MockMapper;

        public GetDepartmentsQueryTests()
        {
            // Mocking Automapper
            MockMapper = new Mock<IMapper>();
        }

        #region Tests
        [Fact]
        public async Task ShouldGetDepartments()
        {
            // Arrage
            var departments = new List<Department>
            {
                new()
                {
                    Id = 1,
                    Name = "Test1"
                }
            };
            var mockdepartments = departments.AsQueryable().BuildMockDbSet();
            MockDbContext.Setup(x => x.Departments).Returns(mockdepartments.Object);

            MockMapper.Setup(x => x.Map<IEnumerable<DepartmentDto>>(It.IsAny<IEnumerable<Department>>())).Returns(new List<DepartmentDto>
            {
                new()
                {
                    Id = 1,
                    Name = "Test1",
                }                
            }); ;

            var query = new GetDepartmentsQuery();

            var handler = new GetDepartmentsQuery.GetDepartmentsQueryHandler(MockDbContext.Object, MockMapper.Object);

            // Act
            var result = await handler.Handle(query, new CancellationToken());

            // Assert
            Assert.Equal(departments.Count(), result.Count());
        }
        #endregion
    }
}
