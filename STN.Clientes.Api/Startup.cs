using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STN.Clientes.Data.EF;
using STN.Clientes.Data.EF.Repositories;
using STN.Clientes.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace STN.Clientes.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<StoreDataContext>();
            services.AddTransient<IClienteRepository, ClienteRepositoryEF>();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info() { Title = "STN Cliente", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, StoreDataContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DbInitializer.Initalizer(ctx);
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "STN Cliente - Swagger");
                s.RoutePrefix = "docs";
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
