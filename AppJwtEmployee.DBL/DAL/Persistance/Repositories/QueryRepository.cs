using AppJwtEmployee.DBL.DAL.Abstract;
using AppJwtEmployee.DBL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.DAL.Persistance.Repositories
{
    public class QueryRepository<T,TDbContext> : IQueryRepository<T, TDbContext>
         where T : class, IBaseTable, new() 
        where TDbContext : DbContext
    {

        private readonly TDbContext _dbContext;

        public QueryRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbContext.Set<T>();
        }

        public async Task<List<T>> GetListAsync(
            bool asNoTracking=false,
            CancellationToken cancellationToken = default)
            
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            List<T> items = await query.ToListAsync(cancellationToken).ConfigureAwait(false);

            return items;
        }




        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> condition = null, CancellationToken cancellationToken = default)
    
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (condition == null)
            {
                return await query.AnyAsync(cancellationToken);
            }

            bool isExists = await query.AnyAsync(condition, cancellationToken).ConfigureAwait(false);
            return isExists;
        }


        public async Task<T> GetAsync(
           Expression<Func<T, bool>> condition = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> includes=null,
           bool asNoTracking = false,
           CancellationToken cancellationToken = default)
          
        {
            IQueryable<T> query = _dbContext.Set<T>();


            if (includes != null)
            {
                query = includes(query);
            }

            if (condition != null)
            {
                query = query.Where(condition);
            }
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }


        public async Task<T> GetByIdAsync(
           object id,
           bool asNoTracking = false,
           CancellationToken cancellationToken = default)
       
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var query = _dbContext.Set<T>();
            return await query.FindAsync(id);
        }


        public async Task<List<T>> ExecuteProcedure(
           string procedureName,
            SqlParameter[] parameters,
             CancellationToken cancellationToken = default)
        {
            if (parameters != null
                && parameters.Any(p => p.Value == null))
            {
                return new List<T>();
            }

            IQueryable<T> query = _dbContext.Set<T>();


            var parametersStr = parameters != null
                ? string.Join(", ", parameters.Select(p => $"@{p.ParameterName} = @{p.ParameterName}"))
                : "";
            var sql =
                $"exec {procedureName} {parametersStr}";
            var parametersList = new List<object>();

            if (parameters != null)
            {
                parametersList.AddRange(parameters);
            }

            return await GetFromRawSqlAsync(sql, parameters, cancellationToken);
        }

        public static IList<T> ExecuteProcedure(
            string procedureName,
            IList<SqlParameter> parameters)
        {
            return ExecuteProcedure(procedureName, parameters.ToArray());
        }





        public Task<List<T>> GetFromRawSqlAsync(string sql, SqlParameter[] parameters = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }




            var parametersStr = parameters != null
                ? string.Join(", ", parameters.Select(p => $"@{p.ParameterName} = @{p.ParameterName}"))
                : "";

            var parametersList = new List<object>();

            if (parameters != null)
            {
                parametersList.AddRange(parameters);
                return _dbContext.Set<T>().FromSqlRaw(sql, parametersList.ToArray()).ToListAsync();
            }


            return _dbContext.Set<T>().FromSqlRaw(sql).ToListAsync();


        }






    }
}
