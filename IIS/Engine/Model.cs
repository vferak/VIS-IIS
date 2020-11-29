using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IIS.Engine
{
    public abstract class Model<T>
    {
        [NotMapped]
        public Connection Connection { get; }
        
        [NotMapped]
        public Database<T> Database { get; }
        
        protected Model(Connection connection)
        {
            Connection = connection;
            Database = connection.Create(this);
        }

        public T LoadOne()
        {
            return Database.LoadOne();
        }

        public IEnumerable<T> Load()
        {
            return Database.Load();
        }

        public void Save()
        {
            Database.Save();
        }

        public void Delete()
        {
            Database.Delete();
        }
    }
}