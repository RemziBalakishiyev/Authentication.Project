using AppJwtEmployee.DBL.AutoMapper;
using AppJwtEmployee.DBL.Entities;
using AutoMapper;

namespace AppJwtEmployee.DBL.Dtos
{
    public class AddEmployeeDto:IHaveCustomMappings
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Salary { get; set; }
        public int DepartmentId { get; set; }

        public void CreateMappings(Profile configuration)
        {
           configuration.CreateMap<AddEmployeeDto, Employee>()
                .ForMember(x=>x.Salary,opt=>opt.MapFrom(x=>x.Salary+20));
        }
    }
}
