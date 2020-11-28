using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IIS.Engine
{
    public abstract class Database<T> : IDatabase<T>
    {
        public Model<T> Model { get; set; }
        public abstract T LoadOne();

        public abstract IEnumerable<T> Load();

        public abstract void Save();

        public abstract void Delete();
        
        protected bool IsInsert()
        {
            var database = Activator.CreateInstance(GetType());
            var model = (T)Activator.CreateInstance(typeof(T), database);
            foreach (var property in typeof(T).GetProperties())
            {
                if (!PropertyIsKey(property)) continue;
                
                if (property.GetValue(Model, null) == null)
                {
                    return true;
                }

                property.SetValue(model, property.GetValue(Model, null));
            }

            var connection = (IDatabase<T>) model?.GetType().GetProperty("Connection")?.GetValue(model);

            if (connection == null)
            {
                throw new Exception("Unknown generic class");
            }
            
            return connection.LoadOne() == null;
        }
        
        protected static bool PropertyIsKey(PropertyInfo property)
        {
            return Attribute.IsDefined(property, typeof(KeyAttribute));
        }

        protected static bool PropertyIsRequired(PropertyInfo property)
        {
            return Attribute.IsDefined(property, typeof(RequiredAttribute));
        }

        protected static bool PropertyIsEditable(PropertyInfo property)
        {
            var attribute = (EditableAttribute) Attribute.GetCustomAttribute(property, typeof(EditableAttribute));
            return attribute == null || attribute.AllowEdit;
        }
    }
}