using AppJwtEmployee.DBL.DAL.Abstract;
using AppJwtEmployee.DBL.DAL.Persistance.Context;
using AppJwtEmployee.DBL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.DAL.Persistance.Repositories.EmployeeRepsitory
{
    public class DepartmentRepository : GenericRepository<Department, EmpContext>, IDepartmentRepository
    {
        public DepartmentRepository(EmpContext dbContext) : base(dbContext)
        {
        }
    }
}
