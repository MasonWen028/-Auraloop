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

            // Register ConfigurationService with the required parameter
            builder.Services.AddSingleton<ConfigurationService>(provider => new ConfigurationService(configFilePath));
            builder.Services.AddSingleton<CookieService>();
            builder.Services.AddSingleton<GenericService>();
            builder.Services.AddSingleton<EncryptionService>();
            builder.Services.AddSingleton<OptionService>();

            //builder.Services.AddHttpClient<ProxyService>().ConfigurePrimaryHttpMessageHandler(HttpClientHandlerFactory.CreateHandler); ;
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<CookieHandlerMiddleware>();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}
