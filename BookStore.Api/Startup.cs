using System;
using AutoMapper;
using BookStore.Business;
using BookStore.Business.Middleware;
using BookStore.Business.Services;
using BookStore.Business.Services.Abstracts;
using BookStore.Business.Services.Concretes;
using BookStore.Entity.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace BookStoreMap
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());


            services.AddTransient<ILogService, LogService>();

            //CORS policy
            services.AddCors(setupAction =>
            {
                setupAction.AddPolicy("BookStorePolicy", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(Configuration.GetValue<string>("WebUrl"))
                        .AllowCredentials();
                });
            });

            //PostgreSQL connection
            var connectionString = Configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<BookDbContext>(options =>
                options.UseNpgsql(connectionString,
                    b => b.MigrationsAssembly("BookStore.Api")));

            //Services with Dependency Injection
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IResultService, ResultService>();

            //Swagger Connection
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new Info
                {
                    Title = "BookMap Store Api",
                    Version = "1.0.0"
                });
            });

            //AutoMapper Integration
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ApiLoggingMiddleware>();
            app.UseCors("BookStorePolicy");
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "BookStoreMap");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}