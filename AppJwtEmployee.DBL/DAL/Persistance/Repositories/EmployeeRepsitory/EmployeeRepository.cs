using AppJwtEmployee.DBL.DAL.Abstract;
using AppJwtEmployee.DBL.DAL.Persistance.Context;
using AppJwtEmployee.DBL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.DAL.Persistance.Repositories.EmployeeRepsitory
{
    public class EmployeeRepository : GenericRepository<Employee, EmpContext>,IEmployeeRepository
    {
        public EmployeeRepository(EmpContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetEmployeeWithDepartment()
        {
            var result = GetQueryable()
                .Include(X => X.Department)
                .ToListAsync();

            return await result; 
        }

        public async Task<Employee> GetEmployeeByDepartmentId(int departmentId)
        {
            var result = GetAsync(
                    x => x.DepartmentId == departmentId,
                    x=>x.Include(x=>x.Department)
                );
            return await result;
        }
    }
}
