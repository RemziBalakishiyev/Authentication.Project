using AppJwtEmployee.DBL.Entities;
using AppJwtEmployee.DBL.Utility.Helper.FileOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection;

namespace AppJwtEmployee.DBL.DAL.Persistance.Context;

public class EmpContext:DbContext
{
    public EmpContext()
    {

    }
    public EmpContext(DbContextOptions<EmpContext> options)
        : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetJson.ConnectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
            t => t.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
    }
}
