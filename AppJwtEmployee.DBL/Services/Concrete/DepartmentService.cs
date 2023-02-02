using AppJwtEmployee.DBL.DAL.Abstract;
using AppJwtEmployee.DBL.Dtos;
using AppJwtEmployee.DBL.Entities;
using AppJwtEmployee.DBL.Services.Abstract;
using AppJwtEmployee.DBL.Utility.Result.Abstract;
using AppJwtEmployee.DBL.Utility.Result.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.Services.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper mapper;

        public DepartmentService(IDepartmentRepository departmentRepository,
                                 IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            this.mapper = mapper;
        }
        public async Task<IResultFactory<List<DepartmentDto>>> GetDepartmentsAsync()
        {
            var result = await _departmentRepository.GetListAsync(true);

            if (result is null)
            {
                return ResultInfo<List<DepartmentDto>>.NotFound("D-0001");
            }

            var departments = mapper.Map<List<DepartmentDto>>(result);
            return ResultInfo<List<DepartmentDto>>.Success("D-0004", departments);
        }


        public async Task<IResultFactory<Department>> AddDepartment(AddDeparmentDto addDeparmentDto)
        {
            if (addDeparmentDto is null)
            {
                return ResultInfo<Department>.NotFound("D-0003");
            }

            var addedDepartment = mapper.Map<Department>(addDeparmentDto);
            await _departmentRepository.Add(addedDepartment);

            return ResultInfo<Department>.Success("D-0002");
        }

        public async Task<IResultFactory<DepartmentDto>> GetDepartmentById(int id)
        {
            if (id == 0)
            {
                return ResultInfo<DepartmentDto>.BadRequest("C-0001");
            }

            var department = await _departmentRepository.GetByIdAsync(id, true);
            if (department is null)
            {
                return ResultInfo<DepartmentDto>.NotFound("D-0005");
            }

            var result = mapper.Map<DepartmentDto>(department);
            return ResultInfo<DepartmentDto>.Success("D-0004", result);

        }

        public async Task<IResultFactory<DepartmentDto>> UpdateDepartment(EditDepartmentDto deparmentDto)
        {
            var department = await _departmentRepository.GetAsync(x=>x.Id==deparmentDto.Id);
            if (department is null)
            {
                return ResultInfo<DepartmentDto>.NotFound("D-0005");
            }

            department.Name = deparmentDto.Name;

            await _departmentRepository.SaveChanges();
           
            return ResultInfo<DepartmentDto>.Success("D-0004", null);
        }

        public async Task<IResultFactory<DepartmentDto>> DeleteDepartment(EditDepartmentDto deparmentDto)
        {
            var department = await _departmentRepository.GetByIdAsync(deparmentDto.Id);
            if (department is null)
            {
                return ResultInfo<DepartmentDto>.NotFound("D-0005");
            }

            var result = mapper.Map<Department>(department);
            await _departmentRepository.Delete(result);
            return ResultInfo<DepartmentDto>.Success("D-0004", null);
        }
    }
}
