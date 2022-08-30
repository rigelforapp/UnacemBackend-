using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel;

namespace UNACEM.API
{
    public class Startup
    {
        readonly string allowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
                 opts.UseSqlServer(
                     Configuration.GetConnectionString("BDUNACEM") //, x => x.MigrationsHistoryTable("__EFMigrationHistory")
                     )
                 );

            services.AddTransient<IFormatsQueryService, FormatsQueryService>();
            services.AddTransient<IOvensQueryService, OvensQueryService>();
            services.AddTransient<IProvidersQueryService, ProvidersQueryService>();
            services.AddTransient<IVersionQueryService, VersionQueryService>();
            services.AddTransient<IStretchsQueryService, StretchsQueryService>();
            services.AddTransient<IGalleryQueryService, GalleryQueryService>();
            services.AddTransient<IBudgetsQueryService, BudgetsQueryService>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UNACEM.API", Version = "v1" });


                services.AddCors();
                services.AddControllers();
                //services.AddCors(options =>
                //{
                //    options.AddPolicy(allowSpecificOrigins,
                //                          policy =>
                //                          {
                //                              policy.WithOrigins("http://localhost:5674")
                //                                                  .AllowAnyHeader()
                //                                                  .AllowAnyMethod();
                //                          });
                //});

                //var securitySchema = new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "bearer",
                //    Reference = new OpenApiReference
                //    {
                //        Type = ReferenceType.SecurityScheme,
                //        Id = "Bearer"
                //    }
                //};

                //c.AddSecurityDefinition("Bearer", securitySchema);

                //var securityRequirement = new OpenApiSecurityRequirement
                //{
                //    { securitySchema, new[] { "Bearer" } }
                //};

                //c.AddSecurityRequirement(securityRequirement);

            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , ApplicationDbContext dataContext)
        {
        

            dataContext.Database.Migrate();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .SetIsOriginAllowed(origin => true) // allow any origin
                   .AllowCredentials()); //
          //  app.UseCors(allowSpecificOrigins);
            //app.UseCors();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(Configuration.GetSection("VirtualDirectory").Value + "/swagger/v1/swagger.json", "ClientesExtranet.Api v1"));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
