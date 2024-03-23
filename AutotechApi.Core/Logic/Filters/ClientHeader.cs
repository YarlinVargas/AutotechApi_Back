using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutotechApi.Core.Logic.Filters
{
    public class ClientHeader : Attribute, IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "client",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema() { Type = "string" }
            });
        }
    }
}
