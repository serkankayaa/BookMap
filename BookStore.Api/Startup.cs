using System;
using System.Text;
using System.Threading.Tasks;
using BookStore.Api;
using BookStore.Business;
using BookStore.Business.Services;
using BookStore.Entity.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //Authentication
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    //Token Validation Settings
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = ctx =>
                        {
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = ctx =>
                        {
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = ctx =>
                        {  
                            Console.WriteLine($"Exception : {ctx.Exception.Message}");

                            return Task.CompletedTask;
                        },
                        OnChallenge = ctx =>
                        {
                            return Task.CompletedTask;
                        }
                    };
                }
            );

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

            //Swagger Connection
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new Info
                {
                    Title = "BookMap Store Api",
                        Version = "1.0.0"
                });
            });
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

            app.UseAuthentication();
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