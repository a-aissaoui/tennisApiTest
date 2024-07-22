
using tennisApiTest.Repositories;
using tennisApiTest.Services;

namespace tennisApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // add logging
            builder.Services.AddLogging(configure => configure.AddConsole());

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
            builder.Services.AddScoped<IPlayerService, PlayerService>();

            var app = builder.Build();

            // logging all requests on the console
            app.Use(async (context, next) =>
            {
                var logger = app.Logger;
                logger.LogInformation($"Request received for {context.Request.Method} {context.Request.Path}");
                await next.Invoke();
            });


            // Configure Swagger and redirect to Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty; // Serve Swagger UI at application root
            });


            //app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }


    }
}
