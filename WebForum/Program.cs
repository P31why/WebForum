
using Scalar.AspNetCore;
using WebForum.WebApi;

namespace WebForum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ServiceCollectionExtension.ConfigureOptions(builder.Services, builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            /*// Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                */app.MapOpenApi();
                app.MapScalarApiReference();
            //}

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
