using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BackSaludMigrantes.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba
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
            services.AddDbContext<DataContext>(options =>
            {

                var connectionString = Configuration.GetConnectionString("Connection")
                    .Replace("{{DB_ENDPOINT}}", Configuration.GetValue<string>("DB_ENDPOINT"))
                    .Replace("{{DB_PORT}}", Configuration.GetValue<string>("DB_PORT"))
                    .Replace("{{DB_NAME}}", Configuration.GetValue<string>("DB_NAME"))
                    .Replace("{{DB_USER}}", Configuration.GetValue<string>("DB_USER"))
                    .Replace("{{DB_PASSWORD}}", Configuration.GetValue<string>("DB_PASSWORD"));
                options.UseSqlServer(connectionString);
                
            //    options.UseSqlServer(@"Server=172.16.1.23\\SDSPRUEBD1,27849;Initial Catalog=SiAsegura;User ID=usrAppSiAsegura_B;Password=S1A$_18A$ul3s/*-/;encrypt=false;");
            });
            services.AddCors(options => options.AddPolicy(name: "default",
            policy =>
            {
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));              
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("default");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
             
               // context.Database.Migrate();
             
             
                var logger = LoggerFactory.Create(config =>
                {
                    config.AddConsole();
                }).CreateLogger("Program");

                var list = context.Location.ToList();

                logger.LogInformation("CADENA DE CONEXI�N: " + list);
            }
        }
    }
}
