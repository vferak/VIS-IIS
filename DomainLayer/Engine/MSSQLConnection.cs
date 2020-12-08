using DomainLayer.Engine;

namespace DomainLayer.Engine
{
    public class MSSQLConnection : Connection
    {
        public override Database<T> Create<T>(Model<T> model)
        {
            return new MSSQL<T>(model);
        }
    }
}