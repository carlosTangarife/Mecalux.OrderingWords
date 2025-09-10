using Mecalux.OrderingWords.Application;
using Mecalux.OrderingWords.Infrastructure;
using Mecalux.OrderingWords.Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Mecalux.OrderingWords.Api
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
            // Add CORS policy - restrictive for security
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
                           .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
                           .WithHeaders("Content-Type", "Authorization", "X-Requested-With")
                           .AllowCredentials();
                });
            });

            // Add services
            services.AddInfrastructureServicesRegistration();
            services.AddApplicationServices();

            // Add controllers with model validation
            services.AddControllers();

            // Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Mecalux OrderingWords API", 
                    Version = "v1",
                    Description = "API for ordering words and analyzing text statistics",
                    Contact = new OpenApiContact
                    {
                        Name = "Mecalux Development Team",
                        Email = "dev@mecalux.com"
                    }
                });
            });

            // Add health checks
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Add Serilog request logging
            app.UseSerilogRequestLogging();

            // Global exception handling middleware
            app.UseMiddleware<GlobalExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mecalux OrderingWords API v1");
                    c.RoutePrefix = "swagger"; // Makes Swagger available at /swagger
                });
            }
            else
            {
                // Production error handling
                app.UseHsts(); // HTTP Strict Transport Security
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // Use restrictive CORS policy
            app.UseCors("AllowSpecificOrigins");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
