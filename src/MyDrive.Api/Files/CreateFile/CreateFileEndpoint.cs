using FastEndpoints;
using MongoDB.Bson;
using MongoDB.Driver;
using MyDrive.Api.Files.Domain;

namespace MyDrive.Api.Files.CreateFile
{
    public class CreateFileEndpoint : Endpoint<CreateFileRequest, CreateFileResponse>
    {
        private readonly IMongoCollection<FileModel> mongoCollection;

        public CreateFileEndpoint(IMongoCollection<FileModel> mongoCollection)
        {
            this.mongoCollection = mongoCollection;
        }

        public override void Configure()
        {
            Post("/api/files");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateFileRequest req, CancellationToken ct)
        {
            var file = new FileModel
            {
                Name = req.Name,
                Id = ObjectId.GenerateNewId(),
                Size = req.Size,
                Type = req.Type,
            };
            this.mongoCollection.InsertOne(file);
            await SendAsync(new CreateFileResponse
            {
                Id = file.Id.ToString()
            },
            200, ct);
        }
    }
}
