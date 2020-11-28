using System.Collections.Generic;

namespace IIS.Engine
{
    public interface IDatabase<out T>
    {
        T LoadOne();
        IEnumerable<T> Load();
        void Save();
        
        void Delete();
    }
}