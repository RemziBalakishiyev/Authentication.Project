using AppJwtEmployee.DBL.DAL.Abstract;
using AppJwtEmployee.DBL.Dtos;
using AppJwtEmployee.DBL.Entities;
using AppJwtEmployee.DBL.Services.Abstract;
using AppJwtEmployee.DBL.Utility.Result.Abstract;
using AppJwtEmployee.DBL.Utility.Result.Concrete;
using AutoMapper;

namespace AppJwtEmployee.DBL.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public IResultFactory<Employee> AddEmployee(AddEmployeeDto employee)
        {
            var emp= _mapper.Map<Employee>(employee);
            _employeeRepository.Add(emp);
            return ResultInfo<Employee>.Success("Employee added successfully");
        }


    }
}
