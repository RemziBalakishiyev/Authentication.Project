using AppJwtEmployee.DBL.DAL.Persistance.Context;
using AppJwtEmployee.DBL.Entities;

namespace AppJwtEmployee.DBL.DAL.Abstract;

public interface IDepartmentRepository:IRepository<Department,EmpContext>
{

}
