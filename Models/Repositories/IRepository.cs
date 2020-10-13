using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace vocabteam.Models.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity, bool saveChange = true);
        void Delete(T entity, bool saveChange = true);
        IEnumerable<T> Filter(Expression<Func<T, bool>> filter);

    }

}