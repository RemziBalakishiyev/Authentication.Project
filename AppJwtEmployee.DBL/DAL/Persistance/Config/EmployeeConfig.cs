using AppJwtEmployee.DBL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppJwtEmployee.DBL.DAL.Persistance.Config;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).HasColumnName("FIRS_NAME");
        builder.Property(x => x.LastName).HasColumnName("LAST_NAME");
        builder.Property(x => x.Salary).HasColumnName("SALARY");
        builder.Property(x => x.BirthDate).HasColumnName("BIRTH_DATE");

        builder.HasOne(x => x.Department).WithMany(x => x.Employees).HasForeignKey(x => x.DepartmentId);
    }
}
