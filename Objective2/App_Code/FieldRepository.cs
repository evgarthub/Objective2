using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for FieldRepository
/// </summary>
public class FieldRepository : RepositoryConnection, IRepository<Field>
{

    public void Add(Field entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Field entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Field> FindAll()
    {
        var command = "SELECT * FROM [Field]";
        var data = DB.Query(command);

        foreach (var item in data)
        {
            yield return new Field((DynamicRecord)item);
        }
    }

    public Field FindById(int Id)
    {
        string command = "SELECT * FROM [Field] WHERE Id=@0";
        var item = DB.QuerySingle(command, Id);
        return new Field(((DynamicRecord)item));
    }

    public void Update(Field entity)
    {
        throw new NotImplementedException();
    }
}