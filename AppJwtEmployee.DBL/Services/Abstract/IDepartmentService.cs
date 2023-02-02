using AppJwtEmployee.DBL.Dtos;
using AppJwtEmployee.DBL.Entities;
using AppJwtEmployee.DBL.Utility.Result.Abstract;

namespace AppJwtEmployee.DBL.Services.Abstract;

public interface IDepartmentService
{
    Task<IResultFactory<List<DepartmentDto>>> GetDepartmentsAsync();
    Task<IResultFactory<Department>> AddDepartment(AddDeparmentDto addDeparmentDto);
    Task<IResultFactory<DepartmentDto>> GetDepartmentById(int id);
    Task<IResultFactory<DepartmentDto>> DeleteDepartment(EditDepartmentDto deparmentDto);
    Task<IResultFactory<DepartmentDto>> UpdateDepartment(EditDepartmentDto deparmentDto);
}
