using System.ComponentModel.DataAnnotations.Schema;

namespace IIS.Engine
{
    public abstract class Model<T>
    {
        [NotMapped]
        public Database<T> Connection { get; set; }

        protected Model(Database<T> connection)
        {
            Connection = connection;
            connection.Model = this;
        }
    }
}