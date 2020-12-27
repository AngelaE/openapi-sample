using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace BookApi.OpenApi
{
    public class ClientHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-Detailed-Logs",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "boolean" }
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-Correlation-Id",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "string" }
            });
        }
    }
}
