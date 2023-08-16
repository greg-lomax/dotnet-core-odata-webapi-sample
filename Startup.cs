using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using odata_error.Models;
using odata_error.Swagger;
using System.Collections.Generic;


namespace odata_error
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
            services
                .AddDbContext<TestDbContext>(opt => opt.UseSqlite("Filename=./testdata.db3"))
                .AddControllers()
                .AddOData(opt =>
                {
                    opt
                        .Select()
                        .Filter()
                        .Expand()
                        .OrderBy()
                        .Count()
                        .SetMaxTop(5000)
                        .AddRouteComponents("odata", GetEdmModel());
                });

            services.AddSwaggerGen(config =>
            {
                config.OperationFilter<ODataParametersSwaggerDefinition>();
            });
        }


        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<AzureClassUser>("AzureClassUsers");
            builder.EntitySet<ConfigNode>("ConfigNodes");

            var model = (EdmModel)builder.GetEdmModel();

            // var configNode = model.FindDeclaredEntitySet("ConfigNodes").EntityType();
            // var parentCodeProperty = configNode.FindProperty("ParentCode");
            // var codeProperty = configNode.FindProperty("Code");

            // model.AddAlternateKeyAnnotation(configNode, new Dictionary<string, IEdmProperty>()
            // {
            //     {"ParentCode", parentCodeProperty },
            //     {"Code" , codeProperty}
            // });

            return model;
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OData 8.x OpenAPI");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }



    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }


}
