using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load ocelot.json
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

            // Register Swagger
            builder.Services.AddSwaggerGen();
            // Register Ocelot
            builder.Services.AddOcelot(builder.Configuration);

            // Other services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // app.UseSwagger();
                // app.UseSwaggerUI();
            }

            app.MapControllers();

            // Ocelot MUST be last
            await app.UseOcelot();

            app.Run();
        }
    }
}