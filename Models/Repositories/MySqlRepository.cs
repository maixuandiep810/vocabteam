using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using vocabteam.Helpers;

namespace vocabteam.Models.Repositories
{
    public class MySqlRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly VocabteamContext _context;
        protected DbSet<T> entities;
        string errorMessage = string.Empty;

        public MySqlRepository(VocabteamContext context)
        {
            this._context = context;
            entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            IQueryable<T> result;
            try
            {
                result = entities.AsQueryable();
            }
            catch (System.Exception)
            {
                throw new RepositoryException001();
            }

            return result;
        }

        public T GetById(int id)
        {
            T result;
            try
            {
                result = entities.FirstOrDefault(s => s.Id == id);
            }
            catch (System.Exception)
            {
                throw new RepositoryException001();
            }

            return result;
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                entity.CreatedTime = DateTime.Now;
                entity.UpdatedTime = DateTime.Now;
                entities.Add(entity);
                int a = this._context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw new RepositoryException001();
            }
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                entity.UpdatedTime = DateTime.Now;
                this._context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw new RepositoryException001();
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw new RepositoryException001();
            }
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> filter)
        {
            IEnumerable<T> result;
            try
            {
                result = entities.Where(filter);
            }
            catch (System.Exception)
            {
                throw new RepositoryException001();
            }

            return result;
        }
    }
}