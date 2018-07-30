using System;
using System.Collections.Generic;
using WebMatrix.Data;

public class CategoryRepository : RepositoryConnection, IRepository<Category>
{
    public string dbName = "[Category]";

    public void Add(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> FindAll()
    {
        var command = "SELECT * FROM " + dbName;
        var data = DB.Query(command);

        foreach (var item in data)
        {
            yield return new Category((DynamicRecord)item);
        }
    }

    public Category FindById(int Id)
    {
        string command = "SELECT * FROM " + dbName + " WHERE Id=@0";
        var item = DB.QuerySingle(command, Id);
        return new Category(((DynamicRecord)item));
    }

    public void Update(Category entity)
    {
        throw new NotImplementedException();
    }
}