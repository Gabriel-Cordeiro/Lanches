using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dominio.interfaces.memoria;
using dominio.interfaces.servicos;
using dominio.servicos;
using dominio.servicos;
using infraestrutura.memoria;
using infraestrutura.memoria.repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LanchesApi
{
    public class Startup
    {
        static public IConfigurationRoot Configuration;
        public Startup()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddScoped<IIngredienteServico, IngredienteServico>();
            services.AddScoped<IIngredienteDados, IngredienteDados>();
            services.AddScoped<ILancheDados, LancheDados >();
            services.AddScoped<ILancheServico, LancheServico>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
