using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace BookApi.OpenApi
{
    public class BearerTokenOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            var parameter = new OpenApiParameter
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "string"}
            };
            operation.Parameters.Add(parameter);
        }
    }

}
