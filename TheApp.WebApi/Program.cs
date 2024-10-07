using Microsoft.AspNetCore.OData;
using TheApp.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddOData(options =>
    {
        options
            .Select().Filter().OrderBy().Expand().Count().SetMaxTop(null)
            .AddRouteComponents("odata", EdmModels.GetEntityModel());
    });

var app = builder.Build();

//app.UseODataRouteDebug();
        
app.UseRouting();

app.MapControllers();

app.Run();

namespace TheApp.WebApi
{
    public partial class Program;
}
