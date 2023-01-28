using AppJwtEmployee.DBL.DAL.Persistance.Context;
using AppJwtEmployee.DBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.DAL.Abstract
{
    public interface IEmployeeRepository:IRepository<Employee,EmpContext>
    {
        Task<Employee> GetEmployeeByDepartmentId(int departmentId);
        Task<IEnumerable<Employee>> GetEmployeeWithDepartment();
    }
}
