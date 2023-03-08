using FastEndpoints;

namespace MyDrive.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddFastEndpoints();
            var app = builder.Build();

            app.UseFastEndpoints();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}