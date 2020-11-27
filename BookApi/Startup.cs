using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace BookApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                // to generate enums as integer with descriptions remove this line and check
                // https://stackoverflow.com/questions/60222469/swagger-c-sharp-enum-generation-underlying-int-values-do-not-match-the-origina
                .AddJsonOptions(o => { o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                
                c.CustomOperationIds(apiDesc =>
                {
                    // use ControllerName_Method as operation id. That will group the methods in the generated client
                    if(apiDesc.ActionDescriptor is ControllerActionDescriptor desc)
                    {
                        return $"{desc.ControllerName}_{desc.ActionName}";
                    }

                    // otherwise get the method name from the methodInfo
                    var controller = apiDesc.ActionDescriptor.RouteValues["controller"];
                    apiDesc.TryGetMethodInfo(out MethodInfo methodInfo);
                    string methodName = methodInfo?.Name ?? null;

                    // Even when a custom Operation ID was assigned => group within the controller.
                    // Generally using the method name works well -> have not used this in a real service 
                    var customName = methodInfo.CustomAttributes.FirstOrDefault(a => a.AttributeType.Name == nameof(SwaggerOperationAttribute))?
                        .NamedArguments.FirstOrDefault(arg => arg.MemberName == "OperationId").TypedValue.Value.ToString();

                    return $"{controller}_{customName ?? methodName}";
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
