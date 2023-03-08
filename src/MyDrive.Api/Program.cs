using FastEndpoints;
using MongoDB.Driver;
using MyDrive.Api.Files.Domain;
using System.Runtime.ConstrainedExecution;

namespace MyDrive.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            services.AddFastEndpoints();
            services.AddSingleton<IMongoClient, MongoClient>(s =>
            {
                var uri = s.GetRequiredService<IConfiguration>()["DBHOST"];
                return new MongoClient(uri);
            });
            services.AddSingleton<IMongoCollection<FileModel>>(s =>
            {
                var mongoClient = s.GetRequiredService<IMongoClient>();
                var DBName = s.GetRequiredService<IConfiguration>()["DBNAME"];
                var database = mongoClient.GetDatabase(DBName);
                var collection = database.GetCollection<FileModel>("Files");
                return collection;
            });
            var app = builder.Build();

            app.UseFastEndpoints();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}