using CicklumTask.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CiklumTasks.API
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
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("ciklumTaskDB")));
            services.AddControllers();

            ConfigureCors(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebBeds API",
                    Version = "v1",
                    Description = "Example WebBeds Web API use",
                    Contact = new OpenApiContact
                    {
                        Name = "Alejandro Ojeda Maruny",
                        Email = "ojedamaruny@gmail.com",
                        Url = new Uri("https://github.com/scriptndestroy")
                    },
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CiklumTaskAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureCors(IServiceCollection services)
        {
            var frontendServerUrl = Configuration.GetValue<string>("FrontendServerUrl");
            services.AddCors(options =>
                options.AddPolicy("AllowOrigin", builder =>
                    builder.WithOrigins(frontendServerUrl)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                )
            );
        }
    }
}
