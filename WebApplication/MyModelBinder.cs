using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using DomainLayer.Engine;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication
{
    public class MyModelBinder : IModelBinder
    {
        private readonly Connection _connection;
        
        public MyModelBinder(Connection connection)
        {
            _connection = connection;
        }
        
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelType = bindingContext.ModelType;
            var model = Activator.CreateInstance(modelType, _connection);

            foreach (var property in modelType.GetProperties())
            {
                if (Attribute.IsDefined(property, typeof(NotMappedAttribute))) continue;
                
                var value = bindingContext.ValueProvider.GetValue(property.Name).FirstValue;
                var converter = TypeDescriptor.GetConverter(property.PropertyType);
                property.SetValue(model, string.IsNullOrWhiteSpace(value) ? null : converter.ConvertFromString(value));
            }
            
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}