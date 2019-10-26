using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using products_api.Products.API.Interfaces;
using products_api.Products.API.Interfaces.Queries;
using products_api.Products.Domain.Interfaces;
using products_api.Products.Domain.Services;
using products_api.Products.Infrastructure.Context;
using products_api.Products.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace products_api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddCors(options => 
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("https://distributor-dev.zymoresearch.com/", 
                                                    "https://localhost:4200/", 
                                                    "http://localhost:3002", 
                                                    "https://localhost:5001")
                                        .AllowAnyHeader()
                                        .WithMethods("GET", "POST", "PUT", "DELETE"));
            });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Products API", 
                    Version = "v1",
                    Description = "Product API to interface with Product Database"
                    }
                );
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            

            services.AddTransient<IProductContext, ProductContext>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            services.AddScoped<IKitQueries, KitsRepository>();
            services.AddScoped<IComponentQueries, ComponentsRepository>();

            services.AddScoped<IKitService, KitService>();
            services.AddScoped<IComponentService, ComponentService>();
            services.AddScoped<IKitsRepository, KitsRepository>();
            services.AddScoped<IComponentsRepository, ComponentsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c => {
                    c.RouteTemplate = "api-docs/{documentName}/products.json";
                });

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.DisplayOperationId();
                    c.SwaggerEndpoint("/api-docs/v1/products.json", "Product API V1");
                    c.RoutePrefix = string.Empty;
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");

            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
