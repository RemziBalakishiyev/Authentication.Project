using AppJwtEmployee.DBL.Entities.Abstract;

namespace AppJwtEmployee.DBL.Entities;

public class Department:IBaseTable
{

    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Employee> Employees { get; set; }
}

