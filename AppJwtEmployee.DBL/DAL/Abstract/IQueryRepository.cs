using AppJwtEmployee.DBL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.DAL.Abstract
{
    public interface IQueryRepository<T,TDbContext> 
        where TDbContext : DbContext
         where T : class, IBaseTable, new()
    {
        Task<List<T>> ExecuteProcedure(string procedureName, SqlParameter[] parameters, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> condition = null, CancellationToken cancellationToken = default);
        Task<T> GetAsync(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes=null, bool asNoTracking = false, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(object id, bool asNoTracking = false, CancellationToken cancellationToken = default);
        Task<List<T>> GetFromRawSqlAsync(string sql, SqlParameter[] parameters = null, CancellationToken cancellationToken = default);
        Task<List<T>> GetListAsync(bool asNoTracking=false, CancellationToken cancellationToken = default);
        IQueryable<T> GetQueryable();
    }


}
