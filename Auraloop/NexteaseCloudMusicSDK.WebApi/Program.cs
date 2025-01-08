using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.Services;
using NexteaseCloudMusicSDK.WebApi.Middlewares;

namespace NexteaseCloudMusicSDK.WebApi
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
                    policy.SetIsOriginAllowed(origin => true) // Allows all origins
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials(); // Allows any HTTP methods (GET, POST, PUT, DELETE, etc.)
                });
            });

            builder.Services.AddHttpClient<NetEaseApiClient>();

            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IArtistService, ArtistService>();
            builder.Services.AddSingleton<RequestContext>();

            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<AuthMiddleware>();

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}