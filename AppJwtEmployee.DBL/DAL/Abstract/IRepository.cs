using AppJwtEmployee.DBL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppJwtEmployee.DBL.DAL.Abstract;

public interface IRepository<TEntity,TDbContext>:IQueryRepository<TEntity, TDbContext> where TEntity : class,IBaseTable,new()
        where TDbContext : DbContext
{
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);

}
