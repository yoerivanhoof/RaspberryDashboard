using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using RaspberryDashboard_Backend.Hubs;
using RaspberryDashboard_Backend.Services;
using System;

namespace RaspberryDashboard_Backend
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
            services.AddSignalR()
                .AddJsonProtocol(options => { options.PayloadSerializerOptions.PropertyNamingPolicy = null; });

            Console.WriteLine("Orgin " + Environment.GetEnvironmentVariable("AllowOrgin"));

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                //Allow all Orgins
                //Wildcard is not allowed with 
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(_ => true) //workaround to the max
                    .AllowCredentials();
            }));

            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddSingleton<IDiscordService, DiscordService>();
            services.AddSingleton<IMqttService, MqttService>();
            services.AddSingleton<ILightService, LightService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDiscordService discordService,
            IMqttService mqttService, ILightService lightService)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<DiscordHub>("/hub/discord");
                endpoints.MapHub<LightHub>("/hub/light");
            });
        }
    }
}