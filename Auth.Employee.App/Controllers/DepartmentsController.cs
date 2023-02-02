using AppJwtEmployee.DBL.Dtos;
using AppJwtEmployee.DBL.Extensions;
using AppJwtEmployee.DBL.Services.Abstract;
using AppJwtEmployee.DBL.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Employee.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        /// <summary>
        /// Bütün department-ləri gətirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("Getall")]
        public async Task<IActionResult> GetDepartment()
        {
            var result =  await _departmentService.GetDepartmentsAsync();
            return result.AsObjectResult();
        }   

        /// <summary>
        /// Bütün department-ləri gətirir
        /// </summary>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddDepartment(AddDeparmentDto addDeparmentDto)
        {
            var result = await _departmentService.AddDepartment(addDeparmentDto);
            return result.AsObjectResult();
        }

        [HttpGet("getbyid/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _departmentService.GetDepartmentById(id);
            return result.AsObjectResult();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDepartment(EditDepartmentDto departmentDto)
        {
            var result = await _departmentService.UpdateDepartment(departmentDto);
            return result.AsObjectResult();
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteDepartment(EditDepartmentDto departmentDto)
        {
            var result = await _departmentService.DeleteDepartment(departmentDto);
            return result.AsObjectResult();
        }



    }
}
