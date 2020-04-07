using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RaspberryDashboard_Backend.Hubs;
using RaspberryDashboard_Backend.Services;

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
            services.AddSignalR();

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                //Allow all Orgins
                //Wildcard is not allowed with .AllowCredentials()
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("*");
            }));

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
                endpoints.MapHub<DiscordHub>("/discordhub");
                endpoints.MapHub<LightHub>("/lighthub");
            });
        }
    }
}