
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Conexa.Infra.Ioc;
using Conexa.Integration.Interface;
using Conexa.Integration;
using Conexa.Api.Errors;

namespace Conexa.Api
{
    public class Startup
    {
        private IConfiguration _configuration;
        public AppSettings settingsIntegration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

      
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(_configuration.GetSection(
                                     SettingsIntegration.SettingsIntegrations));
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

         public void OnGet()
    {
       
        _configuration.GetSection(SettingsIntegration.SettingsIntegrations).Bind(settingsIntegration);

    }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

         
            app.UseMiddleware<ExceptionMiddleware>();

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
