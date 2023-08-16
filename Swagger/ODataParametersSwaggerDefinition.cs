using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;


namespace odata_error.Swagger
{
    public class ODataParametersSwaggerDefinition : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.ReturnType.GetInterfaces().Any(i => i == typeof(IQueryable)))
            {
                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$filter",
                    Description = "My $filter filter",
                    Required = false,
                    In = ParameterLocation.Query,
                });

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$top",
                    Description = "My $top filter",
                    Required = false,
                    In = ParameterLocation.Query,
                });

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$expand",
                    Description = "My $expand filter",
                    Required = false,
                    In = ParameterLocation.Query,
                });

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$select",
                    Description = "My $select filter",
                    Required = false,
                    In = ParameterLocation.Query,
                });

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "orderby",
                    Description = "My $orderby filter",
                    Required = false,
                    In = ParameterLocation.Query,
                });
            }
        }
    }


}
