using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyHoursApi.Models;
using Microsoft.EntityFrameworkCore;
using MyHoursApi.Repositories;

using GraphQL;
using GraphQL.Server.Ui.Playground;
using MyHoursApi.GraphQL;
using GraphQL.Server;
using GraphQL.Server.Transports.WebSockets;
using Microsoft.AspNetCore.Server.Kestrel.Core;



namespace MyHoursApi
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(
                options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention()
            );

            //graphql dependecy inyection
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<MyHourSchema>();
            services.AddScoped<UserRepository>();
            services.AddScoped<ProjectRepository>();
            services.AddScoped<RelationRepository>();

            services.AddGraphQL(options => { options.ExposeExceptions = true; })
            .AddGraphTypes(ServiceLifetime.Scoped);


            services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });
            // services.AddAuthentication("Bearer")
            //     .AddJwtBearer("Bearer", options =>
            //         {
            //             options.Authority = "https://localhost:5001";
            //             options.Audience = "graphql";
            //         });

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyHoursApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyHoursApi v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseGraphQL<MyHourSchema>();

            // app.UseGraphQLPlayground(new GraphQLPlaygroundOptions{
            //      Path = "/ui/playground"
            // });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
