using AppJwtEmployee.DBL.Dtos;
using AppJwtEmployee.DBL.Extensions;
using AppJwtEmployee.DBL.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Employee.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpPost]
        public IActionResult Add(AddEmployeeDto employee)
        {
            var service = employeeService.AddEmployee(employee);
            return service.AsObjectResult();
        }
    }
}
