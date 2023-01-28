using AppJwtEmployee.DBL.DAL.Abstract;
using AppJwtEmployee.DBL.Dtos;
using AppJwtEmployee.DBL.Entities;
using AppJwtEmployee.DBL.Utility.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.Services.Abstract;

public interface IEmployeeService
{
    IResultFactory<Employee> AddEmployee(AddEmployeeDto employee);
}
