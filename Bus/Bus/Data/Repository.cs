using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public DbContext Context { get; }

        public DbSet<T> DbSet { get; }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public IQueryable<T> Query()
        {
            return DbSet;
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

    }

}
