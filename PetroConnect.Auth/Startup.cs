using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PetroConnect.API.Common;
using PetroConnect.API.Services;
using PetroConnect.Auth.Models;
using PetroConnect.Data.Context;

namespace PetroConnect.Auth
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
            services.AddControllers();
            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "PetroConnect Auth";
                    document.Info.Description = "Solution to petrol pump";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Petro Connect",
                        Email = string.Empty,
                        Url = ""
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "",
                        Url = ""
                    };
                };
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = true,
                    ValidAudience = appSettings.Audience,
                };
            });

            services.AddDbContext<PetroConnectContext>(
                op => op.UseSqlServer(Configuration.GetConnectionString("dbContext")));
            services.AddScoped<IUserService, UserService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AuthCorsPolicy",
                builder =>
                {
                    builder.WithOrigins(appSettings.ClientAppUrl, "localhost", "localhost:4200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });

                // options.AddDefaultPolicy(
                //builder =>
                //{
                //    builder.WithOrigins(appSettings.ClientAppUrl).AllowAnyHeader().AllowAnyMethod();
                //});


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddColoredConsoleLogger();
            //loggerFactory.AddColoredConsoleLogger(c =>
            //{
            //    c.LogLevel = LogLevel.Information;
            //    c.Color = ConsoleColor.Blue;
            //});
            //loggerFactory.AddColoredConsoleLogger(c =>
            //{
            //    c.LogLevel = LogLevel.Debug;
            //    c.Color = ConsoleColor.Gray;
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();
            // global cors policy 
            app.UseCors("AuthCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
