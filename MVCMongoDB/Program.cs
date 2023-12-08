using Microsoft.Extensions.Options;
using MVCMongoDB.Models;
using MVCMongoDB.Services;

namespace MVCMongoDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //inyeccion de dependencias sencillo
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            builder.Services.Configure<BarSettings>(builder.Configuration.GetSection(nameof(BarSettings)));
            builder.Services.AddSingleton<IBarSettings>(provider => provider.GetRequiredService<IOptions<BarSettings>>().Value);
            builder.Services.AddSingleton<BeerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Enable CORS
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}