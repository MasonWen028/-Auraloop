using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using NeteaseCloudMusicApi_SDK.Helpers.RequestClient;
using NeteaseCloudMusicApi_SDK.Services;
using System.Reflection;

namespace NeteaseCloudMusicApi_SDK
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin() // Allows all origins
                          .AllowAnyHeader() // Allows any headers
                          .AllowAnyMethod(); // Allows any HTTP methods (GET, POST, PUT, DELETE, etc.)
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<CacheService>();
            builder.Services.AddSingleton<RequestProvider>();
            builder.Services.AddServicesFromFolder(Assembly.GetExecutingAssembly(), "Services.Impls");


            string configFilePath = Path.Combine(AppContext.BaseDirectory, "config.json");
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Netease Cloud Music API",
                    Version = "v1",
                    Description = "API documentation for the Netease Cloud Music application."
                });
                c.EnableAnnotations();
            });
            // Register ConfigurationService with the required parameter
            builder.Services.AddSingleton<ConfigurationService>(provider => new ConfigurationService(configFilePath));
            builder.Services.AddSingleton<CookieService>();
            builder.Services.AddSingleton<GenericService>();
            builder.Services.AddSingleton<EncryptionService>();
            builder.Services.AddSingleton<OptionService>();

            builder.Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Limits.MaxResponseBufferSize = 104857600; // 100 MB
                options.Limits.MaxRequestBufferSize = 104857600; // 100 MB
                options.Limits.MaxRequestBodySize = 104857600;   // 100 MB
            });

            //builder.Services.AddHttpClient<ProxyService>().ConfigurePrimaryHttpMessageHandler(HttpClientHandlerFactory.CreateHandler); ;
            builder.Services.AddHttpContextAccessor();

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ConfigureEndpointDefaults(listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {                
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Netease Cloud Music API V1");
                });
            }

            


            app.UseMiddleware<CookieHandlerMiddleware>();

            app.UseResponseCompression();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}
