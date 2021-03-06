﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using MyAppCore1.Services;
using MyAppCore1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyAppCore1 {
    public class Startup {
        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddSingleton(Configuration);//Se agrega para que la clase "Saludo" puede insertarlo en su constructor al instanciar
            services.AddSingleton<ISaludo, Saludo>();
            services.AddScoped<IRestauranteData, SqlRestauranteData>();
            services.AddDbContext<MyAppCore1DbContext>(opciones => 
                    opciones.UseSqlServer(Configuration.GetConnectionString("MyAppCore1")));
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<MyAppCore1DbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            ISaludo saludo) {
            loggerFactory.AddConsole();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler(new ExceptionHandlerOptions {
                    ExceptionHandler = context => context.Response.WriteAsync("Amontema...")
                });
            }

            app.UseFileServer();

            app.UseNodeModules(env.ContentRootPath);

            app.UseIdentity();

            app.UseMvc(ConfiguracionRutas);

            app.Run(ctx => ctx.Response.WriteAsync("No encontrado"));

        }

        private void ConfiguracionRutas(IRouteBuilder rutaBuilder) {
            rutaBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
