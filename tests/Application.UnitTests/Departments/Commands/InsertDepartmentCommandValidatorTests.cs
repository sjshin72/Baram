using Baram.Application.Departments.Commands;
using FluentValidation.TestHelper;
using System.Threading.Tasks;
using Xunit;

namespace Baram.Application.UnitTests.Departments.Commands
{
    public class InsertDepartmentCommandValidatorTests
    {
        private InsertDepartmentCommandValidator Validator;
        public InsertDepartmentCommandValidatorTests()
        {
            Validator = new InsertDepartmentCommandValidator();
        }

        #region Tests
        [Fact]
        public async Task DepartmentNameShouldValid()
        {
            // Arrange
            var command = new InsertDepartmentCommand { 
                Name = "Test department"
            };

            // Act
            var result = await Validator.ValidateAsync(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ShouldHaveErrorWhenDepartmentNameIsEmpty()
        {
            // Arrange
            var command = new InsertDepartmentCommand
            {
                Name = string.Empty
            };

            // Act
            var result = await Validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveValidationErrorFor(command => command.Name);
        }
        #endregion
    }
}
