using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using DomainLayer.Engine;

namespace DomainLayer.Engine
{
    public abstract class Database<T>
    {
        public Model<T> Model { get; set; }
        public abstract T LoadOne();

        public abstract IEnumerable<T> Load();

        public abstract void Save();

        public abstract void Delete();
        
        public Database(Model<T> model)
        {
            Model = model;
        }
        
        protected bool IsInsert()
        {
            var model = (T)Activator.CreateInstance(typeof(T), Model.Connection);
            foreach (var property in typeof(T).GetProperties())
            {
                if (!PropertyIsKey(property)) continue;

                var keyValue = property.GetValue(Model, null);
                
                if (keyValue == null)
                {
                    return true;
                }

                property.SetValue(model, keyValue);
                break;
            }

            var database = (Database<T>) model?.GetType().GetProperty("Database")?.GetValue(model);

            if (database == null)
            {
                throw new Exception("Unknown generic class");
            }
            
            return database.LoadOne() == null;
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
        
        protected static bool PropertyIsNotMapped(PropertyInfo property)
        {
            return Attribute.IsDefined(property, typeof(NotMappedAttribute));
        }

        protected string FormatDateTimeString(string dateTime)
        {
            return DateTime.Parse(dateTime).ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}