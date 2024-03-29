using CiklumTasks.ApplicationServices;
using CiklumTasks.Model;
using CiklumTasks.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System;

namespace CiklumTasks.API
{
    public class Startup
    {
        readonly string CiklumPolicy = "CiklumPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            RegisterApplicationServices(services);
            RegisterTransientServices(services);

            ConfigureCors(services);

            services.AddControllers();

            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("ciklumTaskDB")));

            //In memory, Install EntityFrameworkCore.InMemory
            //services.AddDbContext<Context>(opt =>  opt.UseInMemoryDatabase("ciklumTaskDB"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CiklumTask API",
                    Version = "v1",
                    Description = "Example CiklumTask Web API use",
                    Contact = new OpenApiContact
                    {
                        Name = "Alejandro Ojeda Maruny",
                        Email = "ojedamaruny@gmail.com",
                        Url = new Uri("https://github.com/scriptndestroy")
                    },
                });
            });
            services.AddResponseCaching();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CiklumTaskAPI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        #region Private methods
        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddTransient<ITasksService, TasksService>();
        }

        private static void RegisterTransientServices(IServiceCollection services)
        {
            services.AddTransient<ITasksRepository, TasksRepository>();
        }

        private void ConfigureCors(IServiceCollection services)
        {

            var frontendServerUrl = Configuration.GetValue<string>("FrontendServerUrl");
            var gitServerUrl = Configuration.GetValue<string>("GitServerUrl");
            services.AddCors(options =>
                options.AddPolicy(CiklumPolicy, builder =>
                    builder.WithOrigins(frontendServerUrl, gitServerUrl)                        
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                )
            );
        }
        #endregion
    }
}
