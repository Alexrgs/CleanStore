using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Domain;
using Store.Persistence;
using System.Reflection;
using Store.Application.Infrastructure.AutoMapper;
using Store.Application.Abstractions;
using Store.Common;
using Store.Infrastructure;
using Store.Application.Products.Queries.GetAllProducts;
using Store.Application.Infrastructure;
using Store.WebUI.Filters;
using Store.Application.Cart.Commands.AddProduct;
using Microsoft.AspNetCore.Mvc;
using NJsonSchema.Generation;
using NSwag;
using System.Collections.Generic;
using System.Linq;
using NSwag.Generation.Processors.Security;
using NSwag.AspNetCore;
using IdentityServer4.EntityFramework.Entities;
using static IdentityModel.OidcConstants;

namespace Store.WebUI
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
            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add framework services.
            //services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();

            // Add MediatR
            services.AddMediatR(typeof(GetAllProductsQueryHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddDbContext<IStoreDbContext, StoreDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("StoreDatabase")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<StoreDbContext>();

             services.AddIdentityServer()
               .AddApiAuthorization<ApplicationUser, StoreDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
         
            services
               .AddMvc(options => {
                   options.Filters.Add(typeof(CustomExceptionFilterAttribute));
                   options.EnableEndpointRouting = false;
                   })
               .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddProductCommandValidator>());

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            // Register the Swagger services
            services.AddOpenApiDocument(document =>
            {
                document.AddSecurity("bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Description = "My Authentication",
                    Flow = OpenApiOAuth2Flow.Implicit,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            Scopes = new Dictionary<string, string> { { "demo_api", "Demo API - full access" } },
                            AuthorizationUrl = "https://localhost:44319/connect/authorize",
                            TokenUrl = "https://localhost:44319/connect/token",
                        },
                    },
                });

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("bearer"));
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();
            app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            if (env.IsDevelopment())
            {
                app.UseOpenApi(); // serve OpenAPI/Swagger documents
                app.UseSwaggerUi3(); // serve Swagger UI
                                     // app.UseReDoc(); // Serve redoc
            }


           
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //more info at: https://docs.microsoft.com/en-ca/aspnet/core/client-side/spa/react?view=aspnetcore-2.2&tabs=visual-studio
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                  //  spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
