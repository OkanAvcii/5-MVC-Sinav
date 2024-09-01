using BlogApp.Dal.Contexts;
using BlogApp.Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Dal.Concrete
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public BaseRepo(AppDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public int Create(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            _table.Remove(entity);
            return _context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _table.ToList();
        }

        public bool GetAny(Expression<Func<T, bool>> expression)
        {
            return _table.Any(expression);
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public TResult GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = _table;
            if (join != null)
                query = join(query);
            if (where != null)
                query = query.Where(where);
            if (orderBy != null)
                return orderBy(query).Select(select).FirstOrDefault();
            else
                return query.Select(select).FirstOrDefault();
        }

        public IList<TResult> GetFilteredList<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = _table;
            if (join != null)
                query = join(query);
            if (where != null)
                query = query.Where(where);
            if (orderBy != null)
                return orderBy(query).Select(select).ToList();
            else
                return query.Select(select).ToList();
        }

        public int Update(T entity)
        {
            _table.Update(entity);
            return _context.SaveChanges();
        }
    }
}
