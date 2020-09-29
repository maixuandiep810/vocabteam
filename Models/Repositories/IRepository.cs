using System.Linq;

namespace vocabteam.Models.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(int id, bool isActive = true);
        void Insert(T entity, bool saveChange = true);
        void Update(T entity, bool saveChange = true);
        void Delete(T entity, bool saveChange = true);
    }

}