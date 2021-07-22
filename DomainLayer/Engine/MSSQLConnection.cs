using DomainLayer.Engine;

namespace DomainLayer.Engine
{
    public class MSSQLConnection : Connection
    {
        private string ConnectionString { get; set; }

        public MSSQLConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override Database<T> Create<T>(Model<T> model)
        {
            var database = new MSSQL<T>(model);
            database.SetConnectionString(ConnectionString);
            return database;
        }
    }
}