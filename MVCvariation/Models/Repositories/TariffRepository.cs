using DataLayer;
using HomeIO.Models.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HomeIO.Models.Repositories
{
    public class TariffRepository : SQLConnection, IRepository<Tariff>
    {
        public void Create(Tariff entity)
        {
            Open();
            SqlCommand command = new SqlCommand();

            command.Connection = DBInstance;
            command.CommandText = "INSERT INTO[Tariffs]([TypeId],[Unit],[Cost],[StartDate],[SourceId]) VALUES(@tariffTypeId, @tariffUnit, @tariffCost, @tariffDate, @tariffSourceId)";
            command.Parameters.AddWithValue("tariffTypeId", entity.TypeId);
            command.Parameters.AddWithValue("tariffUnit", entity.Unit);
            command.Parameters.AddWithValue("tariffCost", entity.Cost);
            command.Parameters.AddWithValue("tariffDate", entity.Date);
            command.Parameters.AddWithValue("tariffSourceId", entity.SourceId);
            command.ExecuteNonQuery();

            Close();
        }

        public void Delete(Tariff entity)
        {
            Open();
            SqlCommand command = new SqlCommand();

            command.Connection = DBInstance;
            command.CommandText = "DELETE FROM [Tariffs] WHERE Id = @tariffId";
            command.Parameters.AddWithValue("tariffId", entity.Id);
            command.ExecuteNonQuery();

            Close();
        }

        public void Delete(int id)
        {
            Open();
            SqlCommand command = new SqlCommand();

            command.Connection = DBInstance;
            command.CommandText = "DELETE FROM [Tariffs] WHERE Id = @tariffId";
            command.Parameters.AddWithValue("tariffId", id);
            command.ExecuteNonQuery();

            Close();
        }

        public IList<Tariff> GetAll()
        {
            Open();
            SqlCommand command = new SqlCommand();

            command.Connection = DBInstance;
            command.CommandText = "SELECT [TypeId],[Unit],[Cost],[StartDate],[SourceId] FROM [Tariffs]";
            SqlDataReader reader = command.ExecuteReader();

            IList<Tariff> rows = new List<Tariff>();

            while (reader.Read())
            {
                rows.Add(new Tariff
                {
                    Id = reader.GetInt16(0),
                    TypeId = reader.GetInt16(1),
                    Unit = reader.GetString(2),
                    Cost = reader.GetDouble(3),
                    Date = reader.GetDateTime(4),
                    SourceId = reader.GetInt16(5)
                });
            }

            Close();

            return rows;
        }

        public Tariff GetById(int id)
        {
            Open();
            SqlCommand command = new SqlCommand();

            command.Connection = DBInstance;
            command.CommandText = "SELECT [TypeId],[Unit],[Cost],[StartDate],[SourceId] FROM [Tariffs]";
            SqlDataReader reader = command.ExecuteReader();

            Tariff row = new Tariff
            {
                Id = reader.GetInt16(0),
                TypeId = reader.GetInt16(1),
                Unit = reader.GetString(2),
                Cost = reader.GetDouble(3),
                Date = reader.GetDateTime(4),
                SourceId = reader.GetInt16(5)
            };

            Close();

            return row;
        }

        public void Update(Tariff entity)
        {
            Open();
            SqlCommand command = new SqlCommand();

            command.Connection = DBInstance;
            command.CommandText = "UPDATE [Tariffs] SET [TypeId] = @tariffTypeId,[Unit] = @tariffUnit,[Cost] = @tariffCost,[StartDate] = @tariffDate,[SourceId] = @tariffSourceId WHERE Id = @tariffId";
            command.Parameters.AddWithValue("tariffId", entity.Id);
            command.Parameters.AddWithValue("tariffTypeId", entity.TypeId);
            command.Parameters.AddWithValue("tariffUnit", entity.Unit);
            command.Parameters.AddWithValue("tariffCost", entity.Cost);
            command.Parameters.AddWithValue("tariffDate", entity.Date);
            command.Parameters.AddWithValue("tariffSourceId", entity.SourceId);
            command.ExecuteNonQuery();

            Close();
        }
    }
}