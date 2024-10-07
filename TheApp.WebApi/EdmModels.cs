using System.Reflection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace TheApp.WebApi;

public static class EdmModels
{
    public static IEdmModel GetEntityModel()
    {
        var assembly = typeof(EdmModels).Assembly;
        
        var query =
            from type in assembly.GetTypes()
            let exposedAttribute = type.GetCustomAttribute<ExposedAttribute>()
            where exposedAttribute is not null
            select new
            {
                type,
                exposedAttribute.ControllerName
            };

        var viewsModelBuilder = new ODataConventionModelBuilder();

        foreach (var model in query)
        {
            var entityType = viewsModelBuilder.AddEntityType(model.type);
            viewsModelBuilder.AddEntitySet(model.ControllerName, entityType);
        }
        
        return viewsModelBuilder.GetEdmModel();
    }
}