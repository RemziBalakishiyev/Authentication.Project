using AppJwtEmployee.DBL.Entities.Abstract;

namespace AppJwtEmployee.DBL.Entities;

public class Employee: IBaseTable
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public float? Salary { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}
