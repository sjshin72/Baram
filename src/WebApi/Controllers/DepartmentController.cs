using Baram.Application.Departments.Commands;
using Baram.Application.Departments.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class DepartmentController: ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok(await Mediator.Send(new GetDepartmentsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(InsertDepartmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
