using System.Collections.Generic;

public interface IRepository<T> where T: IEntity
{
    IEnumerable<T> FindAll();
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    T FindById(int Id);
}