
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Conexa.Infra.Ioc;
using Newtonsoft.Json;
using Conexa.Integration.Interface;
using Conexa.Integration;

namespace Conexa.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
     

        public void ConfigureServices(IServiceCollection services)
        {
            NativeInject.RegisterServices(services);
            services.AddHttpClient<IContractIntegrationWeathermap, ContractIntegrationWeathermap>();
            services.AddHttpClient<IContractIntegrationSpotify, ContractIntegrationSpotify>();

            services.AddControllers();          
            services.AddMvc().AddJsonOptions(opcoes =>
            {
                opcoes.JsonSerializerOptions.IgnoreNullValues = true;               
            });
           
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Conexa test V1");             
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
