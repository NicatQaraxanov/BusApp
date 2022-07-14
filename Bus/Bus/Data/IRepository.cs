using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Data
{

    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query();

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);

        void SaveChanges();

    }

}
