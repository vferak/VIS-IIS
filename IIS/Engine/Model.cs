namespace IIS.Engine
{
    public abstract class Model<T>
    {
        public Database<T> Connection { get; set; }

        protected Model(Database<T> connection)
        {
            Connection = connection;
            connection.Model = this;
        }
    }
}