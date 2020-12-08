using DomainLayer.Engine;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace WebApplication
{
    public class MyModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var baseType = context.Metadata.ModelType.BaseType;
            
            if (baseType is { } && baseType.IsGenericType 
                && baseType.GetGenericTypeDefinition().IsAssignableFrom(typeof(Model<>)))
            {
                return new BinderTypeModelBinder(typeof(MyModelBinder));
            }

            return null;
        }
    }
}