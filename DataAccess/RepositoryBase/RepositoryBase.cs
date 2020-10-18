using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.RepositoryBase
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext AppDbContext { get; set; }
        public RepositoryBase(ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public IQueryable<T> FindAll()
        {
            return AppDbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return AppDbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            AppDbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            AppDbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            AppDbContext.Set<T>().Remove(entity);
        }
    }
}