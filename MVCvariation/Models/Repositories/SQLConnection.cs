using System;
using System.Data.SqlClient;

namespace HomeIO.Models.Repositories
{
    public class SQLConnection
    {
        public SqlConnection DBInstance { get; set; }

        public SQLConnection() {
            this.DBInstance = new SqlConnection(
            "user id=dbuser;" +
            "password=admin;" +
            "server=UADEVYKIFIAK\SQLEXPRESS;" +
            "Trusted_Connection=yes;" +
            "database=homeio;" +
            "connection timeout=30");
        }

        public void Open() {
            try
            {
                DBInstance.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Close() {
            DBInstance.Close();
        }
    }
}