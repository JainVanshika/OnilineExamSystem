using Microsoft.EntityFrameworkCore;
using OnlineExam.DataAccess.Repository.IRepository;
using OnlineExamination.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context= context;
            this.dbSet= _context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query=dbSet;
            if (filter != null)
            {
                query=query.Where(filter);
            }
            if(includeProperties!= null)
            {
                foreach(var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            IQueryable<T> query;
            if(tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            query=query.Where(filter);
            if(includeProperties!=null)
            {
                foreach(var includeprop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }
            return query.FirstOrDefault();
        }

        public void RangeRemove(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
