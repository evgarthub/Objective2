using DataLayer;
using HomeIO.Models.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HomeIO.Models.Repositories
{
    public class TypeRepository : SQLConnection, IRepository<Type>
    {
        public void Create(Type entity)
        {
            Open();
            SqlCommand command = new SqlCommand();

            command.Connection = DBInstance;
            command.CommandText = "INSERT INTO[Jobs]([Title],[SalaryAvarage],[English],[CategoryId],[FieldId],[Keywords],[Education]) VALUES(@0, @1, @2, @3, @4, @5, @6)";
            command.ExecuteNonQuery();
        }

        public void Delete(Type entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Type> GetAll()
        {
            throw new NotImplementedException();
        }

        public Type GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Type entity)
        {
            throw new NotImplementedException();
        }
    }
}