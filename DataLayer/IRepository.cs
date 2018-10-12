using System.Collections.Generic;

namespace DataLayer
{

    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Update(T entity);
    }

}

