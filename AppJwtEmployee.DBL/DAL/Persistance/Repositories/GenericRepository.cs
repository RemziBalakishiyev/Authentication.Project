using AppJwtEmployee.DBL.DAL.Abstract;
using AppJwtEmployee.DBL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.DAL.Persistance.Repositories
{
    public class GenericRepository<TEntity,TDbContext> : QueryRepository<TEntity, TDbContext>,IRepository<TEntity, TDbContext>
        where TDbContext : DbContext
        where TEntity : class, IBaseTable, new()
    {
        private readonly TDbContext _dbContext;
        public GenericRepository(TDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(TEntity entity)
            {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
             _dbContext.Remove(entity);
           await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
             _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
